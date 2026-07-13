#!/usr/bin/env bash
# Restore the repo to its starting (broken) state.
set -uo pipefail
cd "$(dirname "$0")"
git checkout -- . 2>/dev/null || true
git clean -fdx --exclude=.git 2>/dev/null || true
rm -f .claude/settings.json
rm -f "${TMPDIR:-/tmp}/textkit-verify-stop.count" "${TMPDIR:-/tmp}/textkit-verify-stop.log"
echo "Reset to starting state."
