using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Quadratic primes.
/// <see href="https://projecteuler.net/problem=27" />
/// </summary>
public static class Problem27
{
    public static long Answer()
    {
        // Keep track of how many consecutive primes we find for each combination of a and b.
        var maxCount = 0;
        var maxA = 0;
        var maxB = 0;

        // Loop through all combinations of a and b.
        for (var a = -999; a <= 999; a++)
        {
            for (var b = -1000; b <= 1000; b++)
            {
                var count = 0;
                var n = 0;

                while (true)
                {
                    long q = n * n + a * n + b;
                    if (q >= 0 && Primes.IsPrime((ulong)q))
                    {
                        count++;
                        n++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxA = a;
                    maxB = b;
                }
            } // b
        } // a

        return maxA * maxB;
    }
}
