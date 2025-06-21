# Wizard2AssetsUnpacker

A cross-platform command-line tool for unpacking and decrypting asset bundles from Shadowverse: Worlds Beyond game files.

## Features

- Decrypts and unpacks asset bundles
- Supports multiple languages
- Outputs decrypted files for further analysis or modding
- Simple CLI interface

## Requirements

- .NET 9.0 SDK or newer
- Windows, Linux, or macOS

## Usage

1. **Build the project:**

   ```powershell
   dotnet build
   ```

2. **Run the CLI:**

   ```powershell
   dotnet run --project Wizard2AssetsUnpacker [command] [options]
   ```

## Commands & Options

### manifest

Download manifest from server.

- `--version <version>` (required): The asset manifest version to download
- `--variant <LangType>`: The asset manifest variant to download (default: Chs)
- `--format <FormatOption>`: The format to save the manifest (default: Raw; options: Raw, Json)

### version

Fetch current assets and asset manifest version.

- `--format <FormatOption>`: The format to save the version info (default: Json; options: Raw, Json)

### asset

Download and decrypt assetbundles. Has subcommands:

#### asset decrypt

- `--file <path>` (required): Path of encrypted assetbundle file
- `--manifest <path>` (required): Path of asset manifest to get decrypt key

#### asset download

- `name <assetName>` (argument): The asset name to download (from manifest)
- `--manifest <path>` (required): Path of asset manifest to get decrypt key

## Example

```powershell
# Download manifest
Wizard2AssetsUnpacker.exe manifest --version 123456 --variant Chs --format Json

# Fetch version info
Wizard2AssetsUnpacker.exe version --format Json

# Decrypt an assetbundle
Wizard2AssetsUnpacker.exe asset decrypt --file "JKCNHLX5FIZINWEDTT2ND2WU4Y" --manifest "assetbundle.Chs.manifest"

# Download an assetbundle by name
Wizard2AssetsUnpacker.exe asset download "asset_name" --manifest "assetbundle.Chs.manifest"
```

## Project Structure

- `Classes/` - Core command and asset handling classes
- `LibConeshell/` - Cryptography and decryption logic
- `Models/` - Data models for requests and responses
- `Config.cs` - Configuration handling
- `Program.cs` - CLI entry point

## Configuration File (`Config.json`)

The application uses a `Config.json` file for runtime configuration. This file is required and must be placed in the output directory.

**Do not share your actual configuration values.**

### Structure

The configuration file is a JSON object with the following fields:

- `AssetBundleAddress`: URL template for asset bundle downloads
- `ManifestAddress`: URL template for manifest downloads
- `VersionAddress`: URL for version info
- `CommonHeader`: Common request header (string)
- `RoutingHeader`: Routing header (string)
- `AppVersion`: Application version (string)
- `DeviceUUID`: Device UUID (string)
- `MD5Salt`: Salt for MD5 operations (string)
- `AssetBundleBaseKeys`: Base keys for asset bundle decryption (string)
- `ClientId`: Client identifier (number)
- `DeviceInfo`: Object containing device information:
  - `Platform`: Platform identifier (string or number)
  - `Device`: Device identifier (string or number)
  - `DeviceName`: Name of the device (string)
  - `PlatformOSVersion`: OS version (string)
  - `GPUVendor`: GPU vendor (string)
  - `GraphicsMemoryMB`: Graphics memory in MB (string or number)
  - `ProcessorType`: Processor type (string)

**Note:** All values are required for proper operation. Do not commit your real configuration to public repositories.

### Example

Below is an example structure for `Config.json`. **Do not use real values from your environment.**

```json
{
  "AssetBundleAddress": "https://example.com/dl/assetbundles/Windows/{0}/{1}",
  "ManifestAddress": "https://example.com/dl/manifests/Windows/{0}/assetbundle.{1}.manifest",
  "VersionAddress": "https://example.com/version/info",
  "CommonHeader": "your_common_header_here",
  "RoutingHeader": "your_routing_header_here",
  "AppVersion": "1.0.0",
  "DeviceUUID": "your-device-uuid",
  "MD5Salt": "your-md5-salt",
  "AssetBundleBaseKeys": "your-base-keys",
  "ClientId": 1234567890,
  "DeviceInfo": {
    "Platform": "4",
    "Device": "3",
    "DeviceName": "Example Device Name",
    "PlatformOSVersion": "Example OS Version",
    "GPUVendor": "Example GPU Vendor",
    "GraphicsMemoryMB": "8192",
    "ProcessorType": "Example Processor"
  }
}
```

## License

MIT License
