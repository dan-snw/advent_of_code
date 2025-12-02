using AOC.Days2025.Day02;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day02Tests
{
    private const string TestInput = "";

    [Fact]
    public void Day02_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day02 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Day02_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day02 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
