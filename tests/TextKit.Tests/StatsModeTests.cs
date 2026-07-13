using TextKit;
using Xunit;

namespace TextKit.Tests;

[Trait("step", "2")]
public class StatsModeTests
{
    [Fact]
    public void Mode_returns_the_most_frequent_value()
    {
        Assert.Equal(4, Stats.Mode(new[] { 1, 4, 2, 4, 3, 4 }));
    }

    [Fact]
    public void Mode_breaks_ties_by_returning_the_smallest_value()
    {
        Assert.Equal(2, Stats.Mode(new[] { 5, 2, 5, 2, 1 }));
    }

    [Fact]
    public void Mode_throws_on_empty_input()
    {
        Assert.Throws<ArgumentException>(() => Stats.Mode(Array.Empty<int>()));
    }
}
