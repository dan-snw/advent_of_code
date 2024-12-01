namespace AOC.Days2023.Day01;

public class DigitsTrackerP1
{
    private bool _foundFirstDigit;
    public int FirstDigit { get; private set; }
    public int SecondDigit { get; private set; }

    public void UpdateDigits(int newDigit)
    {
        if (!_foundFirstDigit)
        {
            FirstDigit = newDigit;
            _foundFirstDigit = true;
        }

        SecondDigit = newDigit;
    }
}
