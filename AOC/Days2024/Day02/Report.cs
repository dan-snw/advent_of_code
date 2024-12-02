namespace AOC.Days2024.Day02;

public class Report(int[] report)
{
    public bool IsSafe()
    {
        var isAscending = report[1] > report[0];
        for (var i = 1; i < report.Length; i++)
        {
            if (Math.Abs(report[i] - report[i - 1]) is < 1 or > 3)
            {
                return false;
            }
            if (report[i] > report[i - 1] != isAscending)
            {
                return false;
            }
        }
        return true;
    }
}
