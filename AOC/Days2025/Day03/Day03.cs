namespace AOC.Days2025.Day03;

public class Day03 : Day<List<List<int>>, int, List<List<int>>, int>
{
    protected override int DayNumber => 3;
    protected override int Year => 2025;

    public override List<List<int>> ParseInputPart1(StreamReader input)
    {
        var banks = new List<List<int>>();
        while (!input.EndOfStream)
        {
            banks.Add(input.ReadLine()!
                .Select(num => int.Parse(num.ToString()))
                .ToList());
        }
        return banks;
    }

    protected override int SolvePart1(List<List<int>> parsedInput)
    {
        var sum = 0;
        foreach (var bank in parsedInput)
        {
            var highestBattery = (0, 0);
            for(var i = 0; i < bank.Count - 1; i++)
            {
                if (bank[i] <= highestBattery.Item1) continue;
                highestBattery.Item1 = bank[i];
                highestBattery.Item2 = i;
            }
            
            var secondHighestBattery = (0, 0);
            for(var i = highestBattery.Item2 + 1; i < bank.Count; i++)
            {
                if (bank[i] <= secondHighestBattery.Item1) continue;
                secondHighestBattery.Item1 = bank[i];
                secondHighestBattery.Item2 = i;
            }

            sum += int.Parse($"{highestBattery.Item1}{secondHighestBattery.Item1}");
        }
        return sum;
    }

    protected override List<List<int>> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<List<int>> parsedInput) => SolvePart1(parsedInput);
}
