namespace AOC;

public static class DayFactory
{
    public static IDay GetDay(int year, int day)
    {
        var dayType = Type.GetType($"AOC.Days{year}.Day{day:00}.Day{day:00}");

        if (dayType == null)
            throw new($"Day {day:00} not found");

        if (!typeof(IDay).IsAssignableFrom(dayType))
            throw new InvalidOperationException("Invalid day type");

        return (IDay)Activator.CreateInstance(dayType)!;
    }
}
