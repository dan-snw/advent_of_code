using AOC.Days2025.Day02;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2025;

public class Day02Tests
{
    private const string TestInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224," + 
                                     "1698522-1698528,446443-446449,38593856-38593862,565653-565659," + 
                                     "824824821-824824827,2121212118-2121212124";

    [Fact]
    public void Day02_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day02 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(1227775554);
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
        result.Should().Be(0);
    }
}
