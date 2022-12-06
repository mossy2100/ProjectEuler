namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Largest prime factor.
/// <see href="https://projecteuler.net/problem=3" />
/// </summary>
public static class Problem3
{
    public static void Test()
    {
        for (ulong i = 1; i <= 100; i++)
        {
            string factors = $"[{string.Join(", ", Primes.GetPrimeFactors(i))}]";
            Console.WriteLine($"The prime factors of {i} are {factors}.");
            if (Primes.IsPrime(i))
            {
                Console.WriteLine($" ===> {i} is PRIME!");
            }
        }
    }

    public static long Answer() => (long)Primes.GetPrimeFactors(600851475143).Last();
}