namespace AOC.Days2024.Day01;

public class Day01 : Day<(List<int>, List<int>), int, (List<int>, Dictionary<int, int>), int>
{
    protected override int DayNumber => 1;
    protected override int Year => 2024;

    public override (List<int>, List<int>) ParseInputPart1(StreamReader input)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine()?.Split("   ");
            list1.Add(Convert.ToInt32(inputLine?[0]));
            list2.Add(Convert.ToInt32(inputLine?[1]));
        }
        list1.Sort();
        list2.Sort();
        return (list1, list2);
    }

    protected override int SolvePart1((List<int>, List<int>) parsedInput) =>
        parsedInput.Item1.Select((t, i) => Math.Abs(t - parsedInput.Item2[i])).Sum();

    protected override (List<int>, Dictionary<int, int>) ParseInputPart2(StreamReader input)
    {
        var list1 = new List<int>();
        var appearancesInSecondList = new Dictionary<int, int>();
        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine()?.Split("   ");
            list1.Add(Convert.ToInt32(inputLine?[0]));
            appearancesInSecondList.TryAdd(Convert.ToInt32(inputLine?[1]), 0);
            appearancesInSecondList[Convert.ToInt32(inputLine?[1])]++;
        }
        return (list1, appearancesInSecondList);
    }

    protected override int SolvePart2((List<int>, Dictionary<int, int>) parsedInput) =>
        parsedInput.Item1.Sum(i => i * parsedInput.Item2.GetValueOrDefault(i, 0));
}
