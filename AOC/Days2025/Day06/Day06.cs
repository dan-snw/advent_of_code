namespace AOC.Days2025.Day06;

public class Day06 : Day<MathGrid, ulong, MathGrid2, ulong>
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

    protected override MathGrid2 ParseInputPart2(StreamReader input)
    {
        var lines = new List<string>();
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
                    .Select(s => s.Equals("+") ? MathSymbol.Plus : MathSymbol.Times)
                    .Reverse()
                    .ToList();
                break;
            }

            lines.Add(line);
        }

        var lineLength = lines[0].Length;
        var i = lineLength - 1;
        var numbers = new List<List<int>>();
        var numbersToAdd = new List<int>();
        while (i >= 0)
        {
            var allSpaces = true;
            var number = "";
            foreach (var line in lines)
            {
                if (line[i] != ' ')
                {
                    allSpaces = false;
                    number += line[i];
                }
            }

            if (allSpaces)
            {
                numbers.Add(numbersToAdd);
                numbersToAdd = [];
            }
            else
            {
                numbersToAdd.Add(int.Parse(number));
            }

            if (i == 0)
            {
                numbers.Add(numbersToAdd);
            }
            i--;
        }
        return new MathGrid2(numbers, symbols);
    }

    protected override ulong SolvePart2(MathGrid2 parsedInput)
    {
        var total = (ulong)0;
        for (var i = 0; i < parsedInput.Symbols.Count; i++)
        {
            if (parsedInput.Symbols[i] == MathSymbol.Plus)
            {
                var subTotal = (ulong)0;
                foreach (var number in parsedInput.Numbers[i])
                {
                    subTotal += (ulong)number;
                }

                total += subTotal;
            }
            else
            {
                var subTotal = (ulong)1;
                foreach (var number in parsedInput.Numbers[i])
                {
                    subTotal *= (ulong)number;
                }

                total += subTotal;
            }
        }

        return total;
    }
}

public record MathGrid(List<List<int>> NumberRows, List<MathSymbol> Symbols);

public record MathGrid2(List<List<int>> Numbers, List<MathSymbol> Symbols);

public enum MathSymbol
{
    Plus,
    Times,
}
