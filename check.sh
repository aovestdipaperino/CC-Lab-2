#!/usr/bin/env bash
# The verification gate. Runs lint, build, and tests in order.
# Exits non-zero if any step fails.
set -uo pipefail
cd "$(dirname "$0")"

echo "== 1/3 format (whitespace) =="
dotnet format whitespace --verify-no-changes
fmt=$?

if [ $fmt -ne 0 ]; then
  echo "CHECK FAILED (format)"
  exit $fmt
fi

echo "== 2/3 build (Release) =="
dotnet build -c Release
build=$?

if [ $build -ne 0 ]; then
  echo "CHECK FAILED (build)"
  exit $build
fi

echo "== 3/3 test (Release) =="
dotnet test -c Release
test=$?

if [ $test -ne 0 ]; then
  echo "CHECK FAILED (test)"
  exit $test
fi

echo "CHECK PASSED"
exit 0
