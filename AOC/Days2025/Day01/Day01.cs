namespace AOC.Days2025.Day01;

public class Day01 : Day<List<Day01.Turn>, int, List<Day01.Turn>, int>
{
    protected override int DayNumber => 1;
    protected override int Year => 2025;

    public override List<Turn> ParseInputPart1(StreamReader input)
    {
        List<Turn> turns = [];
        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine();
            var direction = inputLine![0] == 'L' ? LeftRight.Left : LeftRight.Right;
            var amount = int.Parse(inputLine[1..]);
            turns.Add(new Turn(direction, amount));
        }

        return turns;
    }

    protected override int SolvePart1(List<Turn> parsedInput)
    {
        var timesOnZero = 0;
        var currentPosition = 50;
        foreach (var turn in parsedInput)
        {
            currentPosition = GetNextPosition(currentPosition, turn);
            if (currentPosition == 0)
            {
                timesOnZero++;
            }
        }
        return timesOnZero;
    }

    protected override List<Turn> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<Turn> parsedInput)
    {
        var timesPassingThroughZero = 0;
        var currentPosition = 50;
        foreach (var turn in parsedInput)
        {
            timesPassingThroughZero += TimesPassingThroughZero(currentPosition, turn);
            currentPosition = GetNextPosition(currentPosition, turn);
        }
        return timesPassingThroughZero;
    }

    private static int GetNextPosition(int currentPosition, Turn turn)
    {
        var amountToTurnRight = turn.Direction == LeftRight.Right ? turn.Amount % 100 : 100 - turn.Amount % 100;
        return currentPosition + amountToTurnRight <= 99
            ? currentPosition + amountToTurnRight
            : currentPosition - (100 - amountToTurnRight);
    }
    
    private static int TimesPassingThroughZero(int currentPosition, Turn turn)
    {
        var times = turn.Amount / 100;
        var nextPosition = GetNextPosition(currentPosition, turn);
        if (currentPosition == 0 && turn.Amount != 100)
        {
            return times;
        }
        if((nextPosition == 0 && currentPosition != 0)
           || (turn.Direction == LeftRight.Left && nextPosition >= currentPosition)
           || (turn.Direction == LeftRight.Right && nextPosition <= currentPosition))
        {
            return times + 1;
        }
        return times;
    }
    
    public record Turn(LeftRight Direction, int Amount);

    public enum LeftRight
    {
        Left,
        Right
    }
}
