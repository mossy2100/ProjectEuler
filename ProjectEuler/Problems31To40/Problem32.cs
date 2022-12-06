namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Pandigital products.
/// <see href="https://projecteuler.net/problem=32" />
/// </summary>
public static class Problem32
{
    public static long Answer()
    {
        List<string> permutations = Factorials.CharPermutations("123456789");
        List<int> products = new();

        // Analysis shows that, for a * b = c:
        //   * a can only have 1 or 2 digits (if we specify a < b)
        //   * the total number of digits in a and b together is always 5
        //   * all products that fir the identity must have 4 digits

        // Check every permutation.
        foreach (string permutation in permutations)
        {
            for (int aLength = 1; aLength <= 2; aLength++)
            {
                // Get a, b, and c from the permutation string.
                int a = int.Parse(permutation[..aLength]);
                int b = int.Parse(permutation[aLength..5]);
                int c = int.Parse(permutation[5..]);

                // Avoid the multiplication if possible.
                // Make sure a is less than b to cut matches by half.
                // Also make sure c is greater than both a and b, since it's the product.
                if (a > b || a > c || b > c)
                {
                    continue;
                }

                // Check for match, and if we already found this product.
                if (a * b == c && !products.Contains(c))
                {
                    // Console.WriteLine($"{a} * {b} == {c}");
                    products.Add(c);
                }
            }
        }

        return products.Sum();
    }
}
