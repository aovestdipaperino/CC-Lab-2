using TextKit;
using Xunit;

namespace TextKit.Tests;

public class SlugTests
{
    [Fact]
    public void Ify_lowercases_and_hyphenates_words()
    {
        Assert.Equal("two-words", Slug.Ify("Two Words"));
    }

    [Fact]
    public void Ify_strips_punctuation()
    {
        Assert.Equal("hello-world", Slug.Ify("Hello, World!"));
    }

    [Fact]
    public void Ify_collapses_repeated_separators()
    {
        Assert.Equal("multiple-spaces", Slug.Ify("Multiple   Spaces"));
    }
}
