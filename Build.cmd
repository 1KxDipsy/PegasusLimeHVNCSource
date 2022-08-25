@echo off
pushd "%~dp0"
powershell Compress-7Zip "Source\bin\Release" -ArchiveFileName "PEGASUSFULLVERSION.zip" -Format Zip
:exit
popd
@echo on
