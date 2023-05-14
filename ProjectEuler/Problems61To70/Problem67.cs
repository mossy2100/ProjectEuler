namespace Galaxon.ProjectEuler;

/// <summary>
/// Maximum path sum II.
/// <see href="https://projecteuler.net/problem=67" />
/// </summary>
public static class Problem67
{
    private static readonly int[][]? Triangle = new int[100][];

    private static void GetTriangle()
    {
        var path = Utility.GetDataFilePath("p067_triangle.txt");
        var rows = File.ReadAllLines(path);
        for (var r = 0; r < 100; r++)
        {
            var row = rows[r];
            var strValues = row.Trim().Split(" ");
            var intValues = new int[strValues.Length];
            for (var c = 0; c < strValues.Length; c++)
            {
                intValues[c] = int.Parse(strValues[c]);
            }
            Triangle![r] = intValues;
        }
    }

    public static long Answer()
    {
        GetTriangle();

        var MaxPathSum = new int[100][];

        for (var row = 99; row >= 0; row--)
        {
            var len = row + 1;
            MaxPathSum[row] = new int[len];

            for (var col = 0; col < len; col++)
            {
                MaxPathSum[row][col] = Triangle![row][col];
                if (row < 99)
                {
                    MaxPathSum[row][col] += Max(MaxPathSum[row + 1][col],
                        MaxPathSum[row + 1][col + 1]);
                }
            }
        }

        return MaxPathSum[0][0];
    }
}
