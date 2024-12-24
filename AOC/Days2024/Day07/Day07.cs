namespace AOC.Days2024.Day07;

public class Day07 : Day<List<(int, List<int>)>, int, List<(int, List<int>)>, int>
{
    protected override int DayNumber => 7;
    protected override int Year => 2024;

    public override List<(int, List<int>)> ParseInputPart1(StreamReader input)
    {
        var parsedInput = new List<(int, List<int>)>();
        while (!input.EndOfStream)
        {
            var split = input.ReadLine()!.Split(": ");
            parsedInput.Add(
                (int.Parse(split.First()), split[1].Split(" ").Select(int.Parse).ToList())
            );
        }
        return parsedInput;
    }

    protected override int SolvePart1(List<(int, List<int>)> parsedInput)
    {
        throw new NotImplementedException();
    }

    protected override List<(int, List<int>)> ParseInputPart2(StreamReader input) =>
        ParseInputPart1(input);

    protected override int SolvePart2(List<(int, List<int>)> parsedInput) =>
        SolvePart1(parsedInput);

    public static List<string[]> GetCombinations(int length, string[] characters)
    {
        var combinations = new List<string[]>();

        var combinationMax = "";
        for (var i = 0; i < length; i++)
        {
            combinationMax += "1";
        }

        var fromBase = Convert.ToInt32(combinationMax, characters.Length);
        for (var i = 0; i <= fromBase; i++)
        {
            var inBase = Convert.ToString(i, characters.Length).PadLeft(length, '0');
            combinations.Add(inBase.Select(bit => characters[int.Parse(bit.ToString())]).ToArray());
        }

        return combinations;
    }
}
