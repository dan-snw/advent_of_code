using AOC.Common;

namespace AOC.Days2024.Day06;

public class Day06
    : Day<
        (Dictionary<Coordinate, bool>, Coordinate),
        int,
        (Dictionary<Coordinate, bool>, Coordinate),
        int
    >
{
    protected override int DayNumber => 6;
    protected override int Year => 2024;

    protected override (Dictionary<Coordinate, bool>, Coordinate) ParseInputPart1(
        StreamReader input
    )
    {
        var lineNumber = 0;
        var obstacleMap = new Dictionary<Coordinate, bool>();
        var startingCoordinate = new Coordinate(0, 0);
        while (!input.EndOfStream)
        {
            var line = input.ReadLine();
            for (var i = 0; i < line!.Length; i++)
            {
                if (line[i] == '^')
                {
                    startingCoordinate = new(i, lineNumber);
                }
                obstacleMap.Add(new(i, lineNumber), line[i] == '#');
            }
            lineNumber++;
        }
        return (obstacleMap, startingCoordinate);
    }

    protected override int SolvePart1((Dictionary<Coordinate, bool>, Coordinate) parsedInput)
    {
        var map = parsedInput.Item1;
        var position = parsedInput.Item2;
        var direction = CompassPoint.North;
        var visited = new HashSet<Coordinate> { position };
        while (map.ContainsKey(position.GetNext(direction)))
        {
            if (map[position.GetNext(direction)])
            {
                direction = Coordinate.RotateDirection90(direction);
            }
            position = position.GetNext(direction);
            visited.Add(position);
        }
        return visited.Count;
    }

    protected override (Dictionary<Coordinate, bool>, Coordinate) ParseInputPart2(
        StreamReader input
    ) => ParseInputPart1(input);

    protected override int SolvePart2((Dictionary<Coordinate, bool>, Coordinate) parsedInput) =>
        SolvePart1(parsedInput);
}
