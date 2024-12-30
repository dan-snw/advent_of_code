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

    protected override int SolvePart2(AntennaMap parsedInput) => SolvePart1(parsedInput);

    public static HashSet<Coordinate> GetAntinodes(
        HashSet<Coordinate> allCoordinates,
        Coordinate coordinate1,
        Coordinate coordinate2
    )
    {
        var antinodes = new HashSet<Coordinate>();

        var vector = new Vector(coordinate2.X - coordinate1.X, coordinate2.Y - coordinate1.Y);

        var antinode1 = coordinate1.GetNext(vector.Opposite);
        var antinode2 = coordinate2.GetNext(vector);

        if (allCoordinates.Contains(antinode1))
        {
            antinodes.Add(antinode1);
        }

        if (allCoordinates.Contains(antinode2))
        {
            antinodes.Add(antinode2);
        }

        return antinodes;
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
