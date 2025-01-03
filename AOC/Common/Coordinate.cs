namespace AOC.Common;

public enum CompassPoint
{
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest,
    West,
    NorthWest,
}

public record Position(Coordinate Location, CompassPoint Direction)
{
    public Coordinate Location = Location;
    public CompassPoint Direction = Direction;

    public Position PositionAhead() => this with { Location = Location.GetNext(Direction) };
}

public record Coordinate(int X, int Y)
{
    public int X { get; private init; } = X;
    public int Y { get; private init; } = Y;

    public Coordinate GetNext(CompassPoint direction) =>
        direction switch
        {
            CompassPoint.North => this with { Y = Y - 1 },
            CompassPoint.NorthEast => new(X + 1, Y - 1),
            CompassPoint.East => this with { X = X + 1 },
            CompassPoint.SouthEast => new(X + 1, Y + 1),
            CompassPoint.South => this with { Y = Y + 1 },
            CompassPoint.SouthWest => new(X - 1, Y + 1),
            CompassPoint.West => this with { X = X - 1 },
            CompassPoint.NorthWest => new(X - 1, Y - 1),
            _ => throw new("Compass point does not exist."),
        };

    public Coordinate GetNext(Vector vector) => new(X + vector.X, Y + vector.Y);

    public static CompassPoint RotateDirection90(CompassPoint compassPoint) =>
        (int)compassPoint + 2 <= 7 ? compassPoint + 2 : compassPoint - 6;
}

public record Vector(int X, int Y)
{
    public int X { get; } = X;
    public int Y { get; } = Y;

    public Vector Opposite() => new(-X, -Y);
}
