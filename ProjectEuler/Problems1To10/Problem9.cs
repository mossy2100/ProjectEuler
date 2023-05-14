namespace Galaxon.ProjectEuler;

/// <summary>
/// Special Pythagorean triplet.
/// <see href="https://projecteuler.net/problem=9" />
/// </summary>
public static class Problem9
{
    private static int? IntSqrt(int n)
    {
        var d = Sqrt(n);
        var s = (int)d;
        return d - s == 0 ? s : null;
    }

    public static long Answer()
    {
        for (var a = 1; a < 1000; a++)
        {
            for (var b = a + 1; b < 1000; b++)
            {
                var cSqr = a * a + b * b;
                var c = IntSqrt(cSqr);
                if (!c.HasValue || a + b + c.Value != 1000)
                {
                    continue;
                }
                Console.WriteLine($"a = {a}, b = {b}, c = {c.Value}");
                return a * b * c.Value;
            }
        }
        return 0;
    }
}
