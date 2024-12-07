namespace AOC.Days2024.Day05;

public class Day05
    : Day<
        (Dictionary<int, HashSet<int>>, List<List<int>>),
        int,
        (Dictionary<int, HashSet<int>>, List<List<int>>),
        int
    >
{
    protected override int DayNumber => 5;
    protected override int Year => 2024;

    protected override (Dictionary<int, HashSet<int>>, List<List<int>>) ParseInputPart1(
        StreamReader input
    )
    {
        var mustComeAfterLookup = new Dictionary<int, HashSet<int>>();
        var nextLine = input.ReadLine();
        while (nextLine != "")
        {
            var numbers = nextLine!.Split("|");
            var key = int.Parse(numbers[1]);
            var numberItMustComeAfter = int.Parse(numbers[0]);
            if (!mustComeAfterLookup.ContainsKey(key))
            {
                mustComeAfterLookup[key] = new HashSet<int>();
            }
            mustComeAfterLookup[key].Add(numberItMustComeAfter);
            nextLine = input.ReadLine();
        }

        var intLists = new List<List<int>>();
        while (!input.EndOfStream)
        {
            intLists.Add(input.ReadLine()!.Split(",").Select(int.Parse).ToList());
        }

        return (mustComeAfterLookup, intLists);
    }

    protected override int SolvePart1((Dictionary<int, HashSet<int>>, List<List<int>>) parsedInput)
    {
        var mustComeAfterLookup = parsedInput.Item1;
        var intLists = parsedInput.Item2;
        var sumMiddle = 0;
        foreach (var list in intLists)
        {
            if (IsInOrder(list, mustComeAfterLookup))
            {
                sumMiddle += MiddleNumber(list);
            }
        }
        return sumMiddle;
    }

    protected override (Dictionary<int, HashSet<int>>, List<List<int>>) ParseInputPart2(
        StreamReader input
    ) => ParseInputPart1(input);

    protected override int SolvePart2((Dictionary<int, HashSet<int>>, List<List<int>>) parsedInput)
    {
        var mustComeAfterLookup = parsedInput.Item1;
        var intLists = parsedInput.Item2;
        var sumMiddle = 0;
        foreach (var list in intLists)
        {
            if (!IsInOrder(list, mustComeAfterLookup))
            {
                var orderedList = Order(list, mustComeAfterLookup);
                sumMiddle += MiddleNumber(orderedList);
            }
        }
        return sumMiddle;
    }

    private bool IsInOrder(List<int> list, Dictionary<int, HashSet<int>> mustComeAfterLookup)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var toLookup = list[i];
            var hasRestrictions = mustComeAfterLookup.TryGetValue(
                toLookup,
                out var mustComeAfterSet
            );
            if (hasRestrictions)
            {
                for (var j = i; j < list.Count; j++)
                {
                    if (mustComeAfterSet!.Contains(list[j]))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private int MiddleNumber(List<int> list) => list[list.Count / 2];

    private List<int> Order(List<int> list, Dictionary<int, HashSet<int>> mustComeAfterLookup)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var toLookup = list[i];
            var hasRestrictions = mustComeAfterLookup.TryGetValue(
                toLookup,
                out var mustComeAfterSet
            );
            if (hasRestrictions)
            {
                for (var j = i; j < list.Count; j++)
                {
                    if (mustComeAfterSet!.Contains(list[j]))
                    {
                        list.Add(list[i]);
                        list.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }
        return list;
    }
}
