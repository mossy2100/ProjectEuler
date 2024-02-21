namespace Galaxon.ProjectEuler;

/// <summary>
/// Passcode derivation.
/// <see href="https://projecteuler.net/problem=79"/>
/// </summary>
public static class Problem79
{
    private static readonly Dictionary<byte, HashSet<byte>> s_after = new ();

    private static void EnsureSetExists(byte digit)
    {
        if (!s_after.ContainsKey(digit))
        {
            s_after[digit] = new HashSet<byte>();
        }
    }

    public static long Answer()
    {
        // Get the codes.
        string path = Utility.GetDataFilePath("p079_keylog.txt");
        string[] codes = File.ReadAllLines(path);

        // Take note of what digits come after what digits.
        foreach (string code in codes)
        {
            // Get the code digits.
            var digit0 = (byte)(code[0] - '0');
            var digit1 = (byte)(code[1] - '0');
            var digit2 = (byte)(code[2] - '0');

            // Ensure each digit we find is in the dictionary.
            EnsureSetExists(digit0);
            EnsureSetExists(digit1);
            EnsureSetExists(digit2);

            // Note which ones come after which.
            s_after[digit0].Add(digit1);
            s_after[digit0].Add(digit2);
            s_after[digit1].Add(digit2);
        }

        // Order the digits in decreasing order of how many digits come after them.
        // Convert into a number.
        return s_after
            .OrderByDescending(kvp => kvp.Value.Count)
            .Select(kvp => kvp.Key)
            .Aggregate(0L, (total, digit) => total * 10 + digit);
    }
}
