using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Cubic permutations.
/// <see href="https://projecteuler.net/problem=62"/>
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
            double min = Pow(10, nDigits - 1);
            double max = min * 10 - 1;

            // Store the cubes we find with this many digits.
            List<ulong> cubes = new ();

            // Get all the cubes with this many digits.
            while (true)
            {
                ulong nCubed = n * n * n;
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
                ulong cube0 = cubes[i0];
                string str0 = Combinatorial.SortDigits(cube0);
                for (int i1 = i0 + 1; i1 < cubes.Count - 3; i1++)
                {
                    ulong cube1 = cubes[i1];
                    string str1 = Combinatorial.SortDigits(cube1);
                    if (str0 != str1)
                    {
                        continue;
                    }

                    for (int i2 = i1 + 1; i2 < cubes.Count - 2; i2++)
                    {
                        ulong cube2 = cubes[i2];
                        string str2 = Combinatorial.SortDigits(cube2);
                        if (str0 != str2)
                        {
                            continue;
                        }

                        for (int i3 = i2 + 1; i3 < cubes.Count - 1; i3++)
                        {
                            ulong cube3 = cubes[i3];
                            string str3 = Combinatorial.SortDigits(cube3);
                            if (str0 != str3)
                            {
                                continue;
                            }

                            for (int i4 = i3 + 1; i4 < cubes.Count; i4++)
                            {
                                ulong cube4 = cubes[i4];
                                string str4 = Combinatorial.SortDigits(cube4);
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
