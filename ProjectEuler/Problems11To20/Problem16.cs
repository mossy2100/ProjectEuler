using System.Numerics;
using AstroMultimedia.Core.Numbers;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Power digit sum.
/// <see href="https://projecteuler.net/problem=16" />
/// </summary>
public static class Problem16
{
    public static long Answer() =>
        (long)BigInteger.Pow(2, 1000).DigitSum();
}
