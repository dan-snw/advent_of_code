using System.Text.RegularExpressions;

namespace AOC.Days2023.Day08;

public class Day08 : Day<CamelMaps, int, CamelMaps, long>
{
    // only want to keep numbers, capital letters, commas and equals sign
    private static readonly Regex irrelevantCharacters = new(@"[^A-Z,=0-9]");
    protected override int DayNumber => 8;
    protected override int Year => 2023;

    private static CamelMaps ParseInput(StreamReader input)
    {
        var lRSequence = input.ReadLine();
        // skip line which is empty:
        input.ReadLine();
        Dictionary<string, (string, string)> mappings = new();
        while (!input.EndOfStream)
        {
            string[] mapping = irrelevantCharacters
                .Replace(input.ReadLine(), "")
                .Replace("=", ",")
                .Split(",");
            mappings.Add(mapping[0], (mapping[1], mapping[2]));
        }

        CamelMaps camelMaps = new(lRSequence, mappings);
        return camelMaps;
    }

    public override CamelMaps ParseInputPart1(StreamReader input) => ParseInput(input);

    protected override CamelMaps ParseInputPart2(StreamReader input) => ParseInput(input);

    protected override int SolvePart1(CamelMaps camelMaps) => camelMaps.FollowMaps();

    protected override long SolvePart2(CamelMaps camelMaps) => camelMaps.FollowAsIfGhost();
}
