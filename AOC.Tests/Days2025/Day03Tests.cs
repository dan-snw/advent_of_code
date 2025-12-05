using AOC.Days2025.Day03;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day03Tests
{
    private const string TestInput = 
        "987654321111111\n" + 
        "811111111111119\n" +
        "234234234234278\n" +
        "818181911112111";

    [Fact]
    public void Day03_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(357);
    }

    [Fact]
    public void Day03_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day03 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
