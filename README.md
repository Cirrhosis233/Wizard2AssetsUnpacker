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
- `--variant <LangType>`: The asset manifest variant to download (default: chs)
  - Available values: `jpn` (1), `eng` (2), `kor` (3), `chs` (4), `cht` (5)
- `--format <FormatOption>`: The format to save the manifest (default: raw)
  - Available values: `raw` (0), `json` (1)

### version

Fetch current assets and asset manifest version.

- `--format <FormatOption>`: The format to save the version info (default: json)
  - Available values: `raw` (0), `json` (1)

### asset

Download and decrypt assetbundles. Has subcommands:

#### asset decrypt

- `--file <path>` (required): Path of encrypted assetbundle file
- `--manifest <path>` (required): Path of asset manifest to get decrypt key

#### asset download

- `name <assetName>` (argument): The asset name to download (from manifest)
- `--manifest <path>` (required): Path of asset manifest to get decrypt key

### metadb

Decrypt game created meta database.

- `path <path>` (argument): The path to the meta database created by the game

## Example

```powershell
# Download manifest
Wizard2AssetsUnpacker.exe manifest --version 123456 --variant chs --format json

# Fetch version info
Wizard2AssetsUnpacker.exe version --format json

# Decrypt an assetbundle
Wizard2AssetsUnpacker.exe asset decrypt --file "JKCNHLX5FIZINWEDTT2ND2WU4Y" --manifest "assetbundle.Chs.manifest"

# Download an assetbundle by name
Wizard2AssetsUnpacker.exe asset download "asset_name" --manifest "assetbundle.Chs.manifest"

# Decrypt a meta database
Wizard2AssetsUnpacker.exe metadb "path/to/meta.db"
```

## Project Structure

- `Classes/` - Core command and asset handling classes
- `LibConeshell/` - Cryptography and decryption logic
- `Models/` - Data models for requests and responses
- `Config.cs` - Configuration handling
- `Program.cs` - CLI entry point

## Configuration File (`Config.json`)

The application uses a `Config.json` file for runtime configuration. This file is required and must be placed in the output directory.

**Do not share your account associated values like DeviceInfo and ClientId.**

### Structure

The configuration file is a JSON object with the following fields:

- `AssetBundleAddress`: URL template for asset bundle downloads (string)
- `ManifestAddress`: URL template for manifest downloads (string)
- `VersionAddress`: URL for version info (string)
- `CommonHeader`: Common request header (string, base64 encoded)
- `RoutingHeader`: Routing header (string)
- `AppVersion`: Application version (string)
- `DeviceUUID`: Device UUID (string)
- `MD5Salt`: Salt for MD5 operations (string)
- `AssetBundleBaseKeys`: Base keys for asset bundle decryption (string, base64 encoded)
- `Sqlite3mcKey`: Key for SQLite meta database decryption (string, base64 encoded)
- `Sqlite3mcBaseKey`: Base key for SQLite meta database decryption (string, base64 encoded)
- `ClientId`: Client identifier / user id (long)
- `DeviceInfo`: Object containing device information:
  - `Platform`: Platform identifier (number)
    - Available values: `0` (NONE), `1` (IOS), `2` (ANDROID), `4` (STEAM), `5` (EPIC)
  - `Device`: Device identifier (number)
    - Available values: `1` (IOS), `2` (ANDROID), `3` (WINDOWS), `4` (MAC)
  - `DeviceName`: Name of the device (string)
  - `PlatformOSVersion`: OS version (string)
  - `GPUVendor`: GPU vendor (string)
  - `GraphicsMemoryMB`: Graphics memory in MB (string)
  - `ProcessorType`: Processor type (string)

### Example

Below is an example structure for `Config.json`.

```json
{
  "AssetBundleAddress": "https://example.com/dl/assetbundles/Windows/{0}/{1}",
  "ManifestAddress": "https://example.com/dl/manifests/Windows/{0}/assetbundle.{1}.manifest",
  "VersionAddress": "https://example.com/version/info",
  "CommonHeader": "your-common-header-base64",
  "RoutingHeader": "your_routing_header_here",
  "AppVersion": "1.0.0",
  "DeviceUUID": "your-device-uuid",
  "MD5Salt": "your-md5-salt",
  "AssetBundleBaseKeys": "your-base-keys-base64",
  "Sqlite3mcKey": "your-sqlite3mc-key-base64",
  "Sqlite3mcBaseKey": "your-sqlite3mc-base-key-base64",
  "ClientId": 1234567890,
  "DeviceInfo": {
    "Platform": 4,
    "Device": 3,
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
