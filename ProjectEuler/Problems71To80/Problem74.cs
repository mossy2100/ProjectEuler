using System.Numerics;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Digit factorial chains.
/// <see href="https://projecteuler.net/problem=74" />
/// </summary>
public static class Problem74
{
    public static long Answer()
    {
        int count = 0;
        for (int i = 0; i <= 1_000_000; i++)
        {
            List<BigInteger> chain = new ();
            BigInteger n = i;
            chain.Add(n);
            // Console.Write($"{n} -> ");
            while (true)
            {
                n = Digits.SumFactorialDigits(n);
                if (chain.Contains(n))
                {
                    // Console.Write($"({n})");
                    break;
                }
                chain.Add(n);
                // Console.Write($"{n} -> ");
            }

            int chainLength = chain.Count;
            // Console.WriteLine();
            // Console.WriteLine($"Starting with {i} produces a chain of {chainLength} non-repeating terms.");
            // Console.WriteLine();
            if (chainLength == 60)
            {
                count++;
            }
        }
        return count;
    }
}
