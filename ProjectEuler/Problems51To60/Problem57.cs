using Galaxon.Numerics;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Square root convergents.
/// <see href="https://projecteuler.net/problem=57" />
/// </summary>
public static class Problem57
{
    public static long Answer()
    {
        int count = 0;
        BigRational f = 1 + new BigRational(1, 2);
        for (int i = 0; i < 1000; i++)
        {
            f = 1 + (1 / (f + 1));
            if (Digits.NumDigits(f.Numerator) > Digits.NumDigits(f.Denominator))
            {
                count++;
            }
        }
        return count;
    }
}
