using System.Security.Principal;
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
        int count = 0;
        for (var i = 0; i < 1000; i++)
        {
            foreach (var coordinate in grid.Coordinates.Keys)
            {
                if (grid.CheckCoordinateValue(coordinate, true))
                {
                    var surrounding = grid.GetSurroundings(coordinate);
                    var countOfSurrounding = 0;
                    foreach (var surroundingCoordinate in surrounding)
                    {
                        if (grid.CheckCoordinateValue(surroundingCoordinate, true))
                        {
                            countOfSurrounding++;
                        }
                    }

                    if (countOfSurrounding < 4)
                    {
                        grid.UpdateValue(coordinate, false);
                        count++;
                    }
                        
                }
            }
        }
        return count;
    }
}
