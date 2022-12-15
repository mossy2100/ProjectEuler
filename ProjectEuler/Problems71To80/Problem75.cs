namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Singular integer right triangles.
/// <see href="https://projecteuler.net/problem=75" />
/// </summary>
public static class Problem75
{
    public static long Answer()
    {
        // Set the maximum perimeter.
        const ulong max = 1_500_000;

        // Keep track of how many solutions we find, grouped by perimeter.
        List<(ulong a, ulong b, ulong c)> triples = new ();

        // Also keep track of how many solutions we find for each length.
        int[] count = new int[max + 1];

        // Find all the Pythagorean primitives up to max length.

        // Try values for n.
        ulong n = 1;
        bool done = false;
        while (!done)
        {
            // Try values for m. We know m > n, and that one is odd, one is even.
            ulong m = n + 1;

            while (true)
            {
                // Check m and n are coprime.
                if (!Primes.AreCoprime(n, m))
                {
                    m += 2;
                    continue;
                }

                // Calculate a, b, c, and len.
                ulong mSqr = m * m;
                ulong nSqr = n * n;
                ulong a = mSqr - nSqr;
                ulong b = 2 * m * n;
                ulong c = mSqr + nSqr;
                ulong len = a + b + c;

                // If perimeter is too large, stop checking values for m.
                if (len > max)
                {
                    // If m is the minimum value for this n, and the length is too large,
                    // n is now too large, so exit the outer (n) loop.
                    if (m == n + 1)
                    {
                        done = true;
                    }
                    break;
                }

                // Check we haven't found it already.
                (ulong a, ulong b, ulong c) triple = (a, b, c);
                if (!triples.Contains(triple))
                {
                    // Found a primitive triple.
                    triples.Add(triple);
                    count[len]++;
                    // Console.WriteLine(triple);
                }

                // Next m.
                m += 2;
            }

            // Next n.
            n++;
        }

        // Now we have the primitives, count up the multiples.
        foreach ((ulong a, ulong b, ulong c) triple in triples)
        {
            ulong len = triple.a + triple.b + triple.c;
            for (ulong k = 2; k <= max / len; k++)
            {
                count[k * len]++;
            }
        }

        return count.Count(i => i == 1);
    }
}
