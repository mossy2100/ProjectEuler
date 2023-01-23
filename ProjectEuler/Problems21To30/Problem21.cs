using Galaxon.Core.Numbers;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Amicable numbers.
/// <see href="https://projecteuler.net/problem=21" />
/// </summary>
public static class Problem21
{
    private static long D(long n) =>
        (long)Divisors.GetProperDivisors(n).Sum();

    public static long Answer()
    {
        // Use a HashSet to avoid duplicates.
        List<long> amicable = new();

        // Check them all.
        for (long a = 2; a < 10000; a++)
        {
            // If it's already in the set then skip it.
            if (amicable.Contains(a))
            {
                continue;
            }

            // Find b.
            long b = D(a);

            // See if a and b are an amicable pair.
            if (a != b && D(b) == a)
            {
                amicable.Add(a);
                amicable.Add(b);
            }
        }

        return amicable.Sum();
    }
}
