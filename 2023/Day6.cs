namespace _2023;

public static class Day6
{
    public static string Solve1(string inputPath)
    {
        // input was manually modified to have a time,distance pair on each line
        var input = File.ReadLines(inputPath)
            .Select(x => x.Split(","))
            .Select(x => (long.Parse(x[0]), long.Parse(x[1])));

        return GetResult(input).ToString();
    }

    public static string Solve2(string inputPath)
    {
        var input = File.ReadLines(inputPath).Select(x => long.Parse(x.Split(":")[1].Replace(" ", string.Empty))).ToList();

        return GetResult(new List<(long, long)> { (input[0], input[1]) }).ToString();
    }

    private static int GetResult(IEnumerable<(long, long)> input)
    {
        var result = 1;
        foreach (var (time, recordDistance) in input)
        {
            var possibleWaysToWin = 0;
            for (var i = 0; i < time; i++)
            {
                var distance = i * (time - i);
                if (distance > recordDistance)
                {
                    possibleWaysToWin++;
                }
            }

            if (possibleWaysToWin > 0)
                result *= possibleWaysToWin;
        }

        return result;
    }
}