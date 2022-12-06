namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Distinct primes factors.
/// <see href="https://projecteuler.net/problem=47" />
/// </summary>
public static class Problem47
{
    public static long Answer()
    {
        // Start from just after the first three consecutive numbers to have three distinct prime
        // factors (644, 645, and 646).
        ulong n = 647;

        while (true)
        {
            bool match = true;

            for (byte i = 0; i < 4; i++)
            {
                int p = Primes.NumDistinctPrimeFactors(n + i);
                if (p != 4)
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                return (long)n;
            }

            n++;
        }
    }
}
