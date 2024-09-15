using System.Numerics;
using Galaxon.Numerics.Extensions.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Power digit sum.
/// <see href="https://projecteuler.net/problem=16"/>
/// </summary>
public static class Problem16
{
    public static long Answer()
    {
        return (long)BigInteger.Pow(2, 1000).DigitSum();
    }
}
