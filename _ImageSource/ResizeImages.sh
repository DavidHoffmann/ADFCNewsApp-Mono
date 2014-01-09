#!/bin/bash

mkdir -p ../Android/Resources/drawable
mkdir -p ../Android/Resources/drawable-ldpi
mkdir -p ../Android/Resources/drawable-mdpi
mkdir -p ../Android/Resources/drawable-hdpi
mkdir -p ../Android/Resources/drawable-xhdpi
mkdir -p ../Android/Resources/drawable-xxhdpi

inkscape -z -e ../Android/Resources/drawable-ldpi/Icon.png -w 36 -h 36 Icon.svg
inkscape -z -e ../Android/Resources/drawable-mdpi/Icon.png -w 48 -h 48 Icon.svg
inkscape -z -e ../Android/Resources/drawable-hdpi/Icon.png -w 72 -h 72 Icon.svg
inkscape -z -e ../Android/Resources/drawable-xhdpi/Icon.png -w 96 -h 96 Icon.svg
inkscape -z -e ../Android/Resources/drawable-xxhdpi/Icon.png -w 144 -h 144 Icon.svg


