This is just a small project I had, the script is mainly about using AvaloniaUI TrayIcons and executing a few terminal commands to activate metalHUD on mac metal games.

Please be aware that any potential release will not be notarized and might lead to errors when launched for the first time on another machine.


# Install process

From source :
.NET must be installed (by default it will require you to have version 9.0 unless you change it in the csproj file)

run file Build.zsh
Alternatively you can just use dotnet publish if you only want the executables

From github releases :

Download and extract the app
Right click on your parent folder -> services -> open terminal and type 
`xattr -r -d com.apple.quarantine MetalHudEnabler.app`