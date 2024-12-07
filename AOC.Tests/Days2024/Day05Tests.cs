using AOC.Days2024.Day05;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day05Tests
{
    private const string TestInput =
        "47|53\n"
        + "97|13\n"
        + "97|61\n"
        + "97|47\n"
        + "75|29\n"
        + "61|13\n"
        + "75|53\n"
        + "29|13\n"
        + "97|29\n"
        + "53|29\n"
        + "61|53\n"
        + "97|53\n"
        + "61|29\n"
        + "47|13\n"
        + "75|47\n"
        + "97|75\n"
        + "47|61\n"
        + "75|61\n"
        + "47|29\n"
        + "75|13\n"
        + "53|13\n"
        + "\n"
        + "75,47,61,53,29\n"
        + "97,61,53,29,13\n"
        + "75,29,13\n"
        + "75,97,47,61,53\n"
        + "61,13,29\n"
        + "97,13,75,29,47";

    [Fact]
    public void Day05_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day05 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(143);
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
