using AstroMultimedia.Core.Time;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=58" />
/// </summary>
public static class Problem58
{
    public static long Answer()
    {
        long t1 = DateTime.Now.Ticks;

        // Repeatedly add layers until result found.
        int size = 1;
        int nNumbersOnDiagonals = 1;
        int nPrimes = 0;
        ulong n = 1;
        uint diff = 0;
        while (true)
        {
            // Go to next size.
            size += 2;
            diff += 2;

            // Check the values at each of the next 3 corners.
            for (int i = 0; i < 3; i++)
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

        long t2 = DateTime.Now.Ticks;
        long t = (long)((t2 - t1) / Time.TICKS_PER_MILLISECOND);
        Console.WriteLine($"Total execution time = {t} ms.");

        return size;
    }
}
