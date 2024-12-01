using AOC.Days2023.Day02;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day02Tests
{
    private const string TestInput =
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\n"
        + "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\n"
        + "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\n"
        + "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\n"
        + "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

    private readonly Day02 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(
        TestInput
    );

    [Fact]
    public void Day02_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(8);
    }

    [Fact]
    public void Day02_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(2286);
    }
}
