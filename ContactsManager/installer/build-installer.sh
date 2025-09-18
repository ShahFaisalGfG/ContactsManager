#!/usr/bin/env bash
# Build Inno Setup installer using Wine/ISCC (for WSL or Unix environments)
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ISS="$SCRIPT_DIR/ContactsManager.iss"

if [ ! -f "$ISS" ]; then
  echo "Missing $ISS"
  exit 1
fi

if command -v iscc >/dev/null 2>&1; then
  iscc "$ISS"
  exit $?
fi

if command -v wine >/dev/null 2>&1; then
  # Adjust path to ISCC.exe if installed under Wine
  WINE_ISCC="/c/Program Files (x86)/Inno Setup 6/ISCC.exe"
  wine "$WINE_ISCC" "$ISS"
  exit $?
fi

echo "ISCC not found. Install Inno Setup or run this script in WSL with Inno Setup available." >&2
exit 2
