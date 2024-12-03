using AOC.Days2024.Day03;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day03Tests
{
    private const string TestInput = "";

    [Fact]
    public void Day03_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Day03_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
