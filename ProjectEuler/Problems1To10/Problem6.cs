namespace Galaxon.ProjectEuler;

/// <summary>
/// Sum square difference.
/// <see href="https://projecteuler.net/problem=6" />
/// </summary>
public static class Problem6
{
    public static long Answer()
    {
        int a = 0;
        int b = 0;
        for (int i = 1; i <= 100; i++)
        {
            a += i * i;
            b += i;
        }
        return b * b - a;
    }
}
