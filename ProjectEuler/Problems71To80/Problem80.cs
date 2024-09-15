using System.Numerics;
using Galaxon.Numerics.BigNumbers;
using Galaxon.Numerics.Extensions.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Square root digital expansion.
/// <see href="https://projecteuler.net/problem=80"/>
/// </summary>
public static class Problem80
{
    public static long Answer()
    {
        BigDecimal.MaxSigFigs = 102;
        var total = 0;
        for (var i = 2; i < 100; i++)
        {
            var sqrt = BigDecimal.Sqrt(i);
            Console.WriteLine($"The square root of {i} is {sqrt:N10}");

            if (sqrt.NumSigFigs <= 2)
            {
                Console.WriteLine("Perfect square");
                Console.WriteLine(
                    "------------------------------------------------------------------");
                continue;
            }

            sqrt *= BigDecimal.Exp10(99);
            var digits = (BigInteger)sqrt;
            Console.WriteLine($"The digits are {digits:N0}");
            total += (int)digits.DigitSum();
            Console.WriteLine("------------------------------------------------------------------");
        }
        return total;
    }
}
