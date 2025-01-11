@echo off
setlocal enabledelayedexpansion

REM Event Annotator NuGet Package Server Deploy 
REM ------------------------------------------------
REM BUILDING, CREATING AND DEPLOYING NUGET PACKAGE

REM Set current directory to the script's directory
cd %~dp0

REM Navigate to the Event Annotator project directory if not already there
cd ..\EventAnnotator

ECHO Building project in Release mode...
dotnet build --configuration Release
if %errorlevel% neq 0 (
    ECHO Failed to build project.
    pause
    exit /b %errorlevel%
)

ECHO Creating NuGet package...
REM Create NuGet package
dotnet pack --configuration Release --output ..\Packages
if %errorlevel% neq 0 (
    ECHO Failed to create NuGet package.
    pause
    exit /b %errorlevel%
)

ECHO Finding latest NuGet package...
REM Initialize variable for latest package
set "LATEST_PACKAGE="

REM Loop through the NuGet package files to find the latest one
for /f "delims=" %%i in ('dir "..\Packages\EventAnnotator.*.nupkg" /b /od') do set LATEST_PACKAGE=%%i

REM Check if a package was found
if "%LATEST_PACKAGE%"=="" (
    ECHO No package found to deploy.
    pause
    exit /b
)

ECHO Deploying NuGet package...

REM Prompt for API key and URL
set /p API_KEY="Enter your NuGet API key: "
set /p NUGET_URL="Enter your NuGet server URL: "

REM Push the latest NuGet package to the server
dotnet nuget push "..\Packages\%LATEST_PACKAGE%" --api-key %API_KEY% --source %NUGET_URL% --interactive