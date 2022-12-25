namespace Galaxon.ProjectEuler;

/// <summary>
/// Circular primes.
/// <see href="https://projecteuler.net/problem=35" />
/// </summary>
public static class Problem35
{
    public static int Answer()
    {
        // Get all primes below 1 million.
        List<ulong> primes = Primes.GetPrimesUpTo(1_000_000);

        // There should be 78498 primes in this list.
        if (primes.Count() != 78498)
        {
            throw new ArithmeticException("Wrong number of primes found. Looks like a bug.");
        }

        // Check their rotations are prime.
        int count = 0;
        foreach (long prime in primes)
        {
            // Check all rotations to see if they're also prime.
            List<ulong> rotations = Digits.GetRotations(prime);
            if (rotations.All(Primes.IsPrime))
            {
                Console.WriteLine($"All rotations of {prime} are prime: {string.Join(", ", rotations)}");
                count++;
            }
        }

        return count;
    }
}
