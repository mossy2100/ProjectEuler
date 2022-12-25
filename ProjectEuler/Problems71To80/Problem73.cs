namespace Galaxon.ProjectEuler;

/// <summary>
/// Counting fractions in a range
/// <see href="https://projecteuler.net/problem=73" />
/// </summary>
public static class Problem73
{
    public static long Answer()
    {
        HashSet<double> fractions = new ();
        int max = 12_000;
        for (int den = 2; den <= max; den++)
        {
            int start = (int)Ceiling(den / 3.0) + (den % 3 == 0 ? 1 : 0);
            int stop = (int)Floor(den / 2.0) - (den % 2 == 0 ? 1 : 0);
            for (int num = start; num <= stop; num++)
            {
                // Console.WriteLine($"{num}/{den}");
                fractions.Add((double)num / den);
            }
        }
        return fractions.Count;
    }
}
