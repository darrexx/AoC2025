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
            sum += int.Parse(largestFirst.Item1.ToString() + largestSecond.Item1.ToString());
        }
        
        return sum;
    }
}