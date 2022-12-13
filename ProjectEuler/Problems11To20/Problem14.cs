namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Longest Collatz sequence.
/// <see href="https://projecteuler.net/problem=14" />
/// </summary>
public static class Problem14
{
    public static void Test()
    {
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(string.Join(", ", Sequences.Collatz(i)));
        }
    }

    public static long Answer()
    {
        int longestChainLength = 0;
        int startOfLongestChain = 0;
        for (int i = 1; i < 1_000_000; i++)
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
