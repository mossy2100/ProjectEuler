namespace Galaxon.ProjectEuler;

/// <summary>
/// Double-base palindromes.
/// <see href="https://projecteuler.net/problem=36" />
/// </summary>
public static class Problem36
{
    public static long Answer()
    {
        int sum = 0;
        for (int i = 1; i < 1000000; i++)
        {
            // Check if the base 10 version is palindromic.
            string base10 = i.ToString();
            string base10Rev = string.Join("", base10.Reverse()).TrimStart('0');
            if (base10 != base10Rev)
            {
                continue;
            }

            // Check if the base 2 version is palindromic.
            string base2 = Convert.ToString(i, 2);
            string base2Rev = string.Join("", base2.Reverse()).TrimStart('0');
            if (base2 == base2Rev)
            {
                Console.WriteLine($"{base10} and {base2} are palindromic.");
                sum += i;
            }
        }
        return sum;
    }
}
