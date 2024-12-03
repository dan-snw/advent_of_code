using System.Text.RegularExpressions;

namespace AOC.Days2024.Day03;

public class Day03 : Day<List<(int, int)>, int, List<string>, int>
{
    protected override int DayNumber => 3;
    protected override int Year => 2024;

    protected override List<(int, int)>  ParseInputPart1(StreamReader input)
    {
        var rawInputLine = "";
        while (!input.EndOfStream)
        {
            rawInputLine += input.ReadLine();
        }
        const string regexPattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
        var cleanInput = Regex.Matches(rawInputLine!, regexPattern).Select(x => x.ToString().Replace("mul(", "").Replace(")", ""));
        var splitInput = cleanInput.Select(x => x.Split(","));
        return splitInput.Select(array => (int.Parse(array[0]), int.Parse(array[1]))).ToList();
    }

    protected override int SolvePart1(List<(int, int)> multiplicationPairs) => multiplicationPairs.Sum(pair => pair.Item1 * pair.Item2);

    protected override List<string> ParseInputPart2(StreamReader input)
    {
        const string regexPattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)|don't\(\)|do\(\)";
        var rawInputLine = "";
        while (!input.EndOfStream)
        {
            rawInputLine += input.ReadLine();
        }
        var cleanInput = Regex.Matches(rawInputLine!, regexPattern).Select(x => x.ToString());
        return cleanInput.ToList();
    }

    protected override int SolvePart2(List<string> parsedInput)
    {
        var enabled = true;
        var total = 0;
        foreach (var line in parsedInput)
        {
            if (line.StartsWith("mul") & enabled)
            {
                var multipliers = line.Replace("mul(", "").Replace(")", "").Split(",");
                total += int.Parse(multipliers[0]) * int.Parse(multipliers[1]);
            }
            if (line.StartsWith("do("))
            {
                enabled = true;
            }
            if (line.StartsWith("don't"))
            {
                enabled = false;
            }
        }
        return total;
    }
}
