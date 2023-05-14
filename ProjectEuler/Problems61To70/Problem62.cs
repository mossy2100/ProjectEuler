using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Cubic permutations.
/// <see href="https://projecteuler.net/problem=62" />
/// </summary>
public static class Problem62
{
    public static long Answer()
    {
        // Start with 2-digit numbers.
        var nDigits = 2;

        // Start value that will give us the first 2-digit cube.
        ulong n = 3;

        // How many cubes do we want to find that are permutations of each other?
        const int nSought = 5;

        // Get all the cubes with this many digits.
        while (true)
        {
            var min = Pow(10, nDigits - 1);
            var max = min * 10 - 1;

            // Store the cubes we find with this many digits.
            List<ulong> cubes = new ();

            // Get all the cubes with this many digits.
            while (true)
            {
                var nCubed = n * n * n;
                if (nCubed > max)
                {
                    break;
                }
                cubes.Add(nCubed);
                n++;
            }

            // Make sure we have enough.
            if (cubes.Count < nSought)
            {
                nDigits++;
                continue;
            }

            // Try to find 5 matching numbers from the current set of cubes.
            for (var i0 = 0; i0 < cubes.Count - 4; i0++)
            {
                var cube0 = cubes[i0];
                var str0 = Factorials.SortDigits(cube0);
                for (var i1 = i0 + 1; i1 < cubes.Count - 3; i1++)
                {
                    var cube1 = cubes[i1];
                    var str1 = Factorials.SortDigits(cube1);
                    if (str0 != str1)
                    {
                        continue;
                    }

                    for (var i2 = i1 + 1; i2 < cubes.Count - 2; i2++)
                    {
                        var cube2 = cubes[i2];
                        var str2 = Factorials.SortDigits(cube2);
                        if (str0 != str2)
                        {
                            continue;
                        }

                        for (var i3 = i2 + 1; i3 < cubes.Count - 1; i3++)
                        {
                            var cube3 = cubes[i3];
                            var str3 = Factorials.SortDigits(cube3);
                            if (str0 != str3)
                            {
                                continue;
                            }

                            for (var i4 = i3 + 1; i4 < cubes.Count; i4++)
                            {
                                var cube4 = cubes[i4];
                                var str4 = Factorials.SortDigits(cube4);
                                if (str0 != str4)
                                {
                                    continue;
                                }

                                // Found it.
                                return (long)cube0;
                            }
                        }
                    }
                }
            }

            // Try larger numbers.
            nDigits++;
        }
    }
}
