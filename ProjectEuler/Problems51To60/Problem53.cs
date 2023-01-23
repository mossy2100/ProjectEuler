using System.Numerics;
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
        int count = 0;
        for (int n = 1; n <= 100; n++)
        {
            for (int r = 1; r < n; r++)
            {
                BigInteger c = Factorials.NumCombinations(n, r);
                if (c > 1000000)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
