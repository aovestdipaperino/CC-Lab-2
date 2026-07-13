# TextKit — project guide for Claude Code

A small text-utilities library: Roman numerals, slugs, simple statistics, word counting.
.NET 8, no third-party runtime dependencies.

## Commands
- Build:  `dotnet build`
- Test:   `dotnet test`
- Gate:   `.\check.ps1` (Windows) or `./check.sh` (macOS/Linux). This is the definition of done.

## The gate is staged

The gate runs `dotnet format` and a Release build, then five **steps** in order
(selected by the xUnit `step` trait), stopping at the first step that fails. Just
keep making the next step pass:

1. **Fix the bugs.** The existing suite is red: `Roman` lacks subtractive forms,
   `Slug.Ify` keeps punctuation and doesn't collapse separators, `Stats.Median`
   mishandles even counts, `Stats.Mean` uses integer division — and `Slug.cs` is
   mis-formatted so `dotnet format` fails. Make step-1 tests green.
2. **`Stats.Mode`** — most frequent value; ties resolve to the smallest; throw on empty.
3. **`Words.TopN(text, n)`** — the n most frequent tokens, most frequent first,
   ties broken alphabetically.
4. **`Roman.IsValid(string)`** — true only for canonical numerals in 1..3999
   (reject `IIII`, `VV`, `IC`, invalid characters).
5. **Performance** — `Words.CountUnique` must handle a large input within a time
   budget. The `List.Contains` approach is O(n²); use a set.

Methods for steps 2–4 ship as stubs that throw `NotImplementedException` — the
test project compiles, but those tests fail until you implement them.

## Layout
- `src/TextKit/` — the library: `Roman.cs`, `Slug.cs`, `Stats.cs`, `Words.cs`
- `tests/TextKit.Tests/` — xUnit tests; each class is tagged `[Trait("step", "N")]`

## Conventions
- The tests are the specification. A behaviour is correct when its test passes.
- 4-space indentation; files end with a final newline (see `.editorconfig`).
- You are not expected to finish all five steps — get as far as you can.
