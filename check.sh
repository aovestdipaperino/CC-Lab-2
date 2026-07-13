#!/usr/bin/env bash
# The verification gate. Runs fmt and build, then each lab STEP in order
# (selected by the xUnit "step" trait), stopping at the first step that fails.
# The gate passes only when every step is green.
set -uo pipefail
cd "$(dirname "$0")"

echo "== fmt (whitespace) =="
dotnet format whitespace --verify-no-changes
if [ $? -ne 0 ]; then
  echo "CHECK FAILED (fmt)"
  exit 1
fi

echo "== build (Release) =="
dotnet build -c Release
if [ $? -ne 0 ]; then
  echo "CHECK FAILED (build)"
  exit 1
fi

titles=(
  ""
  "Fix the bugs (Roman subtractive, Slug, Median, Mean) + formatting"
  "Stats.Mode - most frequent value, ties to the smallest"
  "Words.TopN - n most frequent tokens, ties alphabetical"
  "Roman.IsValid - accept only canonical numerals"
  "Performance - CountUnique on a large input under budget"
)

for step in 1 2 3 4 5; do
  echo "== STEP $step/5: ${titles[$step]} =="
  dotnet test -c Release --no-build --filter "step=$step"
  if [ $? -ne 0 ]; then
    echo "CHECK FAILED (step $step)"
    exit 1
  fi
  echo "  STEP $step PASSED"
done

echo "CHECK PASSED"
exit 0
