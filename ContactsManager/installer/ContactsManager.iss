; Inno Setup script to package Contacts Manager
#define SrcRelease "..\\bin\\Release"
#define SrcRoot ".."

[Setup]
AppName=Contacts Manager
AppVersion=1.0.0
DefaultDirName={pf64}\Contacts Manager
DefaultGroupName=Contacts Manager
OutputBaseFilename=ContactsManager-Setup-{appversion}
Compression=lzma2/ultra
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=admin
; Use project icon as installer icon
SetupIconFile={#SrcRoot}\\free-icon-contact-book-6361506.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
; Copy project icon files into the installed app folder
Source: "{#SrcRoot}\\free-icon-contact-book-6361506.ico"; DestDir: "{app}\\icons"; Flags: ignoreversion
Source: "{#SrcRoot}\\icons8-contact-64.ico"; DestDir: "{app}\\icons"; Flags: ignoreversion
Source: "{#SrcRelease}\\ContactsManager.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SrcRelease}\\ContactsManager.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SrcRelease}\\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SrcRelease}\\*.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SrcRelease}\\*.pdb"; DestDir: "{app}"; Flags: ignoreversion; Check: DebugClose

[Icons]
Name: "{group}\\Contacts Manager"; Filename: "{app}\\ContactsManager.exe"; IconFilename: "{app}\\icons\\free-icon-contact-book-6361506.ico"
Name: "{commondesktop}\\Contacts Manager"; Filename: "{app}\\ContactsManager.exe"; IconFilename: "{app}\\icons\\free-icon-contact-book-6361506.ico"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Run]
Filename: "{app}\\ContactsManager.exe"; Description: "Launch Contacts Manager"; Flags: nowait postinstall skipifsilent

[Code]
function DebugClose(): Boolean;
begin
  Result := False;
end;
