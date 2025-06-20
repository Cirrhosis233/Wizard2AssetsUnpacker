namespace Wizard2AssetsUnpacker.Classes
{
    public class AssetBundleStream : FileStream
    {
        private byte[]? keys = null;

        public AssetBundleStream(string filename, long key) : base(filename, FileMode.Open, FileAccess.Read, FileShare.None)
        {
            var baseKeys = Convert.FromBase64String(Config.Instance.AssetBundleBaseKeys);
            var buffer = new byte[baseKeys.Length * 8];
            var inKeys = BitConverter.GetBytes(key);

            uint v11 = 0;
            for (int i = 0; ; i += 8)
            {
                var currentBaseKeys = baseKeys;
                if (currentBaseKeys == null)
                    throw new InvalidOperationException("BaseKeys is null");

                if ((int)v11 >= currentBaseKeys.Length)
                    break;

                var v16 = currentBaseKeys[v11];
                for (int j = 0; j < 8; ++j)
                {
                    int idx = i + j;
                    if (idx >= buffer.Length)
                        throw new IndexOutOfRangeException();

                    buffer[idx] = v16;
                    buffer[idx] ^= inKeys[j];
                }
                v11++;
            }

            keys = buffer;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = base.Read(buffer, offset, count);
            if (bytesRead == 0)
                return 0;

            long position = Position - bytesRead;
            if (position < 0x100)
            {
                int temp = offset - (int)position;
                position = 0x100;
                offset = temp + 0x100;
            }

            if (offset < bytesRead)
            {
                if (buffer == null)
                    throw new InvalidOperationException("Buffer is null");

                do
                {
                    if (offset >= buffer.Length)
                        throw new IndexOutOfRangeException("Buffer overflow");

                    if (keys == null)
                        throw new InvalidOperationException("Keys are null");

                    int keyIdx = (int)(position % keys.Length);
                    if (keyIdx >= keys.Length)
                        throw new IndexOutOfRangeException("Key index out of range");

                    buffer[offset] ^= keys[keyIdx];
                    position++;
                    offset++;
                }
                while (offset < bytesRead);
            }

            return bytesRead;
        }
    }

}
