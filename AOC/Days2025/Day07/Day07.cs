using AOC.Common;

namespace AOC.Days2025.Day07;

public class Day07 : Day<FiniteGrid<bool>, int, FiniteGrid<bool>, ulong>
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

    protected override ulong SolvePart2(FiniteGrid<bool> grid)
    {
        var total = (ulong)1;
        var beamEnds = new Dictionary<Coordinate, ulong>();
        beamEnds.Add(grid.Start!, 1);

        while (beamEnds.Count > 0)
        {
            var nextBeamEnds = GetNextBeamEndsAndCount(beamEnds, grid);
            total += nextBeamEnds.Item1;
            beamEnds = nextBeamEnds.Item2;
        }

        return total;
    }
    
    private (ulong, Dictionary<Coordinate, ulong>) GetNextBeamEndsAndCount(Dictionary<Coordinate, ulong> currentBeamEnds, FiniteGrid<bool> grid)
    {
        var count = (ulong)0;
        var nextBeamEnds = new Dictionary<Coordinate, ulong>();
        foreach (var point in currentBeamEnds)
        {
            if (grid.GetValue(point.Key))
            {
                count += point.Value;
                var leftBelow = point.Key.GetNext(CompassPoint.SouthWest);
                var rightBelow = point.Key.GetNext(CompassPoint.SouthEast);

                if (grid.InGrid(leftBelow))
                {
                    if (nextBeamEnds.ContainsKey(leftBelow))
                    {
                        nextBeamEnds[leftBelow] += point.Value;
                    }

                    else
                    {
                        nextBeamEnds.Add(leftBelow, point.Value);
                    }
                }
                if (grid.InGrid(rightBelow))
                {
                    if (nextBeamEnds.ContainsKey(rightBelow))
                    {
                        nextBeamEnds[rightBelow] += point.Value;
                    }

                    else
                    {
                        nextBeamEnds.Add(rightBelow, point.Value);
                    }
                }
            }
            else
            {
                var next = point.Key.GetNext(CompassPoint.South);
                if (grid.InGrid(next))
                {
                    if (nextBeamEnds.ContainsKey(next))
                    {
                        nextBeamEnds[next] += point.Value;
                    }
                    else
                    {
                        nextBeamEnds.Add(next, point.Value);
                    }
                }
            }
        }
        return (count, nextBeamEnds);
    }
}
