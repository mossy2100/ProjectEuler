namespace Galaxon.ProjectEuler;

/// <summary>
/// Counting Sundays.
/// <see href="https://projecteuler.net/problem=19"/>
/// </summary>
public static class Problem19
{
    private static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    private static int DaysInMonth(int year, int month)
    {
        return month switch
        {
            2 => IsLeapYear(year) ? 29 : 28,
            <= 7 => 30 + month % 2,
            _ => 31 - month % 2
        };
    }

    public static long Answer()
    {
        var year = 1900;
        var month = 1;
        var dayNumber = 1;
        var sundayCount = 0;
        while (true)
        {
            // Check for Sunday.
            if (year >= 1901 && dayNumber % 7 == 0)
            {
                sundayCount++;
            }

            // Go to the start of next month.
            dayNumber += DaysInMonth(year, month);

            // Go to next month.
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }

            // Are we done?
            if (year > 2000)
            {
                break;
            }
        }

        return sundayCount;
    }
}
