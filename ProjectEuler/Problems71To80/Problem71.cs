using Galaxon.Numerics.BigNumbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Ordered fractions.
/// <see href="https://projecteuler.net/problem=71"/>
/// </summary>
public static class Problem71
{
    public static long Answer()
    {
        double limit = 3.0 / 7;
        double minDiff = double.MaxValue;
        ulong minDiffNum = 0;
        ulong minDiffDen = 0;

        for (ulong den = 2; den <= 1_000_000; den++)
        {
            var num = (ulong)Floor(limit * den);
            double r = (double)num / den;
            double diff = limit - r;
            if (diff > 0 && diff < minDiff)
            {
                minDiff = diff;
                minDiffNum = num;
                minDiffDen = den;
            }
        }

        BigRational f = new (minDiffNum, minDiffDen);
        return (long)f.Numerator;
    }
}
