@echo off

set MIGRATION_NAME=%1

if "%MIGRATION_NAME%"=="" (
  echo Migration name is required
  echo Usage: add-migration.cmd FirstMigration
  exit /b 1
)

echo Running Migration: %MIGRATION_NAME%

dotnet ef migrations add "%MIGRATION_NAME%" ^
  --project "TaskManagement.Infrastructure" ^
  --context "TaskManagementDbContext"

