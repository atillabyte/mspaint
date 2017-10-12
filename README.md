# MSPaint Launcher

![Screenshot](https://atil.la/x/img/Dq1dYngyBW.png)

## Usage
In order to set the default version of MSPaint to use, simply start it up without any additional arguments except the version.  
(e.g. `c:\> mspaint xp` _or_ `c:\> mspaint 7` _or_ `c:\> mspaint win7` _or_ `c:\> mspaint windows8` _... and so on._)

When you right-click an image in Windows Explorer and _'Open with Paint'_ the MSPaint version you've selected will be used.


To load an image with a specific version from the command-line, append the path after the version in the arguments.  
(e.g. `c:\> mspaint xp "C:\Users\Allie\Kitten.png"`)

## Installation 
- Windows users can install using [Chocolatey](https://chocolatey.org/) package manager:
      `c:\> choco install mspaint --version 1.1.2` 
  [MSPaint Chocolatey Package](https://chocolatey.org/packages/mspaint/)
