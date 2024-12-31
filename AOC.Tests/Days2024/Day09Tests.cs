using AOC.Days2024.Day09;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day09Tests
{
    private const string TestInput = "2333133121414131402";

    [Fact]
    public void Day09_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day09 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(1928);
    }

    [Fact]
    public void Day09_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day09 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
