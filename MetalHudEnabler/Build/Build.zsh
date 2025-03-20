#!/bin/zsh

dotnet publish -o ./Build/bin
cd ./Build
mkdir -p MetalHudEnabler.app/Contents/Ressources
cp ./Info.plist ./MetalHudEnabler.app/Contents/Info.plist
cp ./metal.icns ./MetalHudEnabler.app/Contents/Ressources/metal.icns

mkdir MetalHudEnabler.app/Contents/MacOS
for file in $(find ./bin -type f); do
    parent=$file:h
    if [[ $parent = "./bin" ]]; then
        name=$file:t
        cp $file "./MetalHudEnabler.app/Contents/MacOS/$name"
    fi
done
