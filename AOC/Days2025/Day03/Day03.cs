using System.Transactions;

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

    protected override int SolvePart1(List<List<int>> parsedInput) => 
        (from bank in parsedInput 
            let firstDigit = GetHighestValueIndex(bank, 0, bank.Count - 1) 
            let secondDigit = GetHighestValueIndex(bank, firstDigit.Index + 1)
            select int.Parse($"{firstDigit.Value}{secondDigit.Value}"))
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

    protected override int SolvePart2(List<List<int>> parsedInput) => SolvePart1(parsedInput);
}

public record ValueIndex
{
    public int Value { get; set; }
    public int Index { get; set; }
}
