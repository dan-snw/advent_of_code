using AOC.Days2024.Day05;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day05Tests
{
    private const string TestInput = "";

    [Fact]
    public void Day05_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day05 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Day05_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day05 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
