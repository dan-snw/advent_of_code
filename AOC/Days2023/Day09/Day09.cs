namespace AOC.Days2023.Day09;

public class Day09 : Day<List<List<int>>, int, List<List<int>>, int>
{
    protected override int DayNumber => 9;
    protected override int Year => 2023;

    protected override List<List<int>> ParseInputPart1(StreamReader input)
    {
        var sequences = new List<List<int>>();
        while (!input.EndOfStream)
            sequences.Add(input.ReadLine().Split(" ").Select(int.Parse).ToList());
        return sequences;
    }

    protected override int SolvePart1(List<List<int>> input)
    {
        return input.Sum(x => GetItemInSequence(x, (seq, y) => seq[^1] + y));
    }

    protected override List<List<int>> ParseInputPart2(StreamReader input) =>
        ParseInputPart1(input);

    protected override int SolvePart2(List<List<int>> input)
    {
        return input.Sum(x => GetItemInSequence(x, (seq, y) => seq[0] - y));
    }

    private static int GetItemInSequence(List<int> sequence, NextItemChooser nextItemChooser)
    {
        if (sequence.All(x => x == 0))
            return 0;
        var differences = new List<int>();
        for (var i = 0; i < sequence.Count - 1; i++)
            differences.Add(sequence[i + 1] - sequence[i]);
        return nextItemChooser(sequence, GetItemInSequence(differences, nextItemChooser));
    }

    private delegate int NextItemChooser(List<int> sequence, int nextItemOfDiffs);
}
