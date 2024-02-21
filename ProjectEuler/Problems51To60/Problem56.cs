using System.Numerics;
using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Powerful digit sum.
/// <see href="https://projecteuler.net/problem=56"/>
/// </summary>
public static class Problem56
{
    public static long Answer()
    {
        BigInteger maxDigitSum = 0;
        for (BigInteger a = 1; a < 100; a++)
        {
            for (var b = 1; b < 100; b++)
            {
                var c = BigInteger.Pow(a, b);
                BigInteger digitSum = c.DigitSum();
                if (digitSum > maxDigitSum)
                {
                    maxDigitSum = digitSum;
                }
            }
        }
        return (long)maxDigitSum;
    }
}
