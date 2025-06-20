# Wizard2AssetsUnpacker

A cross-platform command-line tool for unpacking and decrypting asset bundles from Wizard2 game files.

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

## License

MIT License
