namespace AOC.Days2025.Day06;

public class Day06 : Day<MathGrid, ulong, MathGrid, ulong>
{
    protected override int DayNumber => 6;
    protected override int Year => 2025;

    public override MathGrid ParseInputPart1(StreamReader input)
    {
        var numberRows = new List<List<int>>();
        var symbols = new List<MathSymbol>();
        while(!input.EndOfStream)
        {
            var line = input.ReadLine()!;
            if (line.StartsWith("+") || line.StartsWith("*"))
            {
                symbols = line
                    .Split(" ")
                    .Select(s => s.Trim())
                    .Where(s => s != "")
                    .Select(s  => s.Equals("+") ? MathSymbol.Plus : MathSymbol.Times)
                    .ToList();
                break;
            }
            numberRows.Add(line
                .Split(' ')
                .Select(s => s.Trim())
                .Where(s => s != "")
                .Select(int.Parse)
                .ToList());
   
        }
        return new MathGrid(numberRows, symbols);
    }

    protected override ulong SolvePart1(MathGrid parsedInput)
    {
        var total = (ulong)0;
        for (var i = 0; i < parsedInput.NumberRows[0].Count; i++)
        {
            if (parsedInput.Symbols[i] == MathSymbol.Plus)
            {
                var subTotal = (ulong)0;
                foreach (var row in parsedInput.NumberRows)
                {
                    subTotal += (ulong)row[i];
                }

                total += subTotal;
            }
            else
            {
                var subTotal = (ulong)1;
                foreach (var row in parsedInput.NumberRows)
                {
                    subTotal *= (ulong)row[i];
                }

                total += subTotal;
            }
        }

        return total;
    }

    protected override MathGrid ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override ulong SolvePart2(MathGrid parsedInput) => SolvePart1(parsedInput);
}

public record MathGrid(List<List<int>> NumberRows, List<MathSymbol> Symbols);

public enum MathSymbol
{
    Plus,
    Times,
}
