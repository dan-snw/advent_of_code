using AOC.Days2025.Day06;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day06Tests
{
    private const string TestInput =
        "123 328  51 64 \n" +
        "45 64  387 23 \n" +
        "6 98  215 314\n" +
        "*   +   *   + ";

    [Fact]
    public void Day06_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day06 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(4277556);
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
        result.Should().Be(0);
    }
}
