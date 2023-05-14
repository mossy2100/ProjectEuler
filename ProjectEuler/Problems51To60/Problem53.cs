using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Combinatoric selections.
/// <see href="https://projecteuler.net/problem=53" />
/// </summary>
public static class Problem53
{
    public static long Answer()
    {
        var count = 0;
        for (var n = 1; n <= 100; n++)
        {
            for (var r = 1; r < n; r++)
            {
                var c = Factorials.NumCombinations(n, r);
                if (c > 1000000)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
