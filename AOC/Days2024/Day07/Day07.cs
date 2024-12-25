namespace AOC.Days2024.Day07;

public class Day07 : Day<List<(long, List<long>)>, long, List<(long, List<long>)>, long>
{
    protected override int DayNumber => 7;
    protected override int Year => 2024;

    public override List<(long, List<long>)> ParseInputPart1(StreamReader input)
    {
        var parsedInput = new List<(long, List<long>)>();
        while (!input.EndOfStream)
        {
            var split = input.ReadLine()!.Split(": ");
            parsedInput.Add(
                (long.Parse(split.First()), split[1].Split(" ").Select(long.Parse).ToList())
            );
        }
        return parsedInput;
    }

    protected override long SolvePart1(List<(long, List<long>)> parsedInput) =>
        parsedInput.Where(l => CanBeMadeTrue(l, ["+", "*"])).Sum(line => line.Item1);

    protected override List<(long, List<long>)> ParseInputPart2(StreamReader input) =>
        ParseInputPart1(input);

    protected override long SolvePart2(List<(long, List<long>)> parsedInput) =>
        SolvePart1(parsedInput);

    private static bool CanBeMadeTrue((long, List<long>) line, string[] characters)
    {
        var combinations = GetCombinations(line.Item2.Count - 1, characters);
        foreach (var combination in combinations)
        {
            var total = line.Item2[0];
            for (var i = 1; i < line.Item2.Count; i++)
            {
                total = ApplyOperation(total, line.Item2[i], combination[i - 1]);
            }
            if (total == line.Item1)
            {
                return true;
            }
        }

        return false;
    }

    private static long ApplyOperation(long value1, long value2, string character) =>
        character switch
        {
            "+" => value1 + value2,
            "*" => value1 * value2,
            _ => throw new NotImplementedException(),
        };

    public static List<string[]> GetCombinations(int length, string[] characters)
    {
        var combinations = new List<string[]>();

        var combinationMax = "";
        for (var i = 0; i < length; i++)
        {
            combinationMax += "1";
        }

        var fromBase = Convert.ToInt32(combinationMax, characters.Length);
        for (var i = 0; i <= fromBase; i++)
        {
            var inBase = Convert.ToString(i, characters.Length).PadLeft(length, '0');
            combinations.Add(inBase.Select(bit => characters[int.Parse(bit.ToString())]).ToArray());
        }

        return combinations;
    }
}
