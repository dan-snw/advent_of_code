using AOC.Common;
using AOC.Days2024.Day08;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2024;

public class Day08Tests
{
    private const string TestInput =
        "............\n"
        + "........0...\n"
        + ".....0......\n"
        + ".......0....\n"
        + "....0.......\n"
        + "......A.....\n"
        + "............\n"
        + "............\n"
        + "........A...\n"
        + ".........A..\n"
        + "............\n"
        + "............";

    [Fact]
    public void Day08_ParseInputPart1_StoresAllCoordinates()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseInputPart1(testInputStream);

        // Assert
        result.AllCoordinates.Count.Should().Be(144);
    }

    [Fact]
    public void Day08_ParseInputPart1_StoresAllLocationsForACharacter()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseInputPart1(testInputStream);

        // Assert
        result.AntennaLocations.Count.Should().Be(3);
        result.AntennaLocations['A'].Should().Contain(new Coordinate(6, 5));
        result.AntennaLocations['A'].Should().Contain(new Coordinate(8, 8));
        result.AntennaLocations['A'].Should().Contain(new Coordinate(9, 9));
    }

    [Fact]
    public void Day08_ParseInputPart1_StoresAllCharacters()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseInputPart1(testInputStream);

        // Assert
        result.AntennaLocations.Count.Should().Be(3);
    }

    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswer()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP1(testInputStream);

        // Assert
        result.Should().Be(14);
    }

    [Fact]
    public void Day08_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        // Arrange
        Day08 day = new();
        var testInputStream = MethodsForTesting.StringToStreamReader(TestInput);

        // Act
        var result = day.ParseAndSolveP2(testInputStream);

        // Assert
        result.Should().Be(0);
    }
}