namespace AOC.Common;

public static class Combinations
{
    public static List<string[]> GetCombinations(int length, string[] characters)
    {
        var combinations = new List<string[]>();

        var possibleCombinations = Math.Pow(characters.Length, length);
        for (var i = 0; i < possibleCombinations; i++)
        {
            var inBase = DecimalToBase(i, characters.Length).PadLeft(length, '0');
            combinations.Add(inBase.Select(bit => characters[int.Parse(bit.ToString())]).ToArray());
        }

        return combinations;
    }

    // https://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net
    private static string DecimalToBase(long decimalNumber, int baseNumber)
    {
        const int bitsInLong = 64;
        const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (baseNumber < 2 || baseNumber > digits.Length)
            throw new NotImplementedException("Base must be >= 2 and <= " + digits.Length);

        if (decimalNumber == 0)
            return "0";

        var index = bitsInLong - 1;
        var currentNumber = Math.Abs(decimalNumber);
        var charArray = new char[bitsInLong];

        while (currentNumber != 0)
        {
            var remainder = (int)(currentNumber % baseNumber);
            charArray[index--] = digits[remainder];
            currentNumber /= baseNumber;
        }

        var result = new string(charArray, index + 1, bitsInLong - index - 1);
        if (decimalNumber < 0)
        {
            result = "-" + result;
        }

        return result;
    }
}
