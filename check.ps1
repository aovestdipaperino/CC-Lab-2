#!/usr/bin/env pwsh
# The verification gate. Runs fmt and build, then each lab STEP in order
# (selected by the xUnit "step" trait), stopping at the first step that fails.
# PowerShell equivalent of check.sh.
$ErrorActionPreference = 'Continue'
Set-Location -Path $PSScriptRoot

Write-Host "== fmt (whitespace) =="
dotnet format whitespace --verify-no-changes
if ($LASTEXITCODE -ne 0) {
    Write-Host "CHECK FAILED (fmt)"
    exit 1
}

Write-Host "== build (Release) =="
dotnet build -c Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "CHECK FAILED (build)"
    exit 1
}

$titles = @(
    'Fix the bugs (Roman subtractive, Slug, Median, Mean) + formatting',
    'Stats.Mode - most frequent value, ties to the smallest',
    'Words.TopN - n most frequent tokens, ties alphabetical',
    'Roman.IsValid - accept only canonical numerals',
    'Performance - CountUnique on a large input under budget'
)

for ($step = 1; $step -le 5; $step++) {
    Write-Host ("== STEP {0}/5: {1} ==" -f $step, $titles[$step - 1])
    dotnet test -c Release --no-build --filter "step=$step"
    if ($LASTEXITCODE -ne 0) {
        Write-Host ("CHECK FAILED (step {0})" -f $step)
        exit 1
    }
    Write-Host ("  STEP {0} PASSED" -f $step)
}

Write-Host "CHECK PASSED"
exit 0
