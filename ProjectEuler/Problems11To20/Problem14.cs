using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Longest Collatz sequence.
/// <see href="https://projecteuler.net/problem=14"/>
/// </summary>
public static class Problem14
{
    public static void Test()
    {
        for (var i = 1; i <= 20; i++)
        {
            Console.WriteLine(string.Join(", ", Sequences.Collatz(i)));
        }
    }

    public static long Answer()
    {
        var longestChainLength = 0;
        var startOfLongestChain = 0;
        for (var i = 1; i < 1_000_000; i++)
        {
            int len = Sequences.Collatz(i).Count;
            if (len > longestChainLength)
            {
                longestChainLength = len;
                startOfLongestChain = i;
            }
        }
        return startOfLongestChain;
    }
}
