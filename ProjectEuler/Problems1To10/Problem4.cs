using System.Numerics;
using AstroMultimedia.Core.Numbers;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Largest palindrome product.
/// <see href="https://projecteuler.net/problem=4" />
/// </summary>
public static class Problem4
{
    public static int Answer()
    {
        int max = 0;
        for (int i = 111; i <= 999; i++)
        {
            for (int j = 111; j <= 999; j++)
            {
                int k = i * j;
                if (((BigInteger)k).IsPalindromic() && k > max)
                {
                    max = k;
                }
            }
        }
        return max;
    }
}
