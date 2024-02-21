using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Totient maximum.
/// <see href="https://projecteuler.net/problem=69"/>
/// </summary>
public static class Problem69
{
    public static long Answer()
    {
        double max = 0;
        ulong numWithMax = 0;

        for (ulong n = 2; n <= 1_000_000; n++)
        {
            ulong phi = Primes.Totient(n);
            double nOnPhi = (double)n / phi;
            Console.WriteLine($"Totient({n}) = {phi} => n/phi(n) = {nOnPhi:G5}");

            if (nOnPhi > max)
            {
                max = nOnPhi;
                numWithMax = n;
            }
        }

        return (long)numWithMax;
    }
}
