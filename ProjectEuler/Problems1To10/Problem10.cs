namespace Galaxon.ProjectEuler;

/// <summary>
/// Summation of primes.
/// <see href="https://projecteuler.net/problem=10" />
/// </summary>
public static class Problem10
{
    public static long Answer() =>
        (long)Primes.GetPrimesUpTo(2_000_000)
            .Aggregate(0UL, (sum, item) => sum + item);
}
