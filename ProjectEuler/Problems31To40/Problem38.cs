using System.Text;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Pandigital multiples.
/// <see href="https://projecteuler.net/problem=38" />
/// </summary>
public static class Problem38
{
    public static long Answer()
    {
        long largest = 0;

        // The multiplicand must have a maximum of 4 digits because the concatenated product has 9.
        for (var x = 1; x < 10000; x++)
        {
            StringBuilder sbDigits = new ("");
            var n = 1;
            while (true)
            {
                sbDigits.Append((x * n).ToString());
                if (n > 1 && sbDigits.Length == 9)
                {
                    var strDigits = sbDigits.ToString();
                    if (Digits.IsPandigital(strDigits))
                    {
                        long concatenatedProduct = int.Parse(strDigits);
                        Console.WriteLine($"x = {x}, n = {n}, p = {concatenatedProduct}");

                        if (concatenatedProduct > largest)
                        {
                            largest = concatenatedProduct;
                        }
                    }
                }

                if (sbDigits.Length >= 9)
                {
                    break;
                }

                n++;
            }
        }
        return largest;
    }
}
