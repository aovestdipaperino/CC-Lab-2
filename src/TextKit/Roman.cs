using System.Text;

namespace TextKit;

public static class Roman
{
    // Value/symbol map. Note: no subtractive entries (900/400/90/40/9/4).
    private static readonly (int Value, string Symbol)[] Map =
    {
        (1000, "M"),
        (500, "D"),
        (100, "C"),
        (50, "L"),
        (10, "X"),
        (5, "V"),
        (1, "I"),
    };

    public static string ToRoman(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "number must be positive");
        }

        var sb = new StringBuilder();
        var remaining = number;
        foreach (var (value, symbol) in Map)
        {
            while (remaining >= value)
            {
                sb.Append(symbol);
                remaining -= value;
            }
        }

        return sb.ToString();
    }

    public static int FromRoman(string roman)
    {
        if (string.IsNullOrEmpty(roman))
        {
            throw new ArgumentException("roman must not be empty", nameof(roman));
        }

        var total = 0;
        foreach (var c in roman.ToUpperInvariant())
        {
            total += ValueOf(c);
        }

        return total;
    }

    // STEP 4 — implement this.
    // Return true if the string is a *canonical* Roman numeral in the range
    // 1..3999 (the value that ToRoman would produce), and false otherwise.
    // Reject non-canonical forms like "IIII", "VV", "IC", and invalid characters.
    public static bool IsValid(string roman)
    {
        throw new NotImplementedException("Roman.IsValid is not implemented yet (step 4).");
    }

    private static int ValueOf(char c) => c switch
    {
        'M' => 1000,
        'D' => 500,
        'C' => 100,
        'L' => 50,
        'X' => 10,
        'V' => 5,
        'I' => 1,
        _ => throw new ArgumentException($"invalid Roman numeral character: {c}"),
    };
}
