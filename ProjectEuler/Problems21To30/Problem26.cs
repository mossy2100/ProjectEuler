using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Reciprocal cycles.
/// <see href="https://projecteuler.net/problem=26" />
/// </summary>
public static class Problem26
{
    public static void Test()
    {
        for (var i = 2; i < 100; i++)
        {
            var j = NumberStrings.Inverse(i, out var reptend);
            Console.WriteLine($"1/{i} = {1m / i} = {j}");
            if (reptend != null)
            {
                Console.WriteLine($"Reptend length = {reptend.Length}");
            }
        }
    }

    public static long Answer()
    {
        var result = 0;
        var maxReptendLength = 0;
        for (var d = 2; d < 1000; d++)
        {
            NumberStrings.Inverse(d, out var reptend);
            if (reptend == null)
            {
                continue;
            }
            var reptendLen = reptend.Length;
            if (reptendLen > maxReptendLength)
            {
                maxReptendLength = reptendLen;
                result = d;
            }
        }
        return result;
    }
}
