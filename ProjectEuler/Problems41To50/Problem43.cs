using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Sub-string divisibility.
/// <see href="https://projecteuler.net/problem=43" />
/// </summary>
public static class Problem43
{
    public static long Answer()
    {
        // Get all possible permutations.
        var permutations = Factorials.CharPermutations("0123456789");

        // Get the first 7 primes.
        int[] primes = { 2, 3, 5, 7, 11, 13, 17 };

        long total = 0;

        // Test each one.
        foreach (var perm in permutations)
        {
            var match = true;
            for (var i = 0; i < 7; i++)
            {
                var num = int.Parse(perm[(i + 1)..(i + 4)]);
                if (num % primes[i] != 0)
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                Console.WriteLine($"{perm} has the desired property.");
                total += long.Parse(perm);
            }
        }

        return total;
    }
}
