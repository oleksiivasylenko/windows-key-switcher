# Windows Key Swithcer

A tiny utility that lets you **turn off the left, right, or both Windows keys** with a single click.  
No registry edits, no scripts, no hacks — just run it and play without interruptions. 🎮

![App screenshot](assets/screenshot.png)

---

## Gaming?

If you’ve ever hit the Windows key by mistake in the middle of a match, you know the pain.  
This tool was built exactly for that reason: to avoid accidental desktop jumps while gaming or working.

---

## Features

- 🚫 Disable **left**, **right**, or **both** Windows keys  
- 🖱️ Super simple interface — no setup needed
- 🎮 Perfect for gaming sessions (works with all games)  
- 💾 Lightweight & portable (no installer)  
- 🖥️ I think - it's compatible with all Windows including Windows 11

---

## How to Use

1. Launch the app.  
2. Select which Windows key(s) you want to disable.  
3. Done — play without worrying about accidental presses.  
4. Close the app to restore normal behavior.  


---

## Download

👉 [See all releases here](https://github.com/oleksiivasylenko/windows-key-switcher/releases)  

Each release contains the following in the **Assets** section:
- `WinKeySwitcher-<version>-win-x64.exe`  
- `WinKeySwitcher-<version>-win-x86.exe`  
- Matching `.sha256` files for integrity verification  

---

## Verify Integrity (SHA-256)

After downloading, you can verify that the executable is authentic and hasn’t been tampered with.  
Each `.exe` has a corresponding `.sha256` file with the expected hash.

**Windows (PowerShell):**
```powershell
Get-FileHash .\WinKeySwitcher-<version>-win-x64.exe -Algorithm SHA256
Get-Content .\WinKeySwitcher-<version>-win-x64.exe.sha256

## License

This project is released under the **MIT License**.  
Free to use, modify, and share.
