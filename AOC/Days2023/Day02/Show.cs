namespace AOC.Days2023.Day02;

public class Show
{
    // Starting assumption is there aren't any shown:
    private int _blue;
    private int _green;
    private int _red;

    public void AddColourInfo(int number, string colour)
    {
        switch (colour)
        {
            case "blue":
                _blue = number;
                break;
            case "red":
                _red = number;
                break;
            case "green":
                _green = number;
                break;
        }
    }

    public int GetBlue() => _blue;

    public int GetRed() => _red;

    public int GetGreen() => _green;
}
