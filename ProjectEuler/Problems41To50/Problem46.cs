using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
///     <see href="https://projecteuler.net/problem="/>
/// </summary>
public static class Problem46
{
    public static long Answer()
    {
        // Start at the first odd composite number.
        ulong a = 9;

        // Look for a = b + 2c^2 where a is odd and composite, and b is prime.
        while (true)
        {
            if (!Primes.IsPrime(a))
            {
                // The largest possible value for c will be √((a - 2) / 2), because the smallest
                // prime (and thus the smallest value for b) is 2.
                var foundValuesThatWork = false;
                for (ulong c = 1; c <= Sqrt((a - 2) / 2.0); c++)
                {
                    ulong b = a - 2 * c * c;
                    if (Primes.IsPrime(b))
                    {
                        foundValuesThatWork = true;
                        Console.WriteLine($"{a} = {b} + 2 * {c}^2");
                        break;
                    }
                }
                if (!foundValuesThatWork)
                {
                    return (long)a;
                }
            }

            // Go to next odd number.
            a += 2;
        }
    }
}
