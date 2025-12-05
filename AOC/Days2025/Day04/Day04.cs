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

    protected override int SolvePart1(FiniteGrid<bool> grid) => 
        (from coordinate in grid.Coordinates.Keys
            where grid.CheckCoordinateValue(coordinate, true)
            select grid.GetSurroundings(coordinate))
        .Count(surrounding => surrounding.Count(grid.GetValue) < 4);

    protected override FiniteGrid<bool> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(FiniteGrid<bool> grid)
    {
        int? oldCount = null;
        var newCount = 0;
        while (oldCount != newCount)
        {
            oldCount = newCount;
            foreach (var coordinate in from coordinate in grid.Coordinates.Keys
                     where grid.CheckCoordinateValue(coordinate, true)
                     let surrounding = grid.GetSurroundings(coordinate)
                     let countOfSurrounding = surrounding
                         .Count(surroundingCoordinate => grid.CheckCoordinateValue(surroundingCoordinate, true))
                     where countOfSurrounding < 4 select coordinate)
            {
                grid.UpdateValue(coordinate, false);
                newCount++;
            }
        }
        return newCount;
    }
}
