using System.Numerics;
using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Lychrel numbers.
/// <see href="https://projecteuler.net/problem=55" />
/// </summary>
public static class Problem55
{
    public static long Answer()
    {
        var count = 0;
        const int MAX_ITERATIONS = 50;
        for (ulong i = 1; i < 10000; i++)
        {
            BigInteger sum = i;
            var isPalindromic = false;
            for (var j = 0; j < MAX_ITERATIONS; j++)
            {
                sum += sum.Reverse();
                if (sum.IsPalindromic())
                {
                    isPalindromic = true;
                    break;
                }
            }
            if (!isPalindromic)
            {
                count++;
            }
        }
        return count;
    }
}
