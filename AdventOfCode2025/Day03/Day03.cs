namespace AdventOfCode2025.Day03;

public class Day03
{
    private readonly string[] _input;

    public Day03()
    {
        _input = File.ReadAllLines("");
    }

    public long Part1()
    {
        var batterieRows = _input.Select(x => x.Select((y, index) => ((int)char.GetNumericValue(y), index)).ToArray()).ToArray();
        var sum = 0;
        foreach (var batteryRow in batterieRows)
        {
            var largestFirst = batteryRow[..^1].MaxBy(x => x.Item1);
            var largestSecond = batteryRow[(largestFirst.index+1)..].MaxBy(x => x.Item1);
            sum +=  largestFirst.Item1*10 + largestSecond.Item1;
        }
        
        return sum;
    }

    public long Part2()
    {
        var batterieRows = _input.Select(x => x.Select((y, index) => ((int)char.GetNumericValue(y), index)).ToArray()).ToArray();
        var sum = 0L;
        foreach (var batteryRow in batterieRows)
        {
            var startingIndex = 0;
            var batteries = 0L;
            for (var i = 11; i >= 0 ; i--)
            {
                var largestFirst = batteryRow[startingIndex..^i].MaxBy(x => x.Item1);
                batteries = batteries*10 + largestFirst.Item1;
                startingIndex = largestFirst.index + 1;
            }
            sum += batteries;
        }

        return sum;
    }
}