
%windir%\microsoft.net\framework\v4.0.30319\msbuild DatabaseToolSuite.sln /p:PlatformTarget=AnyCPU /p:Configuration=Release /t:Rebuild

@IF %ERRORLEVEL% NEQ 0 PAUSE