using AOC.Days2023.Day05;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day05Tests
{
    private const string TestInput =
        "seeds: 79 14 55 13\n"
        + "\n"
        + "seed-to-soil map:\n"
        + "50 98 2\n"
        + "52 50 48\n"
        + "\n"
        + "soil-to-fertilizer map:\n"
        + "0 15 37\n"
        + "37 52 2\n"
        + "39 0 15\n"
        + "\n"
        + "fertilizer-to-water map:\n"
        + "49 53 8\n"
        + "0 11 42\n"
        + "42 0 7\n"
        + "57 7 4\n"
        + "\n"
        + "water-to-light map:\n"
        + "88 18 7\n"
        + "18 25 70\n"
        + "\n"
        + "light-to-temperature map:\n"
        + "45 77 23\n"
        + "81 45 19\n"
        + "68 64 13\n"
        + "\n"
        + "temperature-to-humidity map:\n"
        + "0 69 1\n"
        + "1 0 69\n"
        + "\n"
        + "humidity-to-location map:\n"
        + "60 56 37\n"
        + "56 93 4\n";

    private readonly Day05 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(
        TestInput
    );

    [Fact]
    public void Day05_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(35);
    }

    [Fact]
    public void Day05_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(46);
    }
}
