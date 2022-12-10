using AstroMultimedia.Core.Numbers;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Diophantine equation.
/// <see href="https://projecteuler.net/problem=66" />
/// </summary>
public static class Problem66
{
    public static readonly List<long> SquaresCache = new ();

    public static long Sqr(int x)
    {
        if (x >= SquaresCache.Count)
        {
            SquaresCache.EnsureCapacity(x + 1);
            SquaresCache[x] = (long)(x) * x;
        }
        return SquaresCache[x];
    }

    public static long Answer()
    {
        long largestX = 0;
        long DForLargestX = 0;
        for (long D = 2; D <= 1000; D++)
        {
            // Skip squares.
            if (PolygonalNumbers.IsSquare((ulong)D))
            {
                continue;
            }

            int x = 1;
            while (true)
            {
                // Solve for y.
                double dy = Sqrt((Sqr(x) - 1) / (double)D);
                if (XDouble.FuzzyIsPositiveInteger(dy, 1e-5))
                {
                    int y = (int)Round(dy);

                    // Double-check because imprecision of doubles is giving false positives.
                    if (Sqr(x) - D * Sqr(y) == 1)
                    {
                        Console.WriteLine($"{x}^2 - {D}x{y}^2 = 1");
                        if (x > largestX)
                        {
                            largestX = x;
                            DForLargestX = D;
                        }
                        break;
                    }
                }

                x++;
            }
        }

        return DForLargestX;
    }
}
