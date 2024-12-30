using AOC.Common;

namespace AOC.Days2024.Day08;

public class Day08 : Day<AntennaMap, int, AntennaMap, int>
{
    protected override int DayNumber => 8;
    protected override int Year => 2024;

    public override AntennaMap ParseInputPart1(StreamReader input)
    {
        var lineNumber = 0;
        var antennaLocations = new Dictionary<char, HashSet<Coordinate>>();
        var allLocations = new HashSet<Coordinate>();
        while (!input.EndOfStream)
        {
            var line = input.ReadLine();
            for (var i = 0; i < line!.Length; i++)
            {
                var coordinate = new Coordinate(i, lineNumber);
                var character = line[i];
                allLocations.Add(coordinate);
                if (character == '.')
                {
                    continue;
                }
                antennaLocations.TryAdd(character, []);
                antennaLocations[character].Add(coordinate);
            }
            lineNumber++;
        }
        return new(antennaLocations, allLocations);
    }

    protected override int SolvePart1(AntennaMap antennaMap)
    {
        var antinodeLocations = new HashSet<Coordinate>();
        foreach (var key in antennaMap.AntennaLocations.Keys)
        {
            var coordinates = antennaMap.AntennaLocations[key];
            var tuplesToCheck = coordinates.GetCombinations();
            foreach (var tuple in tuplesToCheck)
            {
                var antinodes = GetAntinodes(antennaMap.AllCoordinates, tuple.Item1, tuple.Item2);
                antinodeLocations.UnionWith(antinodes);
            }
        }
        return antinodeLocations.Count;
    }

    protected override AntennaMap ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(AntennaMap antennaMap)
    {
        var antinodeLocations = new HashSet<Coordinate>();
        foreach (var key in antennaMap.AntennaLocations.Keys)
        {
            var coordinates = antennaMap.AntennaLocations[key];
            var tuplesToCheck = coordinates.GetCombinations();
            foreach (var tuple in tuplesToCheck)
            {
                var antinodes = GetAllAntinodesInLine(
                    antennaMap.AllCoordinates,
                    tuple.Item1,
                    tuple.Item2
                );
                antinodeLocations.UnionWith(antinodes);
            }
        }
        return antinodeLocations.Count;
    }

    public static HashSet<Coordinate> GetAntinodes(
        HashSet<Coordinate> allCoordinates,
        Coordinate coordinate1,
        Coordinate coordinate2
    )
    {
        var antinodes = new HashSet<Coordinate>();

        var vector = new Vector(coordinate2.X - coordinate1.X, coordinate2.Y - coordinate1.Y);

        var antinode1 = GetAntinode(allCoordinates, coordinate1, vector.Opposite());
        var antinode2 = GetAntinode(allCoordinates, coordinate2, vector);

        if (antinode1 is not null)
        {
            antinodes.Add(antinode1);
        }

        if (antinode2 is not null)
        {
            antinodes.Add(antinode2);
        }

        return antinodes;
    }

    private static Coordinate? GetAntinode(
        HashSet<Coordinate> allCoordinates,
        Coordinate coordinate,
        Vector vector
    ) => allCoordinates.Contains(coordinate.GetNext(vector)) ? coordinate.GetNext(vector) : null;

    public static HashSet<Coordinate> GetAllAntinodesInLine(
        HashSet<Coordinate> allCoordinates,
        Coordinate coordinate1,
        Coordinate coordinate2
    )
    {
        var allAntinodes = new HashSet<Coordinate> { coordinate1, coordinate2 };

        var vector = new Vector(coordinate2.X - coordinate1.X, coordinate2.Y - coordinate1.Y);

        var nextAntinodeBehind = GetAntinode(allCoordinates, coordinate1, vector.Opposite());
        while (nextAntinodeBehind is not null)
        {
            allAntinodes.Add(nextAntinodeBehind);
            nextAntinodeBehind = GetAntinode(allCoordinates, nextAntinodeBehind, vector.Opposite());
        }

        var nextAntinodeAhead = GetAntinode(allCoordinates, coordinate2, vector);
        while (nextAntinodeAhead is not null)
        {
            allAntinodes.Add(nextAntinodeAhead);
            nextAntinodeAhead = GetAntinode(allCoordinates, nextAntinodeAhead, vector);
        }

        return allAntinodes;
    }
}

public record AntennaMap(
    Dictionary<char, HashSet<Coordinate>> AntennaLocations,
    HashSet<Coordinate> AllCoordinates
)
{
    public readonly Dictionary<char, HashSet<Coordinate>> AntennaLocations = AntennaLocations;
    public readonly HashSet<Coordinate> AllCoordinates = AllCoordinates;
}
