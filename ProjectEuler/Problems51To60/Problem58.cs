using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Spiral primes.
/// <see href="https://projecteuler.net/problem=58" />
/// </summary>
public static class Problem58
{
    public static long Answer()
    {
        var t1 = DateTime.Now.Ticks;

        // Repeatedly add layers until result found.
        var size = 1;
        var nNumbersOnDiagonals = 1;
        var nPrimes = 0;
        ulong n = 1;
        uint diff = 0;
        while (true)
        {
            // Go to next size.
            size += 2;
            diff += 2;

            // Check the values at each of the next 3 corners.
            for (var i = 0; i < 3; i++)
            {
                n += diff;
                if (Primes.IsPrime(n))
                {
                    nPrimes++;
                }
            }

            // Move to lower-right corner. No need to check for a prime there, because all the
            // lower-right corner vales are squares.
            n += diff;

            // Calculate what percentage of the numbers on the diagonals are prime.
            nNumbersOnDiagonals += 4;
            if (nPrimes * 10 < nNumbersOnDiagonals)
            {
                break;
            }
        }

        var t2 = DateTime.Now.Ticks;
        var t = (t2 - t1) / TimeSpan.TicksPerMillisecond;
        Console.WriteLine($"Total execution time = {t} ms.");

        return size;
    }
}
