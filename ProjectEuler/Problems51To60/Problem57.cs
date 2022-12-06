using AstroMultimedia.Numerics.Types;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Square root convergents.
/// <see href="https://projecteuler.net/problem=57" />
/// </summary>
public static class Problem57
{
    public static long Answer()
    {
        int count = 0;
        Fraction f = 1 + new Fraction(1, 2);
        for (int i = 0; i < 1000; i++)
        {
            f = 1 + (1 / (f + 1));
            if (NumDigits(f.Numerator) > NumDigits(f.Denominator))
            {
                count++;
            }
        }
        return count;
    }
}
