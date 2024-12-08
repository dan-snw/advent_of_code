using AOC.Days2024.Day06;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day06Tests
{
    private const string TestInput =
        "....#.....\n"
        + ".........#\n"
        + "..........\n"
        + "..#.......\n"
        + ".......#..\n"
        + "..........\n"
        + ".#..^.....\n"
        + "........#.\n"
        + "#.........\n"
        + "......#...";

    [Fact]
    public void Day06_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day06 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(41);
    }

    [Fact]
    public void Day06_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day06 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(6);
    }
}
