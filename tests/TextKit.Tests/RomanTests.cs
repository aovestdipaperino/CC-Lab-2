using TextKit;
using Xunit;

namespace TextKit.Tests;

public class RomanTests
{
    [Theory]
    [InlineData(3, "III")]
    [InlineData(10, "X")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(1994, "MCMXCIV")]
    public void ToRoman_produces_canonical_numerals(int number, string expected)
    {
        Assert.Equal(expected, Roman.ToRoman(number));
    }

    [Theory]
    [InlineData("XVI", 16)]
    [InlineData("IV", 4)]
    public void FromRoman_parses_subtractive_forms(string roman, int expected)
    {
        Assert.Equal(expected, Roman.FromRoman(roman));
    }
}
