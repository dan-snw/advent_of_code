namespace AOC.Days2025.Day02;

public class Day02 : Day<List<(int, int)>, int, List<(int, int)>, int>
{
    protected override int DayNumber => 2;
    protected override int Year => 2025;

    public override List<(int, int)> ParseInputPart1(StreamReader input)
    {
        var ranges = new List<(int, int)>();
        while (!input.EndOfStream)
        {
            var pairs = input.ReadLine()!.Split(',');
            ranges = pairs
                .Select(pair => pair.Split('-')
                    .Select(int.Parse)
                    .ToList())
                .Select(test => new ValueTuple<int, int>(test[0], test[1]))
                .ToList();
        }
        return ranges;
    }

    protected override int SolvePart1(List<(int, int)> parsedInput)
    {
        throw new NotImplementedException();
    }

    protected override List<(int, int)> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<(int, int)> parsedInput) => SolvePart1(parsedInput);
}
