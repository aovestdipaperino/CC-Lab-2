namespace TextKit;

public static class Stats
{
    public static double Median(IEnumerable<double> values)
    {
        var sorted = values.OrderBy(v => v).ToList();
        if (sorted.Count == 0)
        {
            throw new ArgumentException("values must not be empty", nameof(values));
        }

        var mid = sorted.Count / 2;
        return sorted[mid];
    }

    public static double Mean(IReadOnlyList<int> values)
    {
        if (values.Count == 0)
        {
            throw new ArgumentException("values must not be empty", nameof(values));
        }

        var sum = 0;
        foreach (var v in values)
        {
            sum += v;
        }

        return sum / values.Count;
    }

    // STEP 2 — implement this.
    // Return the value that appears most often. If several values tie for the
    // most occurrences, return the smallest of them. Throw on an empty input.
    public static int Mode(IReadOnlyList<int> values)
    {
        throw new NotImplementedException("Stats.Mode is not implemented yet (step 2).");
    }
}
