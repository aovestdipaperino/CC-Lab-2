#!/usr/bin/env pwsh
# The verification gate. Runs lint, build, and tests in order.
# Exits non-zero if any step fails. PowerShell equivalent of check.sh.
$ErrorActionPreference = 'Continue'
Set-Location -Path $PSScriptRoot

Write-Host "== 1/3 format (whitespace) =="
dotnet format whitespace --verify-no-changes
if ($LASTEXITCODE -ne 0) {
    Write-Host "CHECK FAILED (format)"
    exit $LASTEXITCODE
}

Write-Host "== 2/3 build (Release) =="
dotnet build -c Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "CHECK FAILED (build)"
    exit $LASTEXITCODE
}

Write-Host "== 3/3 test (Release) =="
dotnet test -c Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "CHECK FAILED (test)"
    exit $LASTEXITCODE
}

Write-Host "CHECK PASSED"
exit 0
