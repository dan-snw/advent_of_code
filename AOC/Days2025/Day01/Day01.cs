namespace AOC.Days2025.Day01;

public class Day01 : Day<List<int>, int, List<int>, int>
{
    protected override int DayNumber => 1;
    protected override int Year => 2025;

    public override List<int> ParseInputPart1(StreamReader input)
    {
        List<int> turns = [];
        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine();
            turns.Add(inputLine![0] == 'L' ? -int.Parse(inputLine[1..]) : int.Parse(inputLine[1..]));
        }
        return turns;
    }

    protected override int SolvePart1(List<int> parsedInput)
    {
        var timesOnZero = 0;
        var currentPosition = 50;
        foreach (var turn in parsedInput)
        {
            currentPosition = GetNextPosition(currentPosition, turn % 100);
            if (currentPosition == 0)
            {
                timesOnZero++;
            }
        }
        return timesOnZero;
    }

    protected override List<int> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<int> parsedInput)
    {
        var timesPassingThroughZero = 0;
        var currentPosition = 50;
        foreach (var turn in parsedInput)
        {
            timesPassingThroughZero += Math.Abs(turn / 100);
            if (currentPosition != 0 && (turn % 100 + currentPosition is <= 0 or > 99 || turn % 100 + currentPosition is 0))
            {
                timesPassingThroughZero++;
            }

            currentPosition = GetNextPosition(currentPosition, turn % 100);
        }
        return timesPassingThroughZero;
    }

    private static int GetNextPosition(int currentPosition, int turn)
    {
        var nextPosition = currentPosition + turn;
        return nextPosition switch
        {
            > 99 => turn + currentPosition - 100,
            < 0 => 100 + turn + currentPosition,
            _ => turn + currentPosition
        };
    }
}
