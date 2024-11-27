namespace AOC.Days2023.Day05;

public class Map(string sourceName, string destinationName, List<MapRule> mapRules)
{
    public string destinationName = destinationName;
    public string sourceName = sourceName;

    public long MapInput(long input)
    {
        foreach (var mapRule in mapRules)
        {
            var output = mapRule.ApplyRule(input);
            if (output != input)
                return output;
        }

        return input;
    }
}
