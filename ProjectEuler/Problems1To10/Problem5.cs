using Galaxon.Core.Collections;
using Galaxon.Numerics.Extensions;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Smallest multiple.
/// <see href="https://projecteuler.net/problem=5"/>
/// </summary>
public static class Problem5
{
    public static long Answer()
    {
        List<ulong> factors = new ();
        for (ulong i = 2; i <= 20; i++)
        {
            List<ulong> factors2 = Primes.PrimeFactors(i);

            Console.WriteLine($"The prime factors if {i} are {string.Join(',', factors2)}");

            List<ulong> newFactors = factors2.Diff(factors);

            if (newFactors.Any())
            {
                Console.WriteLine($"The new prime factors are {string.Join(',', newFactors)}");
                factors.AddRange(newFactors);
            }
        }
        return (long)factors.Product();
    }
}
