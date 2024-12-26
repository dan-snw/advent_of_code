using AOC.Common;
using FluentAssertions;

namespace AOC.Tests.Common;

public class CombinationsTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(4, 16)]
    public void Day07_GetCombinations_ReturnsAllPossibleCombinations(
        int length,
        int possibleCombinations
    )
    {
        // Act
        var characters = new[] { "+", "*" };
        var result = Combinations.GetCombinations(length, characters);

        // Assert
        result.Count.Should().Be(possibleCombinations);
    }
}
