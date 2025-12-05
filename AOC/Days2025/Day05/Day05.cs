namespace AOC.Days2025.Day05;

public class Day05 : Day<Inventory, int, Inventory, int>
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
            var ranges = line!.Split('-').Select(long.Parse).ToList()!;
            inventory.Ranges.Add((ranges[0], ranges[1]));
        }
        
        while (!input.EndOfStream)
        {
            var line = input.ReadLine()!;
            inventory.Ingredients.Add(long.Parse(line)); 
        }
        return inventory;
    }

    protected override int SolvePart1(Inventory inventory) => inventory.Ingredients
        .Count(ingredient => inventory.Ranges.Any(range =>
            InRange(ingredient, range.Lower, range.Upper) 
            ));

    private static bool InRange(long number, long lower, long upper) => number >= lower && number <= upper;
    
    protected override Inventory ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(Inventory inventory) => SolvePart1(inventory);
}

public record Inventory(HashSet<(long Lower, long Upper)> Ranges, HashSet<long> Ingredients);