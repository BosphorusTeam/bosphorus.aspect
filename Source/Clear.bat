@echo off
set dir=%~dp0

RD packages /S /Q
FOR /D /R %dir% %%X IN (bin) DO RMDIR /S /Q "%%X"
FOR /D /R %dir% %%X IN (obj) DO RMDIR /S /Q "%%X"
FOR /D /R %dir% %%X IN (Debug) DO RMDIR /S /Q "%%X"
FOR /D /R %dir% %%X IN (Release) DO RMDIR /S /Q "%%X"

pause
