using AOC.Days2024.Day07;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day07Tests
{
    private const string TestInput =
        "190: 10 19\n"
        + "3267: 81 40 27\n"
        + "83: 17 5\n"
        + "156: 15 6\n"
        + "7290: 6 8 6 15\n"
        + "161011: 16 10 13\n"
        + "192: 17 8 14\n"
        + "21037: 9 7 18 13\n"
        + "292: 11 6 16 20";

    [Fact]
    public void Day07_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day07 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(3749);
    }

    [Fact]
    public void Day07_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day07 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void Day07_ParseInputPart1_ParsesTestInput()
    {
        // Arrange
        Day07 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        var expected = new List<(int, List<int>)>
        {
            (190, [10, 19]),
            (3267, [81, 40, 27]),
            (83, [17, 5]),
            (156, [15, 6]),
            (7290, [6, 8, 6, 15]),
            (161011, [16, 10, 13]),
            (192, [17, 8, 14]),
            (21037, [9, 7, 18, 13]),
            (292, [11, 6, 16, 20]),
        };

        // Act
        var result = day.ParseInputPart1(testInputStream);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
