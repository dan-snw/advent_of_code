namespace AOC.Days2025.Day03;

public class Day03 : Day<List<string>, int, List<string>, int>
{
    protected override int DayNumber => 3;
    protected override int Year => 2025;

    public override List<string> ParseInputPart1(StreamReader input)
    {
        var banks = new List<string>();
        while (!input.EndOfStream)
        {
            banks.Add(input.ReadLine()!);
        }
        return banks;
    }

    protected override int SolvePart1(List<string> parsedInput)
    {
        var sum = 0;
        foreach (var bank in parsedInput)
        {
            var highestBattery = (0, 0);
            for(var i = 0; i < bank.Length - 1; i++)
            {
                if (int.Parse(bank[i].ToString()) <= highestBattery.Item1) continue;
                highestBattery.Item1 = int.Parse(bank[i].ToString());
                highestBattery.Item2 = i;
            }
            
            var secondHighestBattery = (0, 0);
            for(var i = highestBattery.Item2 + 1; i < bank.Length; i++)
            {
                if (int.Parse(bank[i].ToString()) <= secondHighestBattery.Item1) continue;
                secondHighestBattery.Item1 = int.Parse(bank[i].ToString());
                secondHighestBattery.Item2 = i;
            }

            sum += int.Parse($"{highestBattery.Item1}{secondHighestBattery.Item1}");
        }
        return sum;
    }

    protected override List<string> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<string> parsedInput) => SolvePart1(parsedInput);
}
