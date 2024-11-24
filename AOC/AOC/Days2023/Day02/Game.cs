namespace AOC.Days2023.Day02;

public class Game(int id)
{
    private readonly List<Show> allShows = [];

    public void AddShow(Show show)
    {
        allShows.Add(show);
    }

    public int GetId() => id;

    public bool CheckPossible(int blue, int red, int green)
    {
        foreach (var show in allShows)
            if (blue < show.GetBlue() || red < show.GetRed() || green < show.GetGreen())
                return false;

        return true;
    }

    public int PowerOfFewestPossibleCubes()
    {
        var blueMin = 0;
        var redMin = 0;
        var greenMin = 0;
        foreach (var show in allShows)
        {
            blueMin = show.GetBlue() > blueMin ? show.GetBlue() : blueMin;
            redMin = show.GetRed() > redMin ? show.GetRed() : redMin;
            greenMin = show.GetGreen() > greenMin ? show.GetGreen() : greenMin;
        }

        return blueMin * redMin * greenMin;
    }
}
