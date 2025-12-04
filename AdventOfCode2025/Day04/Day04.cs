namespace AdventOfCode2025.Day04;

public class Day04
{
    private readonly string[] _input;

    public Day04()
    {
        _input = File.ReadAllLines("");
    }
    
    public long Part1()
    {
        var count = 0L;
        for (var y = 0; y < _input.Length; y++)
        {
            for (var x = 0; x < _input[y].Length; x++)
            {
                if (_input[y][x] != '@')
                {
                    continue;
                }

                var adjacentPaper = 0;
                for (var compareX = -1; compareX <= 1; compareX++)
                {
                    for (var compareY = -1; compareY <= 1; compareY++)
                    {
                        if (compareX == 0 && compareY == 0)
                        {
                            continue;
                        }
                        
                        var checkX = x + compareX;
                        var checkY = y + compareY;
                        if (checkX < 0 || checkX >= _input[y].Length || checkY < 0 || checkY >= _input.Length)
                        {
                            continue;
                        }

                        if (_input[checkY][checkX] == '@')
                        {
                            adjacentPaper++;
                        }
                    }
                }

                if (adjacentPaper >= 4) continue;
                count++;
            }
        }
        return count;
    }

    public long Part2()
    {
        var count = 0L;
        var oldCount = -1L;
        var input = _input.Select(x => x.ToCharArray()).ToArray();
        while (oldCount != count)
        {
            oldCount = count;
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] != '@')
                    {
                        continue;
                    }

                    var adjacentPaper = 0;
                    for (var compareX = -1; compareX <= 1; compareX++)
                    {
                        for (var compareY = -1; compareY <= 1; compareY++)
                        {
                            if (compareX == 0 && compareY == 0)
                            {
                                continue;
                            }
                        
                            var checkX = x + compareX;
                            var checkY = y + compareY;
                            if (checkX < 0 || checkX >= input[y].Length || checkY < 0 || checkY >= input.Length)
                            {
                                continue;
                            }

                            if (input[checkY][checkX] == '@')
                            {
                                adjacentPaper++;
                            }
                        }
                    }

                    if (adjacentPaper >= 4) continue;
                    input[y][x] = '.';
                    count++;
                }
            }
        }

        return count;
    }
}