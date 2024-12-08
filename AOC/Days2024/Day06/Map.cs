using AOC.Common;

namespace AOC.Days2024.Day06;

public class Map(Dictionary<Coordinate, bool> obstacleMap, Coordinate startingPosition)
{
    private Coordinate StartingPosition { get; } = startingPosition;
    private Dictionary<Coordinate, bool> ObstacleMap { get; } = obstacleMap;

    public HashSet<Coordinate> GetVisitedPositions()
    {
        var direction = CompassPoint.North;
        var position = StartingPosition;
        var visited = new HashSet<Coordinate> { StartingPosition };
        while (ObstacleMap.ContainsKey(position.GetNext(direction)))
        {
            if (ObstacleMap[position.GetNext(direction)])
            {
                direction = Coordinate.RotateDirection90(direction);
            }
            position = position.GetNext(direction);
            visited.Add(position);
        }
        return visited;
    }
}
