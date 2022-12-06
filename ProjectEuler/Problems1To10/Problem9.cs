namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Special Pythagorean triplet.
/// <see href="https://projecteuler.net/problem=9" />
/// </summary>
public static class Problem9
{
    private static int? IntSqrt(int n)
    {
        double d = Sqrt(n);
        int s = (int)d;
        return d - s == 0 ? s : null;
    }

    public static long Answer()
    {
        for (int a = 1; a < 1000; a++)
        {
            for (int b = a + 1; b < 1000; b++)
            {
                int cSqr = a * a + b * b;
                int? c = IntSqrt(cSqr);
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
