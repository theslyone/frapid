@echo off
SET builddir=%~dp0
rmdir "%~dp0..\src\Frapid.Web\bin" /Q /S
xcopy "%~dp0..\src\Frapid.Web\Resources\_Configs\Assets" "%~dp0..\src\Frapid.Web\Resources\Configs\Assets\" /s/y


if exist "../src/Frapid.Web.sln" (
	@echo Building Frapid.Web
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Dashboard/Frapid.Dashboard.sln" (
	@echo Building Frapid Dashboard
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Dashboard/Frapid.Dashboard.sln /p:VisualStudioVersion=14.0
)


if exist "../src/Frapid.Web/Areas/Frapid.WebsiteBuilder/Frapid.WebsiteBuilder.sln" (
	@echo Building WebsiteBuilder Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.WebsiteBuilder/Frapid.WebsiteBuilder.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Reports/Frapid.Reports.sln" (
	@echo Building Frapid Reporting Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Reports/Frapid.Reports.sln /p:VisualStudioVersion=14.0
)


if exist "../src/Frapid.Web/Areas/Frapid.Authorization/Frapid.Authorization.sln" (
	@echo Building Frapid Authorization Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Authorization/Frapid.Authorization.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Config/Frapid.Config.sln" (
	@echo Building Config Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Config/Frapid.Config.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Core/Frapid.Core.sln" (
	@echo Building Core Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Core/Frapid.Core.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Account/Frapid.Account.sln" (
	@echo Building Account Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Account/Frapid.Account.sln /p:VisualStudioVersion=14.0
)


if exist "../src/Frapid.Web/Areas/Frapid.Forms/Frapid.Forms.sln" (
@echo Building Forms Module
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/Frapid.Forms/Frapid.Forms.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/MixERP.Forums/MixERP.Forums.sln" (
	@echo Building Forums Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/MixERP.Forums/MixERP.Forums.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/MixERP.Helpdesk/MixERP.Helpdesk.sln" (
	@echo Building Helpdesk Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/MixERP.Helpdesk/MixERP.Helpdesk.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/MixERP.Finance/MixERP.Finance.sln" (
	@echo Building Finance Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/MixERP.Finance/MixERP.Finance.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/MixERP.HRM/MixERP.HRM.sln" (
	@echo Building HRM Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Debug ../src/Frapid.Web/Areas/MixERP.HRM/MixERP.HRM.sln /p:VisualStudioVersion=14.0
)

if exist "C:\Program Files\Redis\redis-cli.exe" (
	@echo Flusing Redis Cache
	"C:\Program Files\Redis\redis-cli.exe" "flushall"
)

@echo Bundling SQL
cd ..\builds-sql\
call all.bat
@echo Creating PostgreSQL Tenant
cd %builddir%..\src\Frapid.Web\bin\
call frapid.exe create site postgresql.localhost provider Npgsql
@echo Creating SQL Server Tenant
call frapid.exe create site sqlserver.localhost provider System.Data.SqlClient
@echo Creating a Test App
call frapid.exe create app TestApp