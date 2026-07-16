#!/usr/bin/env pwsh
# Restore the repo to its starting (broken) state. PowerShell equivalent of reset.sh.
$ErrorActionPreference = 'Continue'
Set-Location -Path $PSScriptRoot

git checkout -- . 2>$null
git clean -fdx --exclude=.git 2>$null

Write-Host "Reset to starting state. If a /goal is still active in your Claude Code session, run: /goal clear"
