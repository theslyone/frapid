@echo off
SET builddir=%~dp0
SET pubdir=C:\frapid-published

call build-resource.bat

@echo Bundling SQL
cd ..\builds-sql\
call all.bat

@echo Building and publishing all Freebe Modules

cd %builddir%
REM rmdir "%~dp0..\src\Frapid.Web\bin" /Q /S

REM Build all in debug mode first to enable and then Frapid.Web in release mode
if exist "../src/Frapid.Web.sln" (
	@echo Building Frapid.Web
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web.sln /p:VisualStudioVersion=14.0
)

if exist "../src/Frapid.Web/Areas/Frapid.Dashboard/Frapid.Dashboard.sln" (
	@echo Building Frapid Dashboard
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Dashboard/Frapid.Dashboard.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Dashboard\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.WebsiteBuilder/Frapid.WebsiteBuilder.sln" (
	@echo Building WebsiteBuilder Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.WebsiteBuilder/Frapid.WebsiteBuilder.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.WebsiteBuilder\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Account/Frapid.Account.sln" (
	@echo Building Account Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Account/Frapid.Account.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Account\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Calendar/Frapid.Calendar.sln" (
	@echo Building Frapid Calendar Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Calendar/Frapid.Calendar.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Calendar\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Reports/Frapid.Reports.sln" (
	@echo Building Frapid Reporting Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Reports/Frapid.Reports.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Reports\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Authorization/Frapid.Authorization.sln" (
	@echo Building Frapid Authorization Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Authorization/Frapid.Authorization.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Authorization\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Config/Frapid.Config.sln" (
	@echo Building Config Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Config/Frapid.Config.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Config\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/Frapid.Paylink/Frapid.Paylink.sln" (
	@echo Building Paylink Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/Frapid.Paylink/Frapid.Paylink.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\Frapid.Paylink\Properties\PublishProfiles\frapid-publish-profile.pubxml
)


if exist "../src/Frapid.Web/Areas/MixERP.Finance/MixERP.Finance.sln" (
	@echo Building Finance Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/MixERP.Finance/MixERP.Finance.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\MixERP.Finance\Properties\PublishProfiles\mixerp-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/MixERP.HRM/MixERP.HRM.sln" (
	@echo Building HRM Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/MixERP.HRM/MixERP.HRM.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\MixERP.HRM\Properties\PublishProfiles\mixerp-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/MixERP.Inventory/MixERP.Inventory.sln" (
	@echo Building Inventory Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/MixERP.Inventory/MixERP.Inventory.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\MixERP.Inventory\Properties\PublishProfiles\mixerp-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/MixERP.Purchases/MixERP.Purchases.sln" (
	@echo Building Purchase Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/MixERP.Purchases/MixERP.Purchases.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\MixERP.Purchases\Properties\PublishProfiles\mixerp-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/MixERP.Sales/MixERP.Sales.sln" (
	@echo Building Sales Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/MixERP.Sales/MixERP.Sales.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\MixERP.Sales\Properties\PublishProfiles\mixerp-publish-profile.pubxml
)

if exist "../src/Frapid.Web/Areas/SendGridMail/SendGridMail.sln" (
	@echo Building SendGridMail Module
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web/Areas/SendGridMail/SendGridMail.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Areas\SendGridMail\Properties\PublishProfiles\frapid-publish-profile.pubxml
)

@echo Copying relevant files to publish directory
cd "%~dp0..\src\Frapid.Web"
for %%s in ("db" "Overrides" "Reports", "Resources", "i18n", "scripts", "ScrudFactory", "Static", "styles", "bower_components", "lib") do echo Copying %%s && xcopy "%%s" "%pubdir%\%%s" /D/S/E/V/Q/I/Y

@echo Copy *.dll in module bin folders to temp directory and delete bin folder
cd %pubdir%\Areas
for /d /r %%i in (*bin*) do echo Copying %%i && @xcopy /D/S/E/V/Q/I/Y %%i "%~dp0..\src\UnreferencedBin" && @rmdir /s /q %%i

if exist "../src/Frapid.Web.sln" (
	@echo Publish Frapid.Web Bundle
	"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" /verbosity:quiet /nologo /property:Configuration=Release ../src/Frapid.Web.sln /p:VisualStudioVersion=14.0 /p:DeployOnBuild=true /p:PublishProfile=%builddir%..\src\Frapid.Web\Properties\PublishProfiles\frapid-publish-profile-2.pubxml
)

cd %builddir%..\src\Frapid.Web\bin\
@echo Packing Resources
call frapid.exe pack resource

cd %builddir%
call test-postgres-tenant.bat

@echo OK