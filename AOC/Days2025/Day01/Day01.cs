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
            var remainder = turn.Amount % 100;
            if (turn.Direction == LeftRight.Left)
            {
                if (remainder <= currentPosition)
                {
                    currentPosition -= remainder;
                }
                else
                {
                    currentPosition = 100 - (remainder - currentPosition);
                }
            }
            else
            {
                if (currentPosition + remainder <= 99)
                {
                    currentPosition += remainder;
                }
                else
                {
                    currentPosition = remainder - (100 - currentPosition);
                }
            }

            if (currentPosition == 0)
            {
                timesOnZero++;
            }
        }
        return timesOnZero;
    }

    protected override List<Turn> ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(List<Turn> parsedInput) => SolvePart1(parsedInput);

    public record Turn(LeftRight Direction, int Amount);

    public enum LeftRight
    {
        Left,
        Right
    }
}
