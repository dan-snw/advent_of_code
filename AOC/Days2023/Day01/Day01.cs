namespace AOC.Days2023.Day01;

public class Day01 : Day<List<(int, int)>, int, List<(int, int)>, int>
{
    private readonly string[] _wordToNumbers =
    [
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
    ];

    protected override int DayNumber => 1;
    protected override int Year => 2023;

    private static int CalculateCalibrationSum(List<(int, int)> parsedInput)
    {
        var calibrationSum = 0;
        foreach (var digits in parsedInput)
        {
            calibrationSum += digits.Item1 * 10;
            calibrationSum += digits.Item2;
        }

        return calibrationSum;
    }

    public override List<(int, int)> ParseInputPart1(StreamReader input)
    {
        List<(int, int)> calibrationNumbersP1 = [];
        while (!input.EndOfStream)
        {
            DigitsTrackerP1 tracker = new();
            var inputLine = input.ReadLine();
            if (inputLine is null)
                continue;
            foreach (var t in inputLine.Where(char.IsDigit))
                tracker.UpdateDigits(t - '0');
            calibrationNumbersP1.Add((tracker.FirstDigit, tracker.SecondDigit));
        }

        return calibrationNumbersP1;
    }

    protected override int SolvePart1(List<(int, int)> parsedInput) =>
        CalculateCalibrationSum(parsedInput);

    protected override List<(int, int)> ParseInputPart2(StreamReader input)
    {
        List<(int, int)> calibrationNumbersP2 = [];
        while (!input.EndOfStream)
        {
            var inputLine = input.ReadLine();
            if (inputLine is null)
                continue;
            DigitsTrackerP2 digitsTrackerP2 = new();
            for (var i = 0; i < inputLine.Length; i++)
            {
                // Update both parts if it is a single digit:
                if (char.IsDigit(inputLine[i]))
                    digitsTrackerP2.UpdateDigits(inputLine[i] - '0');
                // Update just part 2 if there is a number word match:
                for (var j = 0; j < _wordToNumbers.Length; j++)
                    digitsTrackerP2.CheckStringAndUpdate(i, inputLine, _wordToNumbers[j], j);
            }

            calibrationNumbersP2.Add((digitsTrackerP2.FirstDigit, digitsTrackerP2.SecondDigit));
        }

        return calibrationNumbersP2;
    }

    protected override int SolvePart2(List<(int, int)> parsedInput) =>
        CalculateCalibrationSum(parsedInput);
}
