namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Reciprocal cycles.
/// <see href="https://projecteuler.net/problem=26" />
/// </summary>
public static class Problem26
{
    public static void Test()
    {
        for (int i = 2; i < 100; i++)
        {
            string j = NumberStrings.Inverse(i, out string? reptend);
            Console.WriteLine($"1/{i} = {1m / i} = {j}");
            if (reptend != null)
            {
                Console.WriteLine($"Reptend length = {reptend.Length}");
            }
        }
    }

    public static long Answer()
    {
        int result = 0;
        int maxReptendLength = 0;
        for (int d = 2; d < 1000; d++)
        {
            NumberStrings.Inverse(d, out string? reptend);
            if (reptend == null)
            {
                continue;
            }
            int reptendLen = reptend.Length;
            if (reptendLen > maxReptendLength)
            {
                maxReptendLength = reptendLen;
                result = d;
            }
        }
        return result;
    }
}
