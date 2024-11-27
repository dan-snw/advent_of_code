using AOC.Days2023.Day01;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day01Tests
{
    [Fact]
    public void Day01_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        const string testInput = "1abc2\n" + "pqr3stu8vwx\n" + "a1b2c3d4e5f\n" + "treb7uchet";
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);
        // Act
        var result = day.ParseAndSolveP1(testInputStream);
        // Assert
        result.Should().Be(142);
    }

    [Fact]
    public void Day01_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day01 day = new();
        const string testInput =
            "two1nine\n"
            + "eightwothree\n"
            + "abcone2threexyz\n"
            + "xtwone3four\n"
            + "4nineeightseven2\n"
            + "zoneight234\n"
            + "7pqrstsixteen";
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);
        // Act
        var result = day.ParseAndSolveP2(testInputStream);
        // Assert
        result.Should().Be(281);
    }
}
