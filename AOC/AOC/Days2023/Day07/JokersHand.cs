namespace AOC.Days2023.Day07;

public class JokersHand(string cards, int bid) : Hand(cards, bid)
{
    protected override string AssignCharsForFaceCards(string cards)
    {
        // Now J is lowest so assign to 1 rather than B
        var replacedCards = Cards
            .Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "1")
            .Replace("T", "A");
        return replacedCards;
    }

    protected override HandType AssignHandType()
    {
        var cardCount = CountCards();
        var jokersNumber = cardCount['J'];
        // get rid of jokers from the dictionary before getting the hand type
        cardCount.Remove('J');
        var baseHandType = CheckMaxHandType(cardCount);
        for (var i = 0; i < jokersNumber; i++)
            baseHandType = ApplyJoker(baseHandType);
        return baseHandType;
    }

    private static HandType ApplyJoker(HandType oldHandType)
    {
        return oldHandType switch
        {
            HandType.HighCard => HandType.Pair,
            HandType.Pair => HandType.ThreeOfAKind,
            HandType.TwoPair => HandType.FullHouse,
            HandType.ThreeOfAKind => HandType.FourOfAKind,
            HandType.FullHouse => HandType.FourOfAKind,
            _ => HandType.FiveOfAKind,
        };
    }
}
