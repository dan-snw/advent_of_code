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

    protected override int SolvePart1(AntennaMap parsedInput)
    {
        throw new NotImplementedException();
    }

    protected override AntennaMap ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(AntennaMap parsedInput) => SolvePart1(parsedInput);
}

public record AntennaMap(
    Dictionary<char, HashSet<Coordinate>> AntennaLocations,
    HashSet<Coordinate> AllCoordinates
)
{
    public readonly Dictionary<char, HashSet<Coordinate>> AntennaLocations = AntennaLocations;
    public readonly HashSet<Coordinate> AllCoordinates = AllCoordinates;
}
