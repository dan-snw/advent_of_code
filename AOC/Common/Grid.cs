namespace AOC.Common;

public interface IGrid
{
    public bool InGrid(Coordinate coordinate);
}

public class FiniteGrid<TValue> : IGrid
{
    public Dictionary<Coordinate, TValue> Coordinates = new();
    public Coordinate? Start = null;
    
    public void AddCoordinate(Coordinate coordinate, TValue value) =>
        Coordinates.Add(coordinate, value);
    
    public bool InGrid(Coordinate coordinate) => Coordinates.ContainsKey(coordinate);
    
    public HashSet<Coordinate> GetSurroundings(Coordinate coordinate) => 
        coordinate
            .GetSurrounding()
            .Where(c => Coordinates.ContainsKey(c))
            .ToHashSet();

    public bool CheckCoordinateValue(Coordinate coordinate, TValue value) =>
        Coordinates.ContainsKey(coordinate) && GetValue(coordinate)!.Equals(value);

    public TValue GetValue(Coordinate coordinate) => Coordinates[coordinate];

    public void UpdateValue(Coordinate surroundingCoordinate, TValue value)
    {
        Coordinates[surroundingCoordinate] = value;
    }
}

public class InfiniteGrid : IGrid
{
    public bool InGrid(Coordinate coordinate) => true;
}
