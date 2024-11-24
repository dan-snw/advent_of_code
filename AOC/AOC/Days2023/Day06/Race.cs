namespace AOC.Days2023.Day06;

public class Race(long raceTime, long raceDistance)
{
    public long HowManyWins()
    {
        var boundaries = QuadraticEquation(raceTime, raceDistance);
        // Add 1 and round down for cases where there is a button press that would end in a draw (i.e. where
        // the equation solves to an integer).
        var lower = (int)Math.Floor(boundaries.Item1 + 1);
        var upper = (int)Math.Ceiling(boundaries.Item2 - 1);
        return 1 + upper - lower;
    }

    public static (float, float) QuadraticEquation(long t, long d)
    {
        var lower = (float)((t - Math.Sqrt(t * t - 4 * d)) / 2);
        var upper = (float)((t + Math.Sqrt(t * t - 4 * d)) / 2);
        return (lower, upper);
    }
}
