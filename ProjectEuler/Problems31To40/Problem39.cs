namespace Galaxon.ProjectEuler;

/// <summary>
/// Integer right triangles.
/// <see href="https://projecteuler.net/problem=39"/>
/// </summary>
public static class Problem39
{
    public static long Answer()
    {
        var maxNSolutions = 0;
        var maxP = 0;
        for (var p = 3; p <= 1000; p++)
        {
            var nSolutions = 0;

            // Loop through possible lengths of side a.
            for (var a = 1; a <= p - 2; a++)
            {
                // Loop through possible lengths of side b.
                // Specify b >= a to reduce duplicate matches.
                for (int b = a; b <= p - 2; b++)
                {
                    // Calculate length of hypotenuse c from the total perimeter.
                    int c = p - a - b;

                    // Check c is longer than a and b to skip the multiplications if possible.
                    if (c <= a || c <= b)
                    {
                        continue;
                    }

                    // Check it's a valid right triangle.
                    if (a * a + b * b == c * c)
                    {
                        nSolutions++;
                        Console.WriteLine($"Solution found for p={p}: ({a}, {b}, {c})");
                    }
                }
            }

            if (nSolutions > maxNSolutions)
            {
                maxNSolutions = nSolutions;
                maxP = p;
            }
        }

        return maxP;
    }
}
