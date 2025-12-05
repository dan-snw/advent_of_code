using AOC.Days2025.Day05;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day05Tests
{
    private const string TestInput =
        "3-5\n" +
        "10-14\n" +
        "16-20\n" +
        "12-18\n" +

        "1\n" +
        "5\n" +
        "8\n" +
        "11\n" +
        "17\n" +
        "32\n";

    [Fact]
    public void Day05_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day05 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(3);
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
        result.Should().Be(14);
    }
}
