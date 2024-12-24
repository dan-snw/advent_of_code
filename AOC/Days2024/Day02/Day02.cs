namespace AOC.Days2024.Day02;

public class Day02 : Day<List<List<int>>, int, List<List<int>>, int>
{
    protected override int DayNumber => 2;
    protected override int Year => 2024;

    public override List<List<int>> ParseInputPart1(StreamReader input)
    {
        var reports = new List<List<int>>();
        while (!input.EndOfStream)
        {
            reports.Add([.. input.ReadLine()!.Split(" ").Select(int.Parse).ToList()]);
        }
        return reports;
    }

    protected override int SolvePart1(List<List<int>> reports) => reports.Count(x => x.IsSafe());

    protected override List<List<int>> ParseInputPart2(StreamReader input) =>
        ParseInputPart1(input);

    protected override int SolvePart2(List<List<int>> reports) =>
        reports.Count(x => x.IsSafeWithDampener());
}

internal static class ListExtensions
{
    public static bool IsSafeWithDampener(this List<int> report)
    {
        for (var i = 0; i < report.Count; i++)
        {
            var newList = new List<int>(report);
            newList.RemoveAt(i);
            if (newList.IsSafe())
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsSafe(this List<int> report)
    {
        var isAscending = report[0] < report[1];
        for (var i = 0; i < report.Count - 1; i++)
        {
            if (!IsSafe(report[i], report[i + 1], isAscending))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsSafe(int l1, int l2, bool isAscending) =>
        Math.Abs(l1 - l2) is >= 1 and <= 3 && l1 < l2 == isAscending;
}
