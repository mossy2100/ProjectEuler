namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Maximum path sum II.
/// <see href="https://projecteuler.net/problem=67" />
/// </summary>
public static class Problem67
{
    private static int[][]? Triangle = new int[100][];

    private static void GetTriangle()
    {
        string path = Utility.GetDataFilePath("p067_triangle.txt");
        string[] rows = File.ReadAllLines(path);
        for (int r = 0; r < 100; r++)
        {
            string row = rows[r];
            string[] strValues = row.Trim().Split(" ");
            int[] intValues = new int[strValues.Length];
            for (int c = 0; c < strValues.Length; c++)
            {
                intValues[c] = int.Parse(strValues[c]);
            }
            Triangle![r] = intValues;
        }
    }

    public static long Answer()
    {
        GetTriangle();

        int[][] MaxPathSum = new int[100][];

        for (int row = 99; row >= 0; row--)
        {
            int len = row + 1;
            MaxPathSum[row] = new int[len];

            for (int col = 0; col < len; col++)
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
