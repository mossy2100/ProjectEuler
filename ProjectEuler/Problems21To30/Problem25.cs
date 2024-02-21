using System.Numerics;

namespace Galaxon.ProjectEuler;

/// <summary>
/// 1000-digit Fibonacci number.
/// <see href="https://projecteuler.net/problem=25"/>
/// </summary>
public static class Problem25
{
    public static int Answer()
    {
        BigInteger a = 1;
        BigInteger b = 1;
        var i = 3;
        while (true)
        {
            BigInteger c = a + b;
            if (c >= BigInteger.Pow(10, 999))
            {
                return i;
            }
            a = b;
            b = c;
            i++;
        }
    }
}
