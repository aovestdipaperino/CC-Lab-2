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

    // STEP 3 — implement this.
    // Return the n most frequent tokens, most frequent first. Break ties
    // alphabetically (ascending). If n is greater than the number of distinct
    // tokens, return all of them. n <= 0 returns an empty list.
    public static IReadOnlyList<string> TopN(string text, int n)
    {
        throw new NotImplementedException("Words.TopN is not implemented yet (step 3).");
    }
}
