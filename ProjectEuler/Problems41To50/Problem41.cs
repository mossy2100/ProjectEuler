namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Pandigital prime.
/// <see href="https://projecteuler.net/problem=41" />
/// </summary>
public static class Problem41
{
    public static long Answer()
    {
        List<ulong> primes = Primes.GetPrimesUpTo(987654321);
        return (long)primes.LastOrDefault(Digits.IsPandigital);
    }
}
