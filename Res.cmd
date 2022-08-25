@echo off
pushd "%~dp0"
powershell Expand-7Zip -ArchiveFileName "Source\PEGASUS_LIME\Properties\Resources.7z.001" -TargetPath "Source\PEGASUS_LIME\Properties\"
:exit
popd
@echo on
