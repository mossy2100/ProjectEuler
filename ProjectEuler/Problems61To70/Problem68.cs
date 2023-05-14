using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Magic 5-gon ring.
/// <see href="https://projecteuler.net/problem=68" />
/// </summary>
public static class Problem68
{
    public static bool IsValid(List<int> fiveGon)
    {
        var sum1 = fiveGon[5] + fiveGon[0] + fiveGon[1];
        var sum2 = fiveGon[6] + fiveGon[1] + fiveGon[2];
        var sum3 = fiveGon[7] + fiveGon[2] + fiveGon[3];
        var sum4 = fiveGon[8] + fiveGon[3] + fiveGon[4];
        var sum5 = fiveGon[9] + fiveGon[4] + fiveGon[0];
        return sum1 == sum2 && sum1 == sum3 && sum1 == sum4 && sum1 == sum5;
    }

    public static long Answer()
    {
        List<int> nums = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var fiveGons = Factorials.GetPermutations(nums, 10);
        long max = 0;

        foreach (var fiveGon in fiveGons)
        {
            if (IsValid(fiveGon))
            {
                // Find the numerically lowest external node.
                var min = int.MaxValue;
                var minPos = 0;
                for (var i = 5; i < 10; i++)
                {
                    if (fiveGon[i] < min)
                    {
                        min = fiveGon[i];
                        minPos = i;
                    }
                }

                // Count each arm, going clockwise.
                var values = new int[5][];
                var triplets = new string[5];
                var tripletDigits = new string[5];
                var armSums = new int[5];

                var pos = minPos;
                for (var i = 0; i < 5; i++)
                {
                    values[i] = new[]
                    {
                        fiveGon[pos],
                        fiveGon[pos - 5],
                        fiveGon[(pos - 4) % 5]
                    };

                    tripletDigits[i] = string.Join("", values[i]);
                    armSums[i] = values[i].Sum();
                    triplets[i] = $"({values[i][0]}+{values[i][1]}+{values[i][2]}={armSums[i]})";

                    pos++;
                    if (pos == 10)
                    {
                        pos = 5;
                    }
                }

                var strSolution = string.Join(" ", triplets);
                var digits = string.Join("", tripletDigits);

                // Get the longest 16-digit number.
                if (digits.Length == 16)
                {
                    var digitVal = long.Parse(digits);
                    if (digitVal > max)
                    {
                        max = digitVal;
                    }
                }

                Console.WriteLine($"Solution: {strSolution}");
            }
        }

        return max;
    }
}
