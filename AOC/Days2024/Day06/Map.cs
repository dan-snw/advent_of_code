using AOC.Common;

namespace AOC.Days2024.Day06;

public class Map(Dictionary<Coordinate, bool> obstacleMap, Coordinate startingLocation)
{
    private Position StartingPosition { get; } = new(startingLocation, CompassPoint.North);
    private Dictionary<Coordinate, bool> ObstacleMap { get; } = obstacleMap;

    public HashSet<Coordinate> GetVisitedPositions()
    {
        var current = StartingPosition;
        var visited = new HashSet<Coordinate>();
        while (MapContainsPosition(current))
        {
            visited.Add(current.Location);
            current = PositionAheadIsObstacle(current)
                ? current.TurnRight()
                : current.PositionAhead();
        }
        return visited;
    }

    private bool PositionAheadIsObstacle(Position current) =>
        MapContainsPosition(current.PositionAhead())
        && ObstacleMap[current.PositionAhead().Location];

    private bool MapContainsPosition(Position position) =>
        ObstacleMap.ContainsKey(position.Location);
}

internal static class RecordExtensions
{
    internal static Position TurnRight(this Position position) =>
        position with
        {
            Direction = Coordinate.RotateDirection90(position.Direction),
        };
}
