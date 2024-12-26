namespace AOC.Days2023.Day05;

/* An almanac is an array of seeds and a list of maps. A map is a list of map rules determining the way
in which a source category becomes a destination category. Each map rule specifies a source range and a change
to input that is required for seed sin that range.
 */

public class Day05 : Day<Almanac, long, Almanac, long>
{
    protected override int DayNumber => 5;
    protected override int Year => 2023;

    private Almanac ParseInputAfterSeeds(long[] seedsArray, StreamReader input)
    {
        List<Map> listOfMaps = [];
        List<MapRule> mapRules = [];
        string source = null;
        string destination = null;
        while (!input.EndOfStream)
        {
            var nextLine = input.ReadLine();
            if (nextLine == "")
            {
                // adds the map to the current list of maps (which is added to the Almanac at construction)
                listOfMaps.Add(new(source, destination, mapRules));
                // reset mapRules, source and destination
                mapRules = [];
                source = null;
                destination = null;
            }
            else if (nextLine.Contains("map"))
            {
                var listName = nextLine.Split(" ")[0].Split("-");
                source = listName[0];
                destination = listName[2];
            }
            else
            {
                mapRules.Add(new(nextLine.Split(" ")));
            }
        }

        // add last one once finished reading file:
        listOfMaps.Add(new(source, destination, mapRules));

        Almanac almanac = new(seedsArray, listOfMaps);
        return almanac;
    }

    public override Almanac ParseInputPart1(StreamReader input)
    {
        var seeds = input.ReadLine().Replace("seeds: ", "").Split(" ");
        var seedsArray = seeds.Select(long.Parse).ToArray();
        // skip empty line after seeds are listed
        input.ReadLine();
        return ParseInputAfterSeeds(seedsArray, input);
    }

    protected override Almanac ParseInputPart2(StreamReader input)
    {
        var seeds = input.ReadLine().Replace("seeds: ", "").Split(" ");
        var seedsAsLongs = seeds.Select(long.Parse).ToArray();
        List<long> seedsAsList = [];
        for (var i = 0; i < seedsAsLongs.Length; i += 2)
        for (var j = seedsAsLongs[i]; j < seedsAsLongs[i] + seedsAsLongs[i + 1]; j++)
            seedsAsList.Add(j);

        // skip empty line after seeds are listed
        input.ReadLine();
        return ParseInputAfterSeeds(seedsAsList.ToArray(), input);
    }

    private long GetMinLocation(Almanac almanac)
    {
        var locations = almanac.ConvertAllSeeds();
        var minLocation = locations[0];
        foreach (var location in locations)
            if (location < minLocation)
                minLocation = location;

        return minLocation;
    }

    protected override long SolvePart1(Almanac almanac) => GetMinLocation(almanac);

    protected override long SolvePart2(Almanac almanac) => GetMinLocation(almanac);
}
