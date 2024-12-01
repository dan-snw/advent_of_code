using AOC.Days2023.Day06;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day06Tests
{
    private const string TestInput = "Time:      7  15   30\n" + "Distance:  9  40  200";

    private readonly Day06 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(
        TestInput
    );

    [Fact]
    public void Day06_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(288);
    }

    [Fact]
    public void Race_QuadraticEquation_SolvesCorrectly()
    {
        var result = Race.QuadraticEquation(7, 9);
        var roundedResult = (
            (int)Math.Floor(result.Item1 + 1),
            (int)Math.Ceiling(result.Item2 - 1)
        );
        roundedResult.Should().Be((2, 5));
    }

    [Fact]
    public void Day06_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(71503);
    }
}
