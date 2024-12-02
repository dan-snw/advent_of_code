namespace AOC.Days2024.Day02;

public class Day02 : Day<List<Report>, int, List<Report>, int>
{
    protected override int DayNumber => 2;
    protected override int Year => 2024;

    protected override List<Report> ParseInputPart1(StreamReader input)
    {
        var records = new List<Report>();
        while (!input.EndOfStream)
        {
            records.Add(new(input.ReadLine()!.Split(" ").Select(int.Parse).ToArray()));
        }
        return records;
    }

    protected override int SolvePart1(List<Report> reports) => reports.Count(x => x.IsSafe());

    protected override List<Report> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<Report> parsedInput) => SolvePart1(parsedInput);
}
