using AOC.Days2025.Day01;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day01Tests
{
    private const string TestInput = "L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82";

    [Fact]
    public void Day01_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(3);
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
