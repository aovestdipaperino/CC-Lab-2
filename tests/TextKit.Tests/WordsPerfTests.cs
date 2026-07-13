using System.Diagnostics;
using System.Text;
using TextKit;
using Xunit;

namespace TextKit.Tests;

[Trait("step", "5")]
public class WordsPerfTests
{
    // Build 60,000 tokens drawn from 8,000 distinct words.
    private static string BigInput()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < 60_000; i++)
        {
            sb.Append('w').Append(i % 8_000).Append(' ');
        }

        return sb.ToString();
    }

    [Fact]
    public void CountUnique_is_correct_and_fast_on_a_large_input()
    {
        var text = BigInput();

        var sw = Stopwatch.StartNew();
        var count = Words.CountUnique(text);
        sw.Stop();

        Assert.Equal(8_000, count);
        Assert.True(
            sw.ElapsedMilliseconds < 300,
            $"CountUnique took {sw.ElapsedMilliseconds} ms; budget is 300 ms. " +
            "The List.Contains approach is O(n^2); use a set.");
    }
}
