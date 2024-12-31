namespace AOC.Days2024.Day09;

public class Day09 : Day<List<string>, long, List<string>, long>
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

    public List<string> FreeDiskSpace(List<string> input)
    {
        var freedUp = new List<string>();
        var endOfStringIndex = input.Count - 1;
        var i = 0;
        while (i <= endOfStringIndex)
        {
            if (input[i] == ".")
            {
                while (input[endOfStringIndex] == ".")
                {
                    endOfStringIndex--;
                }
                freedUp.Add(input[endOfStringIndex]);
                endOfStringIndex--;
            }
            else
            {
                freedUp.Add(input[i]);
            }

            i++;
        }

        return freedUp;
    }

    protected override long SolvePart1(List<string> parsedInput) =>
        FreeDiskSpace(parsedInput).Select((t, i) => long.Parse(t) * i).Sum();

    protected override List<string> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override long SolvePart2(List<string> parsedInput) => SolvePart1(parsedInput);
}
