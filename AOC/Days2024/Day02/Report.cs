namespace AOC.Days2024.Day02;

public class Report(List<int> report)
{
    public bool IsSafe(bool useDampener = false)
    {
        if (useDampener == false)
        {
            return ReportIsSafe(report);
        }
        for (var i = 0; i < report.Count; i++)
        {
            var newList = new List<int>(report);
            newList.RemoveAt(i);
            if (ReportIsSafe(newList))
            {
                return true;
            }
        }
        return false;
    }

    private bool ReportIsSafe(List<int> listOfInts)
    {
        var isAscending = listOfInts[0] < listOfInts[1];
        for (var i = 0; i < listOfInts.Count - 1; i++)
        {
            if (!LevelSafe(listOfInts[i], listOfInts[i + 1], isAscending))
            {
                return false;
            }
        }
        return true;
    }

    private bool LevelSafe(int l1, int l2, bool isAscending) =>
        Math.Abs(l1 - l2) is >= 1 and <= 3 && l1 < l2 == isAscending;
}
