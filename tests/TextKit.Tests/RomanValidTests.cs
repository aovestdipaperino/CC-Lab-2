using TextKit;
using Xunit;

namespace TextKit.Tests;

[Trait("step", "4")]
public class RomanValidTests
{
    [Theory]
    [InlineData("III")]
    [InlineData("IV")]
    [InlineData("IX")]
    [InlineData("XL")]
    [InlineData("MCMXCIV")]
    [InlineData("MMMCMXCIX")]
    public void IsValid_accepts_canonical_numerals(string roman)
    {
        Assert.True(Roman.IsValid(roman));
    }

    [Theory]
    [InlineData("IIII")]  // should be IV
    [InlineData("VV")]    // should be X
    [InlineData("IC")]    // not a legal subtractive pair
    [InlineData("XM")]    // not a legal subtractive pair
    [InlineData("ABC")]   // invalid characters
    [InlineData("")]      // empty
    public void IsValid_rejects_noncanonical_or_invalid(string roman)
    {
        Assert.False(Roman.IsValid(roman));
    }

    [Fact]
    public void IsValid_agrees_with_ToRoman_over_the_whole_range()
    {
        for (var n = 1; n <= 3999; n++)
        {
            Assert.True(Roman.IsValid(Roman.ToRoman(n)), $"ToRoman({n}) should be valid");
        }
    }
}
