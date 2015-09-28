#define MyAppName "MongoDBLogger"
#define MyAppVersion "1.0"
#define MyAppPublisher "Excelsior"
#define MyAppURL "http://www.excelsior-gmbh.de/"
#define MyAppExeName "archive.exe"
#define MyAppSetupName 'excelsior'
#define SetupScriptVersion '0'

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppID={{ABF24F87-16E6-4C42-B462-5EAD99D74C13}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\pGina\Plugins\Contrib
DefaultGroupName={#MyAppPublisher}\{#MyAppName}
AllowNoIcons=true
LicenseFile=..\LICENSE
OutputBaseFilename={#MyAppName}-{#MyAppVersion}
SetupIconFile=..\install.ico
Compression=lzma/Max
SolidCompression=true
AppCopyright=Excelsior Gmbh
ExtraDiskSpaceRequired=6
DisableDirPage=auto
AlwaysShowDirOnReadyPage=yes
AlwaysShowGroupOnReadyPage=yes
DisableProgramGroupPage=auto

ArchitecturesInstallIn64BitMode=x64 ia64

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "..\MongoDBLogger\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[UninstallDelete]
Type:files; Name: "{app}"
