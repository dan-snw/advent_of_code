using AOC.Common;

namespace AOC.Days2025.Day07;

public class Day07 : Day<FiniteGrid<bool>, int, FiniteGrid<bool>, int>
{
    protected override int DayNumber => 7;
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
                if (line[x] == 'S')
                {
                    map.Start = new Coordinate(x, y);
                }
                map.AddCoordinate(new Coordinate(x, y), line[x] == '^');
            }
            y++;
        }

        return map;
    }

    protected override int SolvePart1(FiniteGrid<bool> grid)
    {
        var total = 0;
        var beamEnds = new HashSet<Coordinate>
        {
            grid.Start!
        };

        while (beamEnds.Count > 0)
        {
            total += beamEnds.Count(point => grid.CheckCoordinateValue(point, true));
            beamEnds = GetNextBeamEnds(beamEnds, grid);
        }

        return total;
    }

    private HashSet<Coordinate> GetNextBeamEnds(HashSet<Coordinate> currentBeamEnds, FiniteGrid<bool> grid)
    {
        var nextBeamEnds = new HashSet<Coordinate>();
        foreach (var point in currentBeamEnds)
        {
            if (grid.GetValue(point))
            {
                var leftBelow = point.GetNext(CompassPoint.SouthWest);
                var rightBelow = point.GetNext(CompassPoint.SouthEast);

                if (grid.InGrid(leftBelow))
                {
                    nextBeamEnds.Add(leftBelow);
                }
                if (grid.InGrid(rightBelow))
                {
                    nextBeamEnds.Add(rightBelow);
                }
            }
            else
            {
                var next = point.GetNext(CompassPoint.South);
                if (grid.InGrid(next))
                {
                    nextBeamEnds.Add(next);
                }
            }
        }
        return nextBeamEnds;
    }
    
    protected override FiniteGrid<bool> ParseInputPart2(StreamReader input)
    {
        return ParseInputPart1(input);
    }

    protected override int SolvePart2(FiniteGrid<bool> grid)
    {
        var possiblePaths = new HashSet<string>();
        for (var i = 0; i < 1000000; i++)
        {
            possiblePaths.Add(ChartRandomPath(grid));
        }
        return possiblePaths.Count;
    }

    private string ChartRandomPath(FiniteGrid<bool> grid)
    {
        var position = grid.Start!;
        var visited = "";
        while (grid.InGrid(position))
        {
            visited = $"{visited}{position.X}{position.Y}";
            if (!grid.GetValue(position))
            {
                position = position.GetNext(CompassPoint.South);
            }
            else
            {
                var random = new Random();
                var goLeft = random.NextDouble() >= 0.5;
                position = goLeft
                    ? position.GetNext(CompassPoint.SouthWest)
                    : position.GetNext(CompassPoint.SouthEast);
            }
        }

        return visited;
    }
}
