using AOC.Days2023.Day09;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day09Test
{
    private const string TestInput = "0 3 6 9 12 15\n" + "1 3 6 10 15 21\n" + "10 13 16 21 30 45\n";

    private readonly Day09 _day = new();
    private readonly StreamReader _testInputStream = MethodsForTesting.StringToStreamReader(
        TestInput
    );

    [Fact]
    public void ParseAndSolveP1_ReturnsSumNextInSequence()
    {
        var result = _day.ParseAndSolveP1(_testInputStream);
        result.Should().Be(114);
    }

    [Fact]
    public void ParseAndSolveP2_ReturnsSumPreviousInSequence()
    {
        var result = _day.ParseAndSolveP2(_testInputStream);
        result.Should().Be(2);
    }
}
