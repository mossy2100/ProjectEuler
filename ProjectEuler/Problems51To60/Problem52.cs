namespace Galaxon.ProjectEuler;

/// <summary>
/// Permuted multiples.
/// <see href="https://projecteuler.net/problem=52" />
/// </summary>
public static class Problem52
{
    private static string UniqueDigits(int n)
    {
        List<char> digitChars = n.ToString().Distinct().ToList();
        digitChars.Sort();
        return string.Join("", digitChars);
    }

    public static long Answer()
    {
        int x = 1;
        while (true)
        {
            int y = x;
            string digits1 = UniqueDigits(y);
            bool answerFound = true;

            for (int i = 2; i <= 6; i++)
            {
                // Compare the digits in x with the digits in (i * x).
                // Use addition to avoid multiplication and thus save time.
                y += x;
                string digits2 = UniqueDigits(y);
                if (digits2 != digits1)
                {
                    answerFound = false;
                    break;
                }
            }

            if (answerFound)
            {
                return x;
            }

            x++;
        }
    }
}
