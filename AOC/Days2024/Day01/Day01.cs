namespace AOC.Days2024.Day01;

public class Day01 : Day<(List<int>, List<int>), int, string, int>
{
    protected override int DayNumber => 1;
    protected override int Year => 2024;

    protected override (List<int>, List<int>) ParseInputPart1(StreamReader input)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine()?.Split("   ");
            list1.Add(Convert.ToInt32(inputLine?[0]));
            list2.Add(Convert.ToInt32(inputLine?[1]));
        }
        return (list1, list2);
    }

    protected override int SolvePart1((List<int>, List<int>) parsedInput)
    {
        var list1 = parsedInput.Item1;
        var list2 = parsedInput.Item2;
        var sumOfDifferences = 0;
        list1.Sort();
        list2.Sort();
        for (int i = 0; i < list1.Count; i++)
        {
            sumOfDifferences += Math.Abs(list1[i] - list2[i]);
        }
        return sumOfDifferences;
    }

    protected override string ParseInputPart2(StreamReader input)
    {
        throw new NotImplementedException();
    }

    protected override int SolvePart2(string parsedInput)
    {
        throw new NotImplementedException();
    }
}
