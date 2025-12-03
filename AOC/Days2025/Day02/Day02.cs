namespace AOC.Days2025.Day02;

public class Day02 : Day<List<(long, long)>, long, List<(long, long)>, long>
{
    protected override int DayNumber => 2;
    protected override int Year => 2025;

    public override List<(long, long)> ParseInputPart1(StreamReader input)
    {
        var ranges = new List<(long, long)>();
        while (!input.EndOfStream)
        {
            var pairs = input.ReadLine()!.Split(',');
            ranges = pairs
                .Select(pair => pair.Split('-')
                    .Select(long.Parse)
                    .ToList())
                .Select(test => new ValueTuple<long, long>(test[0], test[1]))
                .ToList();
        }
        return ranges;
    }

    protected override long SolvePart1(List<(long, long)> parsedInput) =>
        parsedInput.Sum(TotalInvalidCodesInRange);

    private static long TotalInvalidCodesInRange((long, long) pair)
    {
        var invalidTotal = (long)0;
        var code = pair.Item1;
        while (code <= pair.Item2)
        {
            if (IsInvalidCodePartOne(code.ToString()))
            {
                invalidTotal += code;
            }
            code++;
        }
        return invalidTotal;
    }

    private static bool IsInvalidCodePartOne(string code) =>
        code[..(code.Length / 2)] == code[(code.Length / 2)..];

    protected override List<(long, long)> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override long SolvePart2(List<(long, long)> parsedInput) => SolvePart1(parsedInput);
}
