using System.Text.RegularExpressions;

namespace AOC.Days2023.Day06;

public partial class Day06 : Day<List<Race>, long, Race, long>
{
    protected override int DayNumber => 6;
    protected override int Year => 2023;

    protected override List<Race> ParseInputPart1(StreamReader input)
    {
        var raceTimesString = MultipleSpaceRegex().Replace(input.ReadLine(), " ");
        var raceDistancesString = MultipleSpaceRegex().Replace(input.ReadLine(), " ");
        var raceTimes = raceTimesString.Split(" ")[1..].Select(int.Parse).ToArray();
        var raceDistances = raceDistancesString.Split(" ")[1..].Select(int.Parse).ToArray();
        List<Race> races = [];
        races.AddRange(raceTimes.Select((t, i) => new Race(t, raceDistances[i])));
        return races;
    }

    protected override Race ParseInputPart2(StreamReader input)
    {
        var raceTimeString = MultipleSpaceRegex().Replace(input.ReadLine(), "");
        var raceDistanceString = MultipleSpaceRegex().Replace(input.ReadLine(), "");
        var raceTime = long.Parse(raceTimeString.Replace("Time:", ""));
        var raceDistance = long.Parse(raceDistanceString.Replace("Distance:", ""));
        return new(raceTime, raceDistance);
    }

    protected override long SolvePart1(List<Race> races)
    {
        return races.Aggregate<Race, long>(1, (current, race) => current * race.HowManyWins());
    }

    protected override long SolvePart2(Race race) => race.HowManyWins();

    [GeneratedRegex(" +")]
    private static partial Regex MultipleSpaceRegex();
}
