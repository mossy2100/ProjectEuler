namespace Galaxon.ProjectEuler;

/// <summary>
/// Maximum path sum I.
/// <see href="https://projecteuler.net/problem=18"/>
/// </summary>
public static class Problem18
{
    private const string TriangleAsString = """
                                                75
                                                95 64
                                                17 47 82
                                                18 35 87 10
                                                20 04 82 47 65
                                                19 01 23 75 03 34
                                                88 02 77 73 07 63 67
                                                99 65 04 28 06 16 70 92
                                                41 41 26 56 83 40 80 70 33
                                                41 48 72 33 47 32 37 16 94 29
                                                53 71 44 65 25 43 91 52 97 51 14
                                                70 11 33 28 77 73 17 78 39 68 17 57
                                                91 71 52 38 17 14 91 43 58 50 27 29 48
                                                63 66 04 68 89 53 67 30 73 16 69 87 40 31
                                                04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
                                            """;

    private static int[][]? Triangle;

    private static readonly Dictionary<(int r, int c), int> MaxPathSumCache = new ();

    private static void GetTriangle()
    {
        string[] rows = TriangleAsString.Trim().Split("\n");
        Triangle = new int[rows.Length][];
        for (var r = 0; r < rows.Length; r++)
        {
            string row = rows[r];
            string[] strValues = row.Trim().Split(" ");
            var intValues = new int[strValues.Length];
            for (var c = 0; c < strValues.Length; c++)
            {
                intValues[c] = int.Parse(strValues[c]);
            }
            Triangle[r] = intValues;
        }
    }

    private static int MaxPathSum(int r, int c)
    {
        // Check cache.
        if (MaxPathSumCache.ContainsKey((r, c)))
        {
            return MaxPathSumCache[(r, c)];
        }

        int current = Triangle![r][c];
        int result;
        if (r == Triangle.Length - 1)
        {
            result = current;
        }
        else
        {
            int option1 = current + MaxPathSum(r + 1, c);
            int option2 = current + MaxPathSum(r + 1, c + 1);
            result = Max(option1, option2);
        }

        // Cache the result.
        MaxPathSumCache[(r, c)] = result;

        return result;
    }

    public static long Answer()
    {
        GetTriangle();
        return MaxPathSum(0, 0);
    }
}
