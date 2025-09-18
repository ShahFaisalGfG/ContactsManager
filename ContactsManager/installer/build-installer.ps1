<#
Build Inno Setup installer on Windows using Inno Setup Compiler (ISCC.exe).
Requirements: Inno Setup (https://jrsoftware.org/), optionally signtool.exe for signing.
#>
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
$iss = Join-Path $scriptDir 'ContactsManager.iss'

if (-not (Test-Path $iss)) {
    Write-Error "Missing $iss"
    exit 1
}

Write-Host "Locating Inno Setup Compiler (ISCC.exe)..."

# Try configured path, then common install paths, then PATH
$candidates = @(
    'C:\Program Files (x86)\Inno Setup 6\ISCC.exe',
    'C:\Program Files\Inno Setup 6\ISCC.exe'
)

# Check if ISCC is on PATH
try {
    $cmd = Get-Command ISCC.exe -ErrorAction Stop
    if ($cmd.Path) { $candidates += $cmd.Path }
} catch { }

$iscc = $null
foreach ($p in $candidates) {
    if (-not [string]::IsNullOrEmpty($p) -and (Test-Path $p)) { $iscc = $p; break }
}

if (-not $iscc) {
    Write-Host "ISCC.exe not found in common locations or PATH." -ForegroundColor Yellow
    Write-Host 'Please install Inno Setup 6 and re-run this script. Suggested commands:'
    Write-Host '  - (winget) Run in an elevated PowerShell: winget install --id InnoSetup.InnoSetup -e'
    Write-Host '  - (Chocolatey) Run in an elevated PowerShell: choco install innosetup -y'
    Write-Host 'After installation re-run this script. Or set the path in this script if ISCC is installed elsewhere.'
    exit 1
}

Write-Host "Found ISCC at: $iscc"

Write-Host "Compiling installer..."
Start-Process -FilePath $iscc -ArgumentList @($iss) -Wait -NoNewWindow

if ($LASTEXITCODE -ne 0) { Write-Error "ISCC failed with exit code $LASTEXITCODE"; exit $LASTEXITCODE }

Write-Host "Installer build finished. Output is in the script folder."
