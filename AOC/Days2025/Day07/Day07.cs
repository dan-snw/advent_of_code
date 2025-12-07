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
        var beamEnds = new Dictionary<Coordinate, HashSet<string>>();
        beamEnds.Add(grid.Start!, ["S"]);

        var y = 0;
        while (grid.InGrid(new Coordinate(0, y)))
        {
            beamEnds = GetNextBeamEnds(beamEnds, grid);
            y++;
        }
        
        var total = 0;
        foreach (var point in beamEnds)
        {
            total += point.Value.Count;
        }

        return total;

    }
    
    private Dictionary<Coordinate, HashSet<string>> GetNextBeamEnds(Dictionary<Coordinate, HashSet<string>> currentBeamEnds, FiniteGrid<bool> grid)
    {
        var nextBeamEnds = new Dictionary<Coordinate,  HashSet<string>>();
        foreach (var point in currentBeamEnds)
        {
            if (grid.GetValue(point.Key))
            {
                var leftBelow = point.Key.GetNext(CompassPoint.SouthWest);
                var rightBelow = point.Key.GetNext(CompassPoint.SouthEast);

                if (!nextBeamEnds.ContainsKey(leftBelow))
                {
                    nextBeamEnds.Add(leftBelow, new HashSet<string>());
                }
                foreach (var path in point.Value)
                {
                    nextBeamEnds[leftBelow].Add($"{path}{leftBelow.X}{leftBelow.Y}");
                }
                if (!nextBeamEnds.ContainsKey(rightBelow))
                {
                    nextBeamEnds.Add(rightBelow, new HashSet<string>());
                }
                foreach (var path in point.Value)
                {
                    nextBeamEnds[rightBelow].Add($"{path}{rightBelow.X}{rightBelow.Y}");
                }
            }
            else
            {
                var next = point.Key.GetNext(CompassPoint.South);
                if (!nextBeamEnds.ContainsKey(next))
                {
                    nextBeamEnds.Add(next, new HashSet<string>());
                }
                foreach (var path in point.Value)
                {
                    nextBeamEnds[next].Add($"{path}{next.X}{next.Y}");
                }
            }
        }
        return nextBeamEnds;
    }
    
}
