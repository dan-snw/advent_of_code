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
        parsedInput.Sum(TotalInvalidCodesInRangePart1);

    private static long TotalInvalidCodesInRangePart1((long, long) pair)
    {
        var invalidTotal = (long)0;
        var code = pair.Item1;
        while (code <= pair.Item2)
        {
            if (IsInvalidCodePart1(code.ToString()))
            {
                invalidTotal += code;
            }
            code++;
        }
        return invalidTotal;
    }

    private static bool IsInvalidCodePart1(string code) =>
        code[..(code.Length / 2)] == code[(code.Length / 2)..];
    
    private static long TotalInvalidCodesInRangePart2((long, long) pair)
    {
        var invalidTotal = (long)0;
        var code = pair.Item1;
        while (code <= pair.Item2)
        {
            if (IsInvalidCodePart2(code.ToString()))
            {
                invalidTotal += code;
            }
            code++;
        }
        return invalidTotal;
    }
    
    private static bool IsInvalidCodePart2(string code)
    {
        for (var i = 1; i <= code.Length / 2; i++)
        {
            if (CheckInvalidForWindow(code, i))
            {
                return true;
            }
        }

        return false;
    }

    private static bool CheckInvalidForWindow(string code, int windowSize)
    {
        if (code.Length % windowSize != 0)
        {
            return false;
        }
        for (var i = 0; i + 2 * windowSize <= code.Length; i++)
        {
            if (code.Substring(i, windowSize) != code.Substring(i + windowSize, windowSize))
            {
                return false;
            }
        }

        return true;
    }

    protected override List<(long, long)> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override long SolvePart2(List<(long, long)> parsedInput) => 
        parsedInput.Sum(TotalInvalidCodesInRangePart2);
}
