using AstroMultimedia.Core.Collections;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Smallest multiple.
/// <see href="https://projecteuler.net/problem=5" />
/// </summary>
public static class Problem5
{
    public static long Answer()
    {
        List<ulong> factors = new();
        for (ulong i = 2; i <= 20; i++)
        {
            List<ulong> factors2 = Primes.PrimeFactors(i);
            IEnumerable<ulong> newFactors = factors2.Diff(factors);
            factors.AddRange(newFactors);
        }
        return (long)factors.Aggregate(1UL, (product, factor) => product * factor);
    }
}
