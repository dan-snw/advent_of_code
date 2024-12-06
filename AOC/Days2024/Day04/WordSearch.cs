using AOC.Common;

namespace AOC.Days2024.Day04;

public class Wordsearch
{
    public Dictionary<Coordinate, char> Grid = new();

    public int SearchWordsearch(string word) =>
        Grid.Keys.Sum(coordinate => CountWordsFromCoordinate(coordinate, word));

    private int CountWordsFromCoordinate(Coordinate coordinate, string word)
    {
        if (!CheckCoordinateForLetter(coordinate, word[0]))
        {
            return 0;
        }
        var allDirections = Enum.GetValues(typeof(CompassPoint)).Cast<CompassPoint>();
        return allDirections.Sum(direction => SearchFromCoordinate(coordinate, word, direction) ? 1 : 0);
    }

    private bool SearchFromCoordinate(Coordinate coordinate, string word, CompassPoint direction)
    {
        var nextLetter = coordinate.GetNext(direction);
        for (var i = 0; i < word.Length - 1; i++)
        {
            if (!CheckCoordinateForLetter(nextLetter, word[i + 1]))
            {
                return false;
            }
            nextLetter = nextLetter.GetNext(direction);
        }
        return true;
    }

    private bool CheckCoordinateForLetter(Coordinate coordinate, char letter)
    {
        var isValidPoint = Grid.TryGetValue(coordinate, out var point);
        return isValidPoint && point == letter;
    }

}
