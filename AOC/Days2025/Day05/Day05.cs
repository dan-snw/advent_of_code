namespace AOC.Days2025.Day05;

public class Day05 : Day<Inventory, int, HashSet<(ulong Lower, ulong Upper)>, ulong>
{
    protected override int DayNumber => 5;
    protected override int Year => 2025;

    public override Inventory ParseInputPart1(StreamReader input)
    {
        var inventory = new Inventory([], []);
        
        while (true)
        {
            var line = input.ReadLine()!;
            if (!line.Contains('-'))
            {
                break;
            }
            var ranges = line!.Split('-').Select(ulong.Parse).ToList()!;
            inventory.Ranges.Add((ranges[0], ranges[1]));
        }
        
        while (!input.EndOfStream)
        {
            var line = input.ReadLine()!;
            inventory.Ingredients.Add(ulong.Parse(line)); 
        }
        return inventory;
    }

    protected override int SolvePart1(Inventory inventory) => inventory.Ingredients
        .Count(ingredient => inventory.Ranges.Any(range =>
            InRange(ingredient, range.Lower, range.Upper) 
            ));

    private static bool InRange(ulong number, ulong lower, ulong upper) => number >= lower && number <= upper;

    protected override HashSet<(ulong Lower, ulong Upper)> ParseInputPart2(StreamReader input)
    {
        var ranges = new HashSet<(ulong Lower, ulong Upper)>();
        while (true)
        {
            var line = input.ReadLine()!;
            if (!line.Contains('-'))
            {
                break;
            }
            var upperLower = line!.Split('-').Select(ulong.Parse).ToList()!;
            var range = (upperLower[0], upperLower[1]);    
            ranges = AddNewRange(ranges, range);
        }
        return ranges;
    }

    private HashSet<(ulong Lower, ulong Upper)> AddNewRange(HashSet<(ulong Lower, ulong Upper)> inventoryRanges, (ulong, ulong) newRange)
    {
        var overlappingRanges = new HashSet<(ulong Lower, ulong Upper)>();
        foreach (var range in inventoryRanges.ToList())
        {
            if (Overlap(range, newRange))
            {
                overlappingRanges.Add(range);
            }
        }

        foreach (var range in overlappingRanges)
        {
            inventoryRanges.Remove(range);
        }
        
        if (overlappingRanges.Count == 0)
        {
            inventoryRanges.Add(newRange);
        }
        else
        {
            overlappingRanges.Add(newRange);
            inventoryRanges.Add(GetOverlap(overlappingRanges));
        }
        
        return inventoryRanges;
    }

    private (ulong Lower, ulong Upper) GetOverlap(HashSet<(ulong Lower, ulong Upper)> overlappingRanges)
    {
        var lower = ulong.MaxValue;
        var upper = ulong.MinValue;
        foreach (var range in overlappingRanges)
        {
            if (range.Lower < lower)
            {
                lower = range.Lower;
            }
            if (range.Upper > upper)
            {
                upper = range.Upper;
            }
        }
        return (lower, upper);
    }


    protected override ulong SolvePart2(HashSet<(ulong Lower, ulong Upper)> ranges)
    {
        var total = (ulong)0;
        foreach (var range in ranges)
        {
            total += range.Upper - range.Lower + 1;
        }

        return total;
    }
    
    private bool Overlap((ulong Lower, ulong Upper) first, (ulong Lower, ulong Upper) second) =>
        InRange(first.Lower, second) 
        || InRange(first.Upper, second)
        || InRange(second.Lower, first)
        || InRange(second.Upper, first);
    
    private bool InRange(ulong number, (ulong Lower, ulong Upper) second) =>
        number >= second.Lower && number <= second.Upper;
    
    private (ulong Lower, ulong Upper) CreateOverlap((ulong Lower, ulong Upper) first, (ulong Lower, ulong Upper) second) =>
        (Math.Min(first.Lower, second.Lower), Math.Max(first.Upper, second.Upper));
}

public record Inventory(HashSet<(ulong Lower, ulong Upper)> Ranges, HashSet<ulong> Ingredients);