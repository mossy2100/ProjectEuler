namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Pentagon numbers.
/// <see href="https://projecteuler.net/problem=44" />
/// </summary>
public static class Problem44
{
    public static long Answer()
    {
        int j = 1;
        while (true)
        {
            // Get the next pentagonal number in the series.
            long pj = Pentagonal.Get(j);

            // Check the new number paired with all smaller pentagonal numbers.
            // Check in descending order to minimise the difference.
            for (int k = j - 1; k >= 1; k--)
            {
                long pk = Pentagonal.Get(k);
                // Console.WriteLine($"Comparing {pj} and {pk}");

                // Calculate the sum and the difference;
                long sum = pj + pk;
                long diff = pj - pk;
                if (Pentagonal.IsPentagonal(sum) && Pentagonal.IsPentagonal(diff))
                {
                    // Found the answer.
                    return diff;
                }
            }

            // This check isn't needed when the code is working, but ensures loop doesn't run
            // forever (just in case).
            if (j == int.MaxValue)
            {
                throw new ArithmeticException("Too many iterations.");
            }

            j++;
        }
    }

    public static void Test()
    {
        for (int i = 1; i < 150; i++)
        {
            if (Pentagonal.IsPentagonal(i))
            {
                Console.WriteLine($"{i} is pentagonal.");
            }
        }
    }
}
