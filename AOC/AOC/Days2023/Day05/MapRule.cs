namespace AOC.Days2023.Day05;

public class MapRule(IReadOnlyList<string> rangeDetails)
{
    private readonly long _destinationStart = long.Parse(rangeDetails[0]);
    private readonly long _rangeLength = long.Parse(rangeDetails[2]);
    private readonly long _rangeStart = long.Parse(rangeDetails[1]);

    public long ApplyRule(long input)
    {
        var output =
            input >= _rangeStart && input < _rangeStart + _rangeLength
                ? input + _destinationStart - _rangeStart
                : input;
        return output;
    }
}
