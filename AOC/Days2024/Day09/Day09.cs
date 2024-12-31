namespace AOC.Days2024.Day09;

public class Day09 : Day<List<string>, int, List<string>, int>
{
    protected override int DayNumber => 9;
    protected override int Year => 2024;

    public override List<string> ParseInputPart1(StreamReader input)
    {
        var compressed = input.ReadLine()!.Select(s => int.Parse(s.ToString())).ToList();
        var gap = false;
        var uncompressed = new List<string>();
        var index = 0;
        foreach (var block in compressed)
        {
            for (var j = 0; j < block; j++)
            {
                uncompressed.Add(gap ? "." : $"{index}");
            }
            gap = !gap;
            if (gap)
            {
                index++;
            }
        }
        return uncompressed;
    }

    protected override int SolvePart1(List<string> parsedInput)
    {
        throw new NotImplementedException();
    }

    protected override List<string> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<string> parsedInput) => SolvePart1(parsedInput);
}
