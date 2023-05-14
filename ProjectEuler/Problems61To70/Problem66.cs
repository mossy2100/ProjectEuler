using System.Numerics;
using Galaxon.Core.Numbers;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Diophantine equation.
/// <see href="https://projecteuler.net/problem=66" />
/// </summary>
public static class Problem66
{
    public static long Answer()
    {
        BigInteger largestX = 0;
        var DForLargestX = 0;
        var min = 2;
        var max = 1000;
        for (var D = min; D <= max; D++)
        {
            Console.WriteLine();
            Console.WriteLine($"D = {D}:");

            // Skip squares.
            if (XDouble.IsPerfectSquare(D))
            {
                Console.WriteLine("Perfect square, skipping.");
                continue;
            }

            (var x, var y) = Pell.Solve(D);
            Console.WriteLine($"{x:N0}² - {D}×{y:N0}² = 1");

            if (x > largestX)
            {
                largestX = x;
                DForLargestX = D;
            }
        }

        return DForLargestX;
    }
}
