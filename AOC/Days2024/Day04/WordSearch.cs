using AOC.Common;

namespace AOC.Days2024.Day04;

public class Wordsearch
{
    public Dictionary<Coordinate, char> Grid = new();

    public int SearchWordsearch(string word) =>
        Grid.Keys.Sum(coordinate => CountWordsFromCoordinate(coordinate, word));

    public int SearchForCrossedWords(string word) =>
        Grid.Keys.Count(coordinate => SearchForCrossedWordAtCoordinate(coordinate, word));

    private int CountWordsFromCoordinate(Coordinate coordinate, string word)
    {
        if (!CheckCoordinateForLetter(coordinate, word[0]))
        {
            return 0;
        }
        var allDirections = Enum.GetValues(typeof(CompassPoint)).Cast<CompassPoint>();
        return allDirections.Sum(direction =>
            SearchFromCoordinate(coordinate, word, direction) ? 1 : 0
        );
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

    private bool SearchForCrossedWordAtCoordinate(Coordinate coordinate, string word)
    {
        if (word.Length != 3)
        {
            throw new NotImplementedException("Only works when searching for three letter words.");
        }

        if (!CheckCoordinateForLetter(coordinate, word[1]))
        {
            return false;
        }

        if (!Grid.TryGetValue(coordinate.GetNext(CompassPoint.NorthWest), out var topLeft))
        {
            return false;
        }
        ;
        if (!Grid.TryGetValue(coordinate.GetNext(CompassPoint.NorthEast), out var topRight))
        {
            return false;
        }
        ;
        if (!Grid.TryGetValue(coordinate.GetNext(CompassPoint.SouthWest), out var bottomLeft))
        {
            return false;
        }
        ;
        if (!Grid.TryGetValue(coordinate.GetNext(CompassPoint.SouthEast), out var bottomRight))
        {
            return false;
        }
        ;

        if (topLeft == bottomRight)
        {
            return false;
        }

        if (
            topLeft != word[0] && topLeft != word[2]
            || bottomRight != word[0] && bottomRight != word[2]
        )
        {
            return false;
        }

        if (topLeft == topRight && bottomLeft == bottomRight)
        {
            return true;
        }
        if (topLeft == bottomLeft && topRight == bottomRight)
        {
            return true;
        }
        return false;
    }

    private bool CheckCoordinateForLetter(Coordinate coordinate, char letter)
    {
        var isValidPoint = Grid.TryGetValue(coordinate, out var point);
        return isValidPoint && point == letter;
    }
}
