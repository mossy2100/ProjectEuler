namespace Galaxon.ProjectEuler;

/// <summary>
/// Sum square difference.
/// <see href="https://projecteuler.net/problem=6"/>
/// </summary>
public static class Problem6
{
    public static long Answer()
    {
        var a = 0;
        var b = 0;
        for (var i = 1; i <= 100; i++)
        {
            a += i * i;
            b += i;
        }
        return b * b - a;
    }
}
