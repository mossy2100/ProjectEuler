namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Pentagon numbers.
/// <see href="https://projecteuler.net/problem=44" />
/// </summary>
public static class Problem44
{
    public static long Answer()
    {
        ulong j = 1;
        while (true)
        {
            // Get the next pentagonal number in the series.
            ulong pj = PolygonalNumbers.GetPentagonal(j);

            // Check the new number paired with all smaller pentagonal numbers.
            // Check in descending order to minimise the difference.
            for (ulong k = j - 1; k >= 1; k--)
            {
                ulong pk = PolygonalNumbers.GetPentagonal(k);
                // Console.WriteLine($"Comparing {pj} and {pk}");

                // Calculate the sum and the difference;
                ulong sum = pj + pk;
                ulong diff = pj - pk;
                if (PolygonalNumbers.IsPentagonal(sum) && PolygonalNumbers.IsPentagonal(diff))
                {
                    // Found the answer.
                    return (long)diff;
                }
            }

            // This check isn't needed when the code is working, but ensures loop doesn't run
            // forever (just in case).
            if (j == int.MaxValue)
            {
                throw new ArithmeticException("Too many iterations.");
            }

            j++;
        }
    }
}
