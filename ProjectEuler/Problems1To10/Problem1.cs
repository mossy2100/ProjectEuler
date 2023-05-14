namespace Galaxon.ProjectEuler;

/// <summary>
/// Multiples of 3 or 5.
/// <see href="https://projecteuler.net/problem=1" />
/// </summary>
public static class Problem1
{
    /// <summary>
    /// Correct answer: 233168
    /// </summary>
    public static long Answer()
    {
        var result = 0;
        for (var i = 0; i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                result += i;
            }
        }
        return result;
    }
}
