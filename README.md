# RumbleCameraMod

A lightweight [MelonLoader](https://github.com/LavaGang/MelonLoader) mod for **Rumble Club** that adjusts the gameplay camera distance while preserving the original top-down angle.

> [!IMPORTANT]
> This is an unofficial community project and is not affiliated with or endorsed by Lightfox Games, Rumble Club, or MelonLoader. Use mods only where the game's rules permit them.

## Download

**[Download RumbleCameraMod v1.3](https://github.com/isPIKA/RumbleCameraMod/raw/refs/heads/main/download/RumbleCameraMod.dll)**

SHA-256:

```text
a3cb2f820ea827064d06dd465aa7d8e2886b0c8226ca198a7d4e1a0f1874a6ad
```

## Features

- Adjust camera distance in real time
- Preserve the game's original top-down viewing angle
- Reset instantly to the original distance
- Support the grounded Cinemachine camera
- No changes to punch strength, movement, networking, or other gameplay mechanics

## Controls

| Action | Control |
|---|---|
| Move the camera farther or closer | Hold **Left Alt** and use the **mouse wheel** |
| Reset to the original distance | Hold **Left Alt** and press **R** |

The distance multiplier is limited to **0.5×–3.0×**.

## Requirements

- Windows
- A legitimate installation of Rumble Club
- [MelonLoader 0.7.3](https://github.com/LavaGang/MelonLoader/releases) or a compatible version
- Rumble Club started at least once after installing MelonLoader

Tested with Rumble Club 1.9.2, Unity 2022.3.62f2, MelonLoader 0.7.3 Open Beta, and IL2CPP x64 / .NET 6.

## Installation

### 1. Install MelonLoader

1. Download the installer from the official [MelonLoader releases page](https://github.com/LavaGang/MelonLoader/releases).
2. Run the installer.
3. Select `Rumble Club.exe`, normally located at:

   ```text
   C:\Program Files (x86)\Steam\steamapps\common\Rumble Club\Rumble Club.exe
   ```

4. Complete the installation.
5. Start Rumble Club once, wait for the main menu, and close it. MelonLoader will create the `Mods` folder and required IL2CPP files.

### 2. Install RumbleCameraMod

1. [Download RumbleCameraMod.dll](https://github.com/isPIKA/RumbleCameraMod/raw/refs/heads/main/download/RumbleCameraMod.dll).
2. Copy `RumbleCameraMod.dll` into:

   ```text
   C:\Program Files (x86)\Steam\steamapps\common\Rumble Club\Mods
   ```

3. Start Rumble Club normally through Steam.
4. Confirm that the MelonLoader console reports:

   ```text
   Top-Down Camera Mod v1.3 loaded.
   ```

No separate DLL injector is required. MelonLoader automatically loads the mod from the `Mods` folder.

### Uninstall

Delete `RumbleCameraMod.dll` from the game's `Mods` folder.

## Building from source

### Build requirements

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual Studio 2022 with the **.NET desktop development** workload
- Rumble Club with MelonLoader installed
- Generated files in `Rumble Club\MelonLoader\Il2CppAssemblies`

### Steps

1. Clone the repository:

   ```powershell
   git clone https://github.com/isPIKA/RumbleCameraMod.git
   cd RumbleCameraMod
   ```

2. Open `RumbleCameraMod.slnx` in Visual Studio.
3. Select the **Release** configuration.
4. Choose **Build → Rebuild Solution**.
5. Find the compiled mod at:

   ```text
   RumbleCameraMod\bin\Release\net6.0\RumbleCameraMod.dll
   ```

The project defaults to Steam's standard Windows installation path. For a custom location, pass `RumbleClubDir`:

```powershell
dotnet build -c Release -p:RumbleClubDir="D:\Games\Steam\steamapps\common\Rumble Club"
```

## Troubleshooting

### Missing references when building

Start the game once after installing MelonLoader. The project expects generated assemblies under:

```text
Rumble Club\MelonLoader\Il2CppAssemblies
```

For a custom installation path, set `RumbleClubDir` as shown above.

### The mod loads, but the camera does not change

Enter a match before using the controls. The grounded Cinemachine virtual camera may not exist in the menus.

### The mod stops working after a game update

Start the game once without the mod so MelonLoader can regenerate its IL2CPP assemblies, then rebuild the project.

## Privacy and included files

The source tree contains only original project files. It does not include game-owned, Unity, Cinemachine, MelonLoader, or generated IL2CPP libraries. The `download` directory contains only the compiled RumbleCameraMod binary.

## License

Licensed under the [MIT License](LICENSE).
