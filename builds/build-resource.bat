@echo off
SET builddir=%~dp0

@echo Building Resources
"%~dp0..\src\Frapid.Web\bin\frapid.exe" create resource
