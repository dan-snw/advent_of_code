using AOC.Days2025.Day07;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day07Tests
{
    private const string TestInput =
        ".......S.......\n" +
        "...............\n" +
        ".......^.......\n" +
        "...............\n" +
        "......^.^......\n" +
        "...............\n" +
        ".....^.^.^.....\n" +
        "...............\n" +
        "....^.^...^....\n" +
        "...............\n" +
        "...^.^...^.^...\n" +
        "...............\n" +
        "..^...^.....^..\n" +
        "...............\n" +
        ".^.^.^.^.^...^.\n" +
        "...............";

    [Fact]
    public void Day07_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day07 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(21);
    }

    [Fact]
    public void Day07_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day07 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
