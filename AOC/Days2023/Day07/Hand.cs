namespace AOC.Days2023.Day07;

public abstract class Hand : IComparable<Hand>
{
    private readonly int _handValue;
    protected readonly string Cards;

    protected Hand(string cards, int bid)
    {
        Cards = cards;
        Bid = bid;
        _handValue = CalculateHandValue();
    }

    public int Bid { get; }

    public int CompareTo(Hand otherHand) => _handValue.CompareTo(otherHand._handValue);

    public static Hand CreateJacksHand(string cards, int bid) => new JacksHand(cards, bid);

    public static Hand CreateJokersHand(string cards, int bid) => new JokersHand(cards, bid);

    private int CalculateHandValue()
    {
        var cardsBase14 = AssignCharsForFaceCards(Cards);
        // Prepend hand type as a letter so get a single integer representing hand value.
        var handType = (char)AssignHandType();
        cardsBase14 = handType + cardsBase14;
        // just convert to base 16 since there's a built-in method
        var handValue = Convert.ToInt32(cardsBase14, 16);
        return handValue;
    }

    protected virtual string AssignCharsForFaceCards(string cards)
    {
        var replacedCards = cards
            .Replace("A", "E")
            .Replace("K", "D")
            .Replace("Q", "C")
            .Replace("J", "B")
            .Replace("T", "A");
        return replacedCards;
    }

    protected virtual HandType AssignHandType() => CheckMaxHandType(CountCards());

    protected static HandType CheckMaxHandType(Dictionary<char, int> countedCards)
    {
        // Need to track pairs and three of a kind until all the way through the duplicates list to make
        // sure there aren't any full houses.
        var containsPair = false;
        var containsTwoPair = false;
        var containsThreeOfAKind = false;
        foreach (var count in countedCards.Values)
            switch (count)
            {
                case 5:
                    return HandType.FiveOfAKind;
                case 4:
                    return HandType.FourOfAKind;
                case 3:
                    containsThreeOfAKind = true;
                    break;
                case 2:
                    if (containsPair)
                        containsTwoPair = true;
                    containsPair = true;
                    break;
            }

        if (containsPair && containsThreeOfAKind)
            return HandType.FullHouse;
        if (containsThreeOfAKind)
            return HandType.ThreeOfAKind;
        if (containsTwoPair)
            return HandType.TwoPair;

        if (containsPair)
            return HandType.Pair;

        return HandType.HighCard;
    }

    protected Dictionary<char, int> CountCards()
    {
        var countedCards = new Dictionary<char, int>
        {
            { '2', 0 },
            { '3', 0 },
            { '4', 0 },
            { '5', 0 },
            { '6', 0 },
            { '7', 0 },
            { '8', 0 },
            { '9', 0 },
            { 'T', 0 },
            { 'J', 0 },
            { 'Q', 0 },
            { 'K', 0 },
            { 'A', 0 },
        };
        foreach (var card in Cards)
            countedCards[card]++;
        return countedCards;
    }

    protected enum HandType
    {
        FiveOfAKind = '7',
        FourOfAKind = '6',
        FullHouse = '5',
        ThreeOfAKind = '4',
        TwoPair = '3',
        Pair = '2',
        HighCard = '1',
    }
}
