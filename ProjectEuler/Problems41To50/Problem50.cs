using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Consecutive prime sum.
/// <see href="https://projecteuler.net/problem=50" />
/// </summary>
public static class Problem50
{
    public static long Answer()
    {
        // Find all the primes we need for this problem.
        uint max = 1_000_000;
        List<ulong> primes = Primes.GetPrimesUpTo(max);

        // Keep track of the best solution.
        uint maxNTerms = 1;
        ulong result = 0;

        // Consider each prime as a starting point for a sequence.
        for (int i = 0; i < primes.Count; i++)
        {
            ulong sum = 0;
            uint nTerms = 0;
            for (int j = i; j < primes.Count; j++)
            {
                sum += primes[j];
                nTerms++;

                // Stop adding if the sum is >= max.
                if (sum >= max)
                {
                    break;
                }

                // If the sum is prime, we've found a solution.
                if (nTerms > maxNTerms && Primes.IsPrime(sum))
                {
                    maxNTerms = nTerms;
                    result = sum;
                }
            }
        }

        return (long)result;
    }
}
