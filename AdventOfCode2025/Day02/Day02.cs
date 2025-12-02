namespace AdventOfCode2025.Day02;

public class Day02
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText("");
    }
    
    public long Part1()
    {
        var ranges = _input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("-"))
            .Select(x => (x[0], x[1]));

        var sum = 0L;
        foreach (var range in ranges)
        {
            var elements = EnumerableRangeLong(long.Parse(range.Item1), long.Parse(range.Item2) - long.Parse(range.Item1) + 1)
                .Select(x => x.ToString());
            
            var numbersWithLength = elements.Where(x => x.Length % 2 == 0)
                .Select(x => new { HalfLength = x.Length / 2, Number = x });
            sum += numbersWithLength.Where(x => x.Number[..x.HalfLength] == x.Number[x.HalfLength..]).Select(x => long.Parse(x.Number)).Sum();
            
            
        }
        return sum;
    }
    
    public long Part2()
    {
        var ranges = _input.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split("-"))
            .Select(x => (x[0], x[1]));

        var sum = 0L;
        foreach (var range in ranges)
        {
            var elements = EnumerableRangeLong(long.Parse(range.Item1), long.Parse(range.Item2) - long.Parse(range.Item1) + 1)
                .Select(x => x.ToString());
            
            var numbersWithLength = elements
                .Select(x => new { HalfLength = x.Length / 2, Number = x });

            foreach (var number in numbersWithLength)
            {
                for (var i = 1; i <= number.HalfLength; i++)
                {
                    var chunks = number.Number.Chunk(i).Select(x => long.Parse(x));
                    var isRepeating = chunks.Distinct().Count() == 1;
                    if (!isRepeating) continue;
                    
                    sum += long.Parse(number.Number);
                    break;
                }
            }
        }
        return sum;
    }

    private static IEnumerable<long> EnumerableRangeLong(long start, long count)
    {
        var end = start + count;

        while (start < end)
        {
            yield return start;
            start++;
        }
    }
}