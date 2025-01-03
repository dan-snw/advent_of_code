using AOC.Days2024.Day03;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day03Tests
{

    [Fact]
    public void Day03_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        const string testInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(161);
    }

    [Fact]
    public void Day03_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        const string testInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(testInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(48);
    }
}
