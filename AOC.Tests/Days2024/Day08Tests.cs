using AOC.Days2024.Day08;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day08Tests
{
    private const string TestInput =
        "............\n"
        + "........0...\n"
        + ".....0......\n"
        + ".......0....\n"
        + "....0.......\n"
        + "......A.....\n"
        + "............\n"
        + "............\n"
        + "........A...\n"
        + ".........A..\n"
        + "............\n"
        + "............";

    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(14);
    }

    [Fact]
    public void Day08_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
