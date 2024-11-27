using AOC.Days2023.Day07;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day07Tests
{
    private const string TestInput =
        "32T3K 765\n" + "T55J5 684\n" + "KK677 28\n" + "KTJJT 220\n" + "QQQJA 483\n";

    private readonly Day07 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(
        TestInput
    );

    [Fact]
    public void Day07_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(6440);
    }

    [Fact]
    public void Day07_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        long result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(5905);
    }
}
