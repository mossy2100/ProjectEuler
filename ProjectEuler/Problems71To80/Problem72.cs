namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Counting fractions.
/// <see href="https://projecteuler.net/problem=72" />
/// </summary>
public static class Problem72
{
    public static long Answer()
    {
        ulong count = 1;
        Console.WriteLine("1/2");
        for (ulong den = 2; den <= 1_000_000; den++)
        {
            for (ulong num = 1; num < (den / 2.0); num++)
            {
                if (Primes.AreCoprime(num, den))
                {
                    count += 2;
                    Console.WriteLine($"{num}/{den} and {den - num}/{den}");
                }
            }
        }
        return (long)count;
    }
}
