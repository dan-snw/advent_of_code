using AOC.Common;

namespace AOC.Days2025.Day04;

public class Day04 : Day<Dictionary<Coordinate, bool>, int, Dictionary<Coordinate, bool>, int>
{
    protected override int DayNumber => 4;
    protected override int Year => 2025;

    public override Dictionary<Coordinate, bool> ParseInputPart1(StreamReader input)
    {
        var map = new Dictionary<Coordinate, bool>();
        var y = 0;
        while (!input.EndOfStream)
        {
            var line = input.ReadLine()!;
            for (var x = 0; x < line.Length; x++)
            {
                map.Add(new Coordinate(x, y), line[x] == '@');
            }
            y++;
        }
        return map;
    }

    protected override int SolvePart1(Dictionary<Coordinate, bool> parsedInput)
    {
        var total = 0;
        foreach (var coordinate in parsedInput.Keys)
        {
            if (parsedInput[coordinate])
            {
                var surrounding = coordinate.GetSurrounding();
                var sum = 0;
                foreach (var surroundingCoordinate in surrounding)
                {
                    if (parsedInput.TryGetValue(surroundingCoordinate, out var value) && value)
                    {
                        sum++;
                    }
                }

                if (sum < 4)
                {
                    total++;
                }
            }
        }
        return total;
    }

    protected override Dictionary<Coordinate, bool> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(Dictionary<Coordinate, bool> parsedInput) => SolvePart1(parsedInput);
}
