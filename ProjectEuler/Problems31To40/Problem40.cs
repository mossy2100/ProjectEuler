using System.Text;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Champernowne's constant.
/// <see href="https://projecteuler.net/problem=40" />
/// </summary>
public static class Problem40
{
    private static int GetDigit(StringBuilder sDigits, int index) =>
        int.Parse(sDigits[index].ToString());

    public static long Answer()
    {
        StringBuilder sbDigits = new ();
        var n = 0;
        while (sbDigits.Length <= 1000000)
        {
            sbDigits.Append(n);
            n++;
        }
        return GetDigit(sbDigits, 1) * GetDigit(sbDigits, 10) * GetDigit(sbDigits, 100)
            * GetDigit(sbDigits, 1000) * GetDigit(sbDigits, 10000) * GetDigit(sbDigits, 100000)
            * GetDigit(sbDigits, 1000000);
    }
}
