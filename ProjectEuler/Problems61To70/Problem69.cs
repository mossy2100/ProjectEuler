namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Totient maximum.
/// <see href="https://projecteuler.net/problem=69" />
/// </summary>
public static class Problem69
{
    public static long Answer()
    {
        double max = 0;
        ulong mumWithMax = 0;

        for (ulong n = 2; n <= 1_000_000; n++)
        {
            ulong totient = Primes.Totient(n);
            double nOnPhi = (double)n / totient;
            Console.WriteLine($"Totient({n}) = {totient} => n/phi(n) = {nOnPhi:G5}");

            if (nOnPhi > max)
            {
                max = nOnPhi;
                mumWithMax = n;
            }
        }

        return (long)mumWithMax;
    }
}
