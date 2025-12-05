namespace AOC.Days2025.Day03;

public class Day03 : Day<List<List<int>>, long, List<List<int>>, long>
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

    protected override long SolvePart1(List<List<int>> parsedInput) => 
        (from bank in parsedInput 
            let firstDigit = GetHighestValueIndex(bank, 0, bank.Count - 1) 
            let secondDigit = GetHighestValueIndex(bank, firstDigit.Index + 1)
            select long.Parse($"{firstDigit.Value}{secondDigit.Value}"))
        .Sum();

    private ValueIndex GetHighestValueIndex(List<int> list, int start, int? end = null)
    {
        var valueIndex = new ValueIndex
        {
            Value = 0,
            Index = start - 1
        };
        
        for (var i = start; i < (end ?? list.Count); i++)
        {
            if (list[i] <= valueIndex.Value) continue;
            valueIndex.Value = list[i];
            valueIndex.Index = i;
        }
        return valueIndex;
    }
        

    protected override List<List<int>> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override long SolvePart2(List<List<int>> parsedInput)
    {
        var sum = (long)0;
        foreach (var bank in parsedInput)
        {
            var battery = "";
            
            var valueIndex = new ValueIndex
            {
                Value = 0,
                Index = -1
            };
            
            for (var i = 11; i >= 0; i--)
            {
                valueIndex = GetHighestValueIndex(bank, valueIndex.Index + 1, bank.Count - i);
                battery = $"{battery}{valueIndex.Value}";
            }
            sum += long.Parse(battery);
        }
        return sum;
    }
}

public record ValueIndex
{
    public int Value { get; set; }
    public int Index { get; set; }
}
