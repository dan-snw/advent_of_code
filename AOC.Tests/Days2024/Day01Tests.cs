using AOC.Days2024.Day01;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day01Tests
{
    [Fact]
    public void Day01_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        const string testInput = "";
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Day01_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        const string testInput = "";
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
