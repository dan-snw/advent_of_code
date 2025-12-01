using AOC.Days2025.Day01;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day01Tests
{
    private const string TestInput = "";

    [Fact]
    public void Day01_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

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
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
