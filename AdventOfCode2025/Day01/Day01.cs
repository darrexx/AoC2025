namespace AdventOfCode2025.Day01;

public class Day01
{
    private readonly string[] _inputLines = File.ReadAllLines("G:\\Dev\\AdventOfCode2025\\AdventOfCode2025\\input.txt");

    public int Part1()
    {
        var start = 50;
        var count = 0;

        foreach (var line in _inputLines)
        {
            var direction = line[0];
            if (direction == 'R')
            {
                start += int.Parse(line[1..]);
            }
            else
            {
                start -= int.Parse(line[1..]);
            }
            if (start % 100 == 0)
            {
                count++;
            }
        }

        return count;
    }

    public int Part2()
    {
        var start = 50;
        var count = 0;

        foreach (var line in _inputLines)
        {
            var direction = line[0];
            var changeBy = direction == 'R' ? 1 : -1;
            for(var i = 0; i < int.Parse(line[1..]); i++)
            {
                start += changeBy;
                if (start % 100 == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }
}