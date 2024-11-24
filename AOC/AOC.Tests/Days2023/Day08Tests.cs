using AOC.Days2023.Day08;
using AOC.Tests.Common;
using FluentAssertions;

namespace AOC.Tests.Days2023;

public class Day08Tests
{
    private const string TestInput1 =
        "RL\n"
        + "\n"
        + "AAA = (BBB, CCC)\n"
        + "BBB = (DDD, EEE)\n"
        + "CCC = (ZZZ, GGG)\n"
        + "DDD = (DDD, DDD)\n"
        + "EEE = (EEE, EEE)\n"
        + "GGG = (GGG, GGG)\n"
        + "ZZZ = (ZZZ, ZZZ\n";

    private const string TestInput2 =
        "LLR\n" + "\n" + "AAA = (BBB, BBB)\n" + "BBB = (AAA, ZZZ)\n" + "ZZZ = (ZZZ, ZZZ)\n";

    private const string TestInput3 =
        "LR\n"
        + "\n"
        + "11A = (11B, XXX)\n"
        + "11B = (XXX, 11Z)\n"
        + "11Z = (11B, XXX)\n"
        + "22A = (22B, XXX)\n"
        + "22B = (22C, 22C)\n"
        + "22C = (22Z, 22Z)\n"
        + "22Z = (22B, 22B)\n"
        + "XXX = (XXX, XXX)\n";

    private readonly Day08 _day = new();
    private readonly StreamReader _testInputStream1 = MethodsForTesting.StringToStreamReader(
        TestInput1
    );
    private readonly StreamReader _testInputStream2 = MethodsForTesting.StringToStreamReader(
        TestInput2
    );
    private readonly StreamReader _testInputStream3 = MethodsForTesting.StringToStreamReader(
        TestInput3
    );

    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest1()
    {
        var result = _day.ParseAndSolveP1(_testInputStream1);
        result.Should().Be(2);
    }

    [Fact]
    public void Day08_ParseAndSolveP1_ReturnCorrectAnswerTest2()
    {
        var result = _day.ParseAndSolveP1(_testInputStream2);
        result.Should().Be(6);
    }

    [Fact]
    public void CamelMaps_IsPrime_IdentifiesPrimes()
    {
        CamelMaps.IsPrime(100).Should().Be(false);
        CamelMaps.IsPrime(244).Should().Be(false);
        CamelMaps.IsPrime(2).Should().Be(true);
        CamelMaps.IsPrime(9).Should().Be(false);
        CamelMaps.IsPrime(32).Should().Be(false);
    }

    [Fact]
    public void CamelMaps_CalcPrimeFactors_IdentifiesPrimeFactors()
    {
        var fifteen = CamelMaps.CalcPrimeFactors(15);
        fifteen[3].Should().Be(1);
        fifteen[5].Should().Be(1);
        fifteen.Keys.Should().NotContain(1);
        var oneHundred = CamelMaps.CalcPrimeFactors(100);
        oneHundred[2].Should().Be(2);
        oneHundred[5].Should().Be(2);
        oneHundred.Keys.Should().NotContain(3);
        var two = CamelMaps.CalcPrimeFactors(2);
        two[2].Should().Be(1);
        var three = CamelMaps.CalcPrimeFactors(3);
        three[3].Should().Be(1);
    }

    [Fact]
    public void CamelMaps_CalcLCM_GetsLCMOf23()
    {
        List<long> testMultiples = [2, 3];
        var lcm = CamelMaps.CalcLCM(testMultiples);
        lcm.Should().Be(6);
    }

    [Fact]
    public void CamelMaps_CalcLCM_GetsLCMOf61015()
    {
        List<long> testMultiples = [6, 10, 15];
        var lcm = CamelMaps.CalcLCM(testMultiples);
        lcm.Should().Be(30);
    }

    [Fact]
    public void CamelMaps_CartesianProduct_GetsRightNumberOfProducts()
    {
        IEnumerable<string> list1 = ["aa", "bb", "cc"];
        IEnumerable<string> list2 = ["xx", "yy", "zz"];
        IEnumerable<string> list3 = ["11", "22", "33"];
        IEnumerable<IEnumerable<string>> test = [list1, list2, list3];
        var result = CamelMaps.CartesianProduct(test);
        result.Count().Should().Be(27);
    }

    [Fact]
    public void Day08_ParseAndSolveP2_ReturnCorrectAnswer()
    {
        var result = _day.ParseAndSolveP2(_testInputStream3);
        result.Should().Be(6);
    }
}
