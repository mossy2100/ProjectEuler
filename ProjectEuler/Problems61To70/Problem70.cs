using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Totient permutation.
/// <see href="https://projecteuler.net/problem=70"/>
/// </summary>
public static class Problem70
{
    public static long Answer()
    {
        double min = double.MaxValue;
        ulong numWithMin = 0;

        for (ulong n = 2; n < 10_000_000; n++)
        {
            ulong phi = Primes.Totient(n);
            // Console.WriteLine($"φ({n}) = {phi}");

            if (Combinatorial.IsPermutationOf(n, phi))
            {
                Console.WriteLine($"n={n} is a permutation of φ(n)={phi}");
                double nOnPhi = (double)n / phi;
                if (nOnPhi < min)
                {
                    min = nOnPhi;
                    numWithMin = n;
                }
            }
        }

        return (long)numWithMin;
    }
}
