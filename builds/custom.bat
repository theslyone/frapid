@echo off
SET builddir=%~dp0

cd %builddir%..\src\Frapid.Web\bin\

@echo Packing Resources
call frapid.exe pack resource

cd %builddir%

call test-postgres-tenant.bat

cd %builddir%

call test-sql-server-tenant.bat
