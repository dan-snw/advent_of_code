namespace AOC.Days2023.Day04;

public class ScratchCard(int id)
{
    private readonly List<int> _onCard = [];
    private readonly HashSet<int> _winners = [];

    public int GetId() => id;

    public void AddWinner(int winner)
    {
        _winners.Add(winner);
    }

    public void AddOnCard(int numberOnCard)
    {
        _onCard.Add(numberOnCard);
    }

    public int GetMatchNumber()
    {
        return _onCard.Count(number => _winners.Contains(number));
    }

    public int ScoreCard() => (int)Math.Pow(2, GetMatchNumber() - 1);
}
