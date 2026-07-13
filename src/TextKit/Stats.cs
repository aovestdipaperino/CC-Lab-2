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
}
