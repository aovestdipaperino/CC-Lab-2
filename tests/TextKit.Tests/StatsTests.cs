using TextKit;
using Xunit;

namespace TextKit.Tests;

public class StatsTests
{
    [Fact]
    public void Median_of_odd_count_is_middle_value()
    {
        Assert.Equal(2.0, Stats.Median(new double[] { 3, 1, 2 }));
    }

    [Fact]
    public void Median_of_even_count_averages_the_two_middle_values()
    {
        Assert.Equal(2.5, Stats.Median(new double[] { 1, 2, 3, 4 }));
    }

    [Fact]
    public void Mean_is_a_true_average_not_integer_division()
    {
        Assert.Equal(3.333, Stats.Mean(new[] { 1, 2, 7 }), 3);
    }
}
