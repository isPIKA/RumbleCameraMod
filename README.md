# RumbleCameraMod

A lightweight [MelonLoader](https://github.com/LavaGang/MelonLoader) mod for **Rumble Club** that lets you adjust the gameplay camera distance while preserving the game's original top-down angle.

> [!IMPORTANT]
> This is an unofficial community project and is not affiliated with or endorsed by Lightfox Games, Rumble Club, or MelonLoader. Use mods only where the game's rules permit them.

## Features

- Adjust camera distance in real time
- Preserve the original top-down viewing angle
- Reset instantly to the original distance
- Supports the game's grounded Cinemachine camera
- Makes no changes to punch strength, movement, networking, or other gameplay mechanics

## Controls

| Action | Control |
|---|---|
| Move the camera farther or closer | Hold **Left Alt** and use the **mouse wheel** |
| Reset to the original distance | Hold **Left Alt** and press **R** |

The distance multiplier is limited to **0.5×–3.0×**.

## Requirements

- Windows
- A legitimate installation of Rumble Club
- MelonLoader 0.7.3 or a compatible version
- .NET 6 SDK to build the project
- Visual Studio 2022 with the **.NET desktop development** workload

Tested with:

- Rumble Club 1.9.2
- Unity 2022.3.62f2
- MelonLoader 0.7.3 Open Beta
- IL2CPP x64 / .NET 6 runtime

Game or loader updates may require the mod to be rebuilt or updated.

## Installation

1. Install MelonLoader into the Rumble Club game directory.
2. Start the game once and close it. This generates the required IL2CPP assemblies and the `Mods` folder.
3. Build this project, or obtain `RumbleCameraMod.dll` from a trusted release.
4. Copy only `RumbleCameraMod.dll` into:

   ```text
   C:\Program Files (x86)\Steam\steamapps\common\Rumble Club\Mods
   ```

5. Start Rumble Club normally through Steam. No separate DLL injector is required.
6. Confirm that the MelonLoader console reports `Top-Down Camera Mod v1.3 loaded.`.

### Uninstall

Delete `RumbleCameraMod.dll` from the game's `Mods` folder.

## Building from source

1. Install Rumble Club and MelonLoader.
2. Start the game once so MelonLoader creates `MelonLoader\Il2CppAssemblies`.
3. Install the .NET 6 SDK and Visual Studio 2022.
4. Clone this repository:

   ```powershell
   git clone https://github.com/isPIKA/RumbleCameraMod.git
   cd RumbleCameraMod
   ```

5. Open `RumbleCameraMod.slnx` in Visual Studio.
6. Select the **Release** configuration.
7. Choose **Build → Rebuild Solution**.
8. Find the compiled mod at:

   ```text
   RumbleCameraMod\bin\Release\net6.0\RumbleCameraMod.dll
   ```

The project defaults to Steam's standard Windows installation path. For a custom game location, set the MSBuild property `RumbleClubDir`:

```powershell
dotnet build -c Release -p:RumbleClubDir="D:\Games\Steam\steamapps\common\Rumble Club"
```

## Troubleshooting

### References cannot be found

Ensure MelonLoader has been installed and the game has been started at least once. The project expects generated assemblies under:

```text
Rumble Club\MelonLoader\Il2CppAssemblies
```

For a non-standard Steam path, set `RumbleClubDir` as shown in the build instructions.

### The mod loads, but the camera does not change

Enter a match before using the controls. The grounded Cinemachine virtual camera may not exist while the game is still in menus.

### The mod stops working after an update

Start the game once without the mod so MelonLoader can regenerate its IL2CPP assemblies, then rebuild the project against the new files.

## Privacy and included files

This repository contains only original source and project files. It intentionally does **not** include Rumble Club, Unity, Cinemachine, MelonLoader, or generated IL2CPP binaries.

## License

Licensed under the [MIT License](LICENSE).
