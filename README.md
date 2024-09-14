# HaconMouseTools
Windows Mouse helper as a console application.

At this time all it does is moving the Windows mouse cursor to the current window.

Based on code from:

https://github.com/rhinterndorfer/MousePointerReposition.git

## Usage

```powershell
HaconMouseTools.exe -w
```

## Build

Download the repo and build it in Visual Studio 2022+

## Installation

Copy all `dll` files and the `HaconMouseTools.exe`  file from the resulting `bin` directory to a new `HaconMouseTools` directory under your tools/utilities directory.

## Keyboard Shortcut

I use this with Microsoft PowerToy's `Keyboard Manager` to map a keyboard shortcut.

```powershell
Shortcut: Win+M
Action: Run Program
App: C:\util\HaconMouseTools\HaconMouseTools.exe
Args: -w
Elevation: Normal
Visibility: Hidden
```

I also use:

```powershell
Shortcut: Win+K
Action: Run Program
App: C:\util\nircmd.exe
Args: sendmouse left click
Elevation: Normal
Visibility: Hidden
```

to fire a left-mouse click via a keyboard shortcut. This use `nircmd.exe` from  http://www.nirsoft.net 

I have a bunch of keyboard shortcuts to bring certain application to the foreground, (`Win+1`), while that application is now the current window, my mouse cursor is still located someone on one of my four monitors. To move it to the current windows I can just press `Win+M` and `Win+K` to do a left mouse click.
