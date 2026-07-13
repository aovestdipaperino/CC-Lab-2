namespace TextKit;

public static class Words
{
    public static IReadOnlyList<string> Tokenize(string text)
    {
        return text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
    }

    public static int CountUnique(string text)
    {
        var seen = new List<string>();
        foreach (var token in Tokenize(text))
        {
            if (!seen.Contains(token))
            {
                seen.Add(token);
            }
        }

        return seen.Count;
    }
}
