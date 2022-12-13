namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Counting fractions.
/// <see href="https://projecteuler.net/problem=72" />
/// </summary>
public static class Problem72
{
    public static long Answer()
    {
        long count = 0;
        ulong max = 1_000_000;
        for (ulong den = 2; den <= max; den++)
        {
            count += (long)Primes.Totient(den);

            // DEBUG
            if (den % 1000 == 0)
            {
                Console.WriteLine($"den = {den}, count = {count}");
            }
        }
        return count;
    }
}
