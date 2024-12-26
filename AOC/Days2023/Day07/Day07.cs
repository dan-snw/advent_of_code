namespace AOC.Days2023.Day07;

public class Day07 : Day<List<Hand>, int, List<JokersHand>, int>
{
    protected override int DayNumber => 7;
    protected override int Year => 2023;

    private static List<T> ParseInput<T>(StreamReader input, Func<string, int, T> handCreator)
        where T : Hand
    {
        List<T> hands = [];
        while (!input.EndOfStream)
        {
            string[] handAndBid = input.ReadLine().Split(" ");
            // Store as base 15 so that comparisons later are easier
            hands.Add(handCreator(handAndBid[0], int.Parse(handAndBid[1])));
        }

        return hands;
    }

    public override List<Hand> ParseInputPart1(StreamReader input) =>
        ParseInput(input, Hand.CreateJacksHand);

    protected override List<JokersHand> ParseInputPart2(StreamReader input)
    {
        return ParseInput(input, (s, i) => new JokersHand(s, i));
    }

    private int RankAndSum(List<Hand> hands)
    {
        hands.Sort();
        var answerPart1 = 0;
        var handRank = 1;
        foreach (var hand in hands)
        {
            answerPart1 += hand.Bid * handRank;
            handRank++;
        }

        return answerPart1;
    }

    protected override int SolvePart1(List<Hand> hands) => RankAndSum(hands);

    protected override int SolvePart2(List<JokersHand> hands) =>
        RankAndSum(hands.Cast<Hand>().ToList());
}
