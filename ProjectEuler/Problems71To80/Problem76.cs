namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Counting summations.
/// <see href="https://projecteuler.net/problem=76" />
/// </summary>
public static class Problem76
{
    public static int CountWays(int n, int? max = null)
    {
        // Only one way to sum 1.
        if (n == 1)
        {
            return 1;
        }

        // Default max first number.
        if (max is null)
        {
            max = n;
        }

        int count = 0;

        // Let a be the first number in the series of integer that form the sum.
        // It cannot be greater than max.
        for (int a = Min(n, (int)max); a >= 1; a--)
        {
            if (a == n)
            {
                count++;
            }
            else
            {
                count += CountWays(n - a, a);
            }
        }

        return count;
    }

    public static long Answer()
    {
        return CountWays(100) - 1;
    }
}
