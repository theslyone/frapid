SET builddir=%~dp0
SET pubdir=C:\frapid-published
cd %builddir%
if exist "../src/Frapid.Web/Areas/Frapid.Paylink/Frapid.Paylink.sln" (
	@echo Building Paylink Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /v:detailed /fileLogger  /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Paylink/Frapid.Paylink.sln /p:VisualStudioVersion=14.0
)
cd %builddir%
pause