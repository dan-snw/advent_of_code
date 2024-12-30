using AOC.Common;
using FluentAssertions;

namespace AOC.Tests.Common;

public class CombinationsTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(4, 16)]
    public void GetCombinations_GivenTwoCharacters_ReturnsAllPossibleCombinations(
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

    [Theory]
    [InlineData(new[] { 1, 2 }, 1)]
    [InlineData(new[] { 1, 5, 2 }, 3)]
    public void GetCombinations_GivenVarylingListLenghts_GetsCombinations(
        int[] ints,
        int expectedCount
    )
    {
        // Act
        var combinations = ints.GetCombinations();

        // Assert
        combinations.Count.Should().Be(expectedCount);
    }
}
