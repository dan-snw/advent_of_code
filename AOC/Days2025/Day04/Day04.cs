using AOC.Common;

namespace AOC.Days2025.Day04;

public class Day04 : Day<FiniteGrid<bool>, int, FiniteGrid<bool>, int>
{
    protected override int DayNumber => 4;
    protected override int Year => 2025;

    public override FiniteGrid<bool> ParseInputPart1(StreamReader input)
    {
        var map = new FiniteGrid<bool>();
        var y = 0;
        while (!input.EndOfStream)
        {
            var line = input.ReadLine()!;
            for (var x = 0; x < line.Length; x++)
            {
                map.AddCoordinate(new Coordinate(x, y), line[x] == '@');
            }
            y++;
        }
        return map;
    }

    protected override int SolvePart1(FiniteGrid<bool> grid)
    {
        var total = 0;
        foreach (var coordinate in grid.Coordinates.Keys)
        {
            if (grid.CheckCoordinateValue(coordinate, true))
            {
                var surrounding = grid.GetSurroundings(coordinate);
                var sum = 0;
                foreach (var surroundingCoordinate in surrounding)
                {
                    if (grid.GetValue(surroundingCoordinate))
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

    protected override FiniteGrid<bool> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(FiniteGrid<bool> parsedInput) => SolvePart1(parsedInput);
}
