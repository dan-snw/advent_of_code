namespace AOC.Days2023.Day01;

public class DigitsTrackerP2
{
    private bool _foundFirstDigit;
    public int FirstDigit { get; private set; }
    public int SecondDigit { get; private set; }

    public void CheckStringAndUpdate(
        int index,
        string longString,
        string shortString,
        int intEquivalent
    )
    {
        if (CheckStringMatch(index, shortString, longString))
            UpdateDigits(intEquivalent);
    }

    public void UpdateDigits(int newDigit)
    {
        if (!_foundFirstDigit)
        {
            FirstDigit = newDigit;
            _foundFirstDigit = true;
        }

        SecondDigit = newDigit;
    }

    private static bool CheckStringMatch(int index, string shortString, string longString)
    {
        if (index + shortString.Length > longString.Length)
            return false;
        if (shortString == longString.Substring(index, shortString.Length))
            return true;
        return false;
    }
}
