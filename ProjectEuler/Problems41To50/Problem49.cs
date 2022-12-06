namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=" />
/// </summary>
public static class Problem49
{
    public static long Answer()
    {
        // We know the terms have 4 digits.
        for (int n = 1000; n <= 9999; n++)
        {
            List<string> permutations = Factorials.CharPermutations(n.ToString());

            // Extract the 4-digit primes.
            List<ulong> primes = permutations.Select(ulong.Parse)
                .Where(p => p >= 1000 && Primes.IsPrime(p)).ToList();

            // This value will match, so skip it. We want the other solution.
            if (primes.Contains(1487))
            {
                continue;
            }

            // We need at least 3 primes.
            int nPrimes = primes.Count;
            if (nPrimes < 3)
            {
                continue;
            }

            // Sort them to ensure we have an increasing sequence.
            primes.Sort();

            // Convert to an array so we can use the indices.
            ulong[] aPrimes = primes.ToArray();

            // Look for a sequence of 3 with equal difference between them.
            for (int i = 0; i <= nPrimes - 3; i++)
            {
                ulong pi = aPrimes[i];
                for (int j = i + 1; j <= nPrimes - 2; j++)
                {
                    ulong pj = aPrimes[j];
                    for (int k = j + 1; k <= nPrimes - 1; k++)
                    {
                        ulong pk = aPrimes[k];
                        if (pj - pi == pk - pj)
                        {
                            // Found it.
                            return (long)(pi * 100000000 + pj * 10000 + pk);
                        }
                    }
                }
            }
        }

        return 0;
    }
}
