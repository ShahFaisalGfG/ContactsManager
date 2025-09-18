# Contacts Manager - Installer build instructions

Prerequisites

- Inno Setup 6 (Windows): https://jrsoftware.org/
- For signing: `signtool.exe` (comes with Windows SDK)

Build (Windows)

1. Build the project in Visual Studio in `Release` configuration.
2. Open PowerShell and run:

```powershell
cd .\ContactsManager\installer
.\build-installer.ps1
```

Build (WSL / Unix)

1. Ensure Inno Setup `ISCC.exe` is available under Wine or `iscc` is on PATH.
2. Run:

```bash
cd ContactsManager/installer
./build-installer.sh
```

Notes

- The Inno Setup script expects the Release output under `..\\bin\\Release` relative to the `installer` folder.
- To code-sign the generated EXE, use `signtool.exe sign /fd SHA256 /a /tr http://timestamp.digicert.com /td SHA256 /v path\to\ContactsManager-Setup-1.0.0.exe`.
- For creating an MSI instead of an EXE, see `WiX/` template in this folder.
