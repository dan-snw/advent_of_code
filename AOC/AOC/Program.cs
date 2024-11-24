using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;

namespace AOC;

internal abstract class Program
{
    public static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        var runOptions = new RunOptions();
        configuration.GetSection("Run").Bind(runOptions);

        DayFactory.GetDay(runOptions.Year, runOptions.Day).Complete();
    }

    private class RunOptions
    {
        [UsedImplicitly]
        public int Year { get; set; }

        [UsedImplicitly]
        public int Day { get; set; }
    }
}
