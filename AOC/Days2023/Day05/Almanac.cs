namespace AOC.Days2023.Day05;

public class Almanac(long[] seeds, List<Map> listOfMaps)
{
    private long ConvertSeedToLocation(long seed) =>
        listOfMaps.Aggregate(seed, (current, map) => map.MapInput(current));

    public long[] ConvertAllSeeds() => seeds.Select(ConvertSeedToLocation).ToArray();
}
