# TextKit — project guide for Claude Code

A small text-utilities library: Roman numerals, slugs, simple statistics, word counting.
.NET 8, no third-party runtime dependencies.

## Commands
- Build:  `dotnet build`
- Test:   `dotnet test`
- Gate:   `.\check.ps1` (Windows) or `./check.sh` (macOS/Linux) — runs format, build, and tests
  in order. Both scripts run the identical three steps. This is the definition of done.

## Layout
- `src/TextKit/` — the library
  - `Roman.cs` — `ToRoman(int)` / `FromRoman(string)`
  - `Slug.cs` — `Ify(string)` turns a title into a URL slug
  - `Stats.cs` — `Median(...)` / `Mean(...)`
  - `Words.cs` — `Tokenize(string)` / `CountUnique(string)`
- `tests/TextKit.Tests/` — xUnit tests, one file per source file

## Conventions
- The tests are the specification. A behaviour is correct when its test passes.
- The gate (`check.ps1` / `check.sh`) is: whitespace formatting, a Release build, then the
  full test suite. All three must pass.
- 4-space indentation; files end with a final newline (see `.editorconfig`).
