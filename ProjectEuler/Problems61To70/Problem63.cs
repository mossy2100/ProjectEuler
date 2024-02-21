using System.Numerics;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Powerful digit counts.
/// <see href="https://projecteuler.net/problem=63"/>
/// </summary>
public static class Problem63
{
    public static long Answer()
    {
        var count = 0;
        List<(int, int, BigInteger)> hits = new ();

        var n = 1;
        while (true)
        {
            var min = (BigInteger)Pow(10, n - 1);
            BigInteger max = min * 10 - 1;

            // Get starting value.
            var b = (int)Ceiling(Pow((double)min, 1.0 / n));

            // How many hits with this many digits?
            var countWithNDigits = 0;

            while (true)
            {
                var p = (BigInteger)Pow(b, n);

                // Check if we now have too many digits.
                if (p > max)
                {
                    break;
                }

                // Keep count.
                hits.Add((b, n, p));
                count++;
                countWithNDigits++;

                // Next base.
                b++;
            }

            // See if we're done.
            if (countWithNDigits == 0)
            {
                break;
            }

            n++;
        }

        return count;
    }
}
