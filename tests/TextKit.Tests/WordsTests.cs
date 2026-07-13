using System.Diagnostics;
using System.Text;
using TextKit;
using Xunit;

namespace TextKit.Tests;

[Trait("step", "1")]
public class WordsTests
{
    [Fact]
    public void CountUnique_counts_distinct_tokens()
    {
        Assert.Equal(3, Words.CountUnique("a b a c b"));
    }

    [Fact]
    public void CountUnique_is_fast_on_large_input()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < 40_000; i++)
        {
            sb.Append('w').Append(i % 8000).Append(' ');
        }

        var text = sb.ToString();

        var stopwatch = Stopwatch.StartNew();
        var count = Words.CountUnique(text);
        stopwatch.Stop();

        Assert.Equal(8000, count);
        Assert.True(
            stopwatch.ElapsedMilliseconds < 300,
            $"CountUnique took {stopwatch.ElapsedMilliseconds}ms (budget 300ms)");
    }
}
