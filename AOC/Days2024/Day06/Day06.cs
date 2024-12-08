using AOC.Common;

namespace AOC.Days2024.Day06;

public class Day06 : Day<Map, int, Map, int>
{
    protected override int DayNumber => 6;
    protected override int Year => 2024;

    protected override Map ParseInputPart1(StreamReader input)
    {
        var lineNumber = 0;
        var startingPosition = new Coordinate(0, 0);
        var obstacleMap = new Dictionary<Coordinate, bool>();
        while (!input.EndOfStream)
        {
            var line = input.ReadLine();
            for (var i = 0; i < line!.Length; i++)
            {
                if (line[i] == '^')
                {
                    startingPosition = new(i, lineNumber);
                }
                obstacleMap.Add(new(i, lineNumber), line[i] == '#');
            }
            lineNumber++;
        }
        return new Map(obstacleMap, startingPosition);
    }

    protected override int SolvePart1(Map map) => map.GetVisitedPositions().Count;

    protected override Map ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(Map map)
    {
        return SolvePart1(map);
    }
}
