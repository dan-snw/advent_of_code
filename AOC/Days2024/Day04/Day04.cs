namespace AOC.Days2024.Day04;

public class Day04 : Day<Wordsearch, int, Wordsearch, int>
{
    protected override int DayNumber => 4;
    protected override int Year => 2024;

    protected override Wordsearch ParseInputPart1(StreamReader input)
    {
        var wordSearch = new Wordsearch();
        var lineNumber = 0;
        while (!input.EndOfStream)
        {
            var line = input.ReadLine();
            for (var i = 0; i < line!.Length; i++)
            {
                wordSearch.Grid.Add(new(i, lineNumber), line[i]);
            }
            lineNumber++;
        }
        return wordSearch;
    }

    protected override int SolvePart1(Wordsearch wordsearch) => wordsearch.SearchWordsearch("XMAS");

    protected override Wordsearch ParseInputPart2(StreamReader input) => ParseInputPart1(input);

    protected override int SolvePart2(Wordsearch wordsearch) =>
        wordsearch.SearchForCrossedWords("MAS");
}
