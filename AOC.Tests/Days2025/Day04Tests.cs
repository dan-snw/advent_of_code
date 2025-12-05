using AOC.Days2025.Day04;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day04Tests
{
    private const string TestInput = 
        "..@@.@@@@.\n" +
        "@@@.@.@.@@\n" + 
        "@@@@@.@.@@\n" +
        "@.@@@@..@.\n" +
        "@@.@@@@.@@\n" +
        ".@@@@@@@.@\n" +
        ".@.@.@.@@@\n" +
        "@.@@@.@@@@\n" +
        ".@@@@@@@@.\n" +
        "@.@.@@@.@.";

    [Fact]
    public void Day04_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day04 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(13);
    }

    [Fact]
    public void Day04_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day04 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(43);
    }
}
