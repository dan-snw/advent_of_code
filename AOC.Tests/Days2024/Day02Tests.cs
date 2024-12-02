using AOC.Days2024.Day02;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day02Tests
{
    private const string TestInput =
        "7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9";

    [Fact]
    public void Day02_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day02 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(2);
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
        result.Should().Be(4);
    }
}
