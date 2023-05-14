using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Prime summations.
/// <see href="https://projecteuler.net/problem=77" />
/// </summary>
public static class Problem77
{
    /// <summary>
    /// Count the number of ways a number n can be written as a sum of primes.
    /// The first value in the sequence cannot be greater than max.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int CountWays(int n, int? max = null)
    {
        // Default max first number.
        if (max is null)
        {
            max = n;
        }

        var count = 0;

        // Get primes up to the smaller of n and max.
        var primes = Primes.GetPrimesUpTo((ulong)Min(n, (int)max));

        // Let a be the first in the series of primes that form the sum.
        // It cannot be greater than max.
        for (var i = primes.Count - 1; i >= 0; i--)
        {
            var a = (int)primes[i];
            if (a == n)
            {
                count++;
            }
            else
            {
                count += CountWays(n - a, a);
            }
        }

        return count;
    }

    public static long Answer()
    {
        var n = 10;
        while (true)
        {
            if (CountWays(n) >= 5000)
            {
                return n;
            }
            n++;
        }
    }
}
