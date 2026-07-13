using TextKit;
using Xunit;

namespace TextKit.Tests;

[Trait("step", "3")]
public class WordsTopNTests
{
    [Fact]
    public void TopN_returns_most_frequent_first()
    {
        var top = Words.TopN("a b a c a b", 2);
        Assert.Equal(new[] { "a", "b" }, top);
    }

    [Fact]
    public void TopN_breaks_ties_alphabetically()
    {
        // "b", "c", "a" all appear once; alphabetical order wins.
        var top = Words.TopN("c b a", 2);
        Assert.Equal(new[] { "a", "b" }, top);
    }

    [Fact]
    public void TopN_clamps_to_the_number_of_distinct_tokens()
    {
        var top = Words.TopN("x y x", 10);
        Assert.Equal(new[] { "x", "y" }, top);
    }

    [Fact]
    public void TopN_of_zero_or_less_is_empty()
    {
        Assert.Empty(Words.TopN("a b c", 0));
    }
}
