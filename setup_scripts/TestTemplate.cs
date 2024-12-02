using AOC.DaysYEAR_NUMBER.CLASS_NAME;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.DaysYEAR_NUMBER;

public class CLASS_NAMETests
{
    private const string TestInput = "";

    [Fact]
    public void CLASS_NAME_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        CLASS_NAME day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CLASS_NAME_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        CLASS_NAME day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}
