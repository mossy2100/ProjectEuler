using System.Numerics;

namespace Galaxon.ProjectEuler;

/// <summary>
///     <see href="https://projecteuler.net/problem="/>
/// </summary>
public static class Problem48
{
    public static long Answer()
    {
        BigInteger sum = 0;
        for (var n = 1; n <= 1000; n++)
        {
            sum += BigInteger.Pow(n, n);
        }
        return long.Parse(sum.ToString()[^10..]);
    }
}
