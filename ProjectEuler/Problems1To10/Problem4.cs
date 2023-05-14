using System.Numerics;
using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Largest palindrome product.
/// <see href="https://projecteuler.net/problem=4" />
/// </summary>
public static class Problem4
{
    public static int Answer()
    {
        var max = 0;
        for (var i = 111; i <= 999; i++)
        {
            for (var j = 111; j <= 999; j++)
            {
                var k = i * j;
                if (((BigInteger)k).IsPalindromic() && k > max)
                {
                    max = k;
                }
            }
        }
        return max;
    }
}
