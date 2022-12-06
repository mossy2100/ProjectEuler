using System.Numerics;
using AstroMultimedia.Core.Numbers;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Powerful digit sum.
/// <see href="https://projecteuler.net/problem=56" />
/// </summary>
public static class Problem56
{
    public static long Answer()
    {
        BigInteger maxDigitSum = 0;
        for (BigInteger a = 1; a < 100; a++)
        {
            for (int b = 1; b < 100; b++)
            {
                BigInteger c = BigInteger.Pow(a, b);
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
