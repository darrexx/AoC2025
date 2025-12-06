namespace AdventOfCode2025.Day05;

public class Day05
{
    private readonly string[] _input;

    public Day05()
    {
        _input = File.ReadAllLines("");
    }

    public long Part1()
    {
        var freshIngredientRanges = _input.TakeWhile(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split("-").Select(long.Parse).ToList()).ToList();

        var idsToCheck = _input.SkipWhile(x => !string.IsNullOrWhiteSpace(x))
            .Skip(1).Select(long.Parse);

        return idsToCheck.LongCount(id => freshIngredientRanges.Any(range => id >= range[0] && id <= range[1]));
    }

    public long Part2()
    {
        var freshIngredientRanges = _input.TakeWhile(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split("-").Select(long.Parse).ToList()).OrderBy(x => x[0]).ToList();
        for (var i = 0; i < freshIngredientRanges.Count - 1; i++)
        {
            if (freshIngredientRanges[i + 1][0] > freshIngredientRanges[i][1]) continue;

            freshIngredientRanges[i][1] = Math.Max(freshIngredientRanges[i][1], freshIngredientRanges[i + 1][1]);
            freshIngredientRanges.RemoveAt(i + 1);
            i--;
        }

        return freshIngredientRanges.Select(x => x[1] - x[0] + 1).Sum();
    }
}