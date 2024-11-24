namespace AOC;

public interface IDay
{
    public void Complete();
}

public abstract class Day<TIn1, TOut1, TIn2, TOut2> : IDay
{
    protected abstract int DayNumber { get; }
    protected abstract int Year { get; }

    public void Complete()
    {
        Console.WriteLine($"Solutions for day {DayNumber}, {Year}.");
        Console.WriteLine();
        CompletePart1();
        Console.WriteLine();
        CompletePart2();
    }

    protected abstract TIn1 ParseInputPart1(StreamReader input);
    protected abstract TOut1 SolvePart1(TIn1 input);
    protected abstract TIn2 ParseInputPart2(StreamReader input);
    protected abstract TOut2 SolvePart2(TIn2 input);

    private static void PrintSolutionP1(TOut1 part1Solution)
    {
        Console.WriteLine("Part 1:");
        Console.WriteLine(part1Solution);
    }

    private static void PrintSolutionP2(TOut2 part2Solution)
    {
        Console.WriteLine("Part 2:");
        Console.WriteLine(part2Solution);
    }

    private TOut1 ParseAndSolveP1(StreamReader input) => SolvePart1(ParseInputPart1(input));

    private TOut2 ParseAndSolveP2(StreamReader input) => SolvePart2(ParseInputPart2(input));

    private StreamReader GetInput() => new($"Inputs/{Year}/Day{DayNumber:00}.txt");

    private void CompletePart1() => PrintSolutionP1(ParseAndSolveP1(GetInput()));

    private void CompletePart2() => PrintSolutionP2(ParseAndSolveP2(GetInput()));
}
