using _2023.Helpers;

namespace _2023;

public static class Day8
{
    public static string Solve1(string inputPath)
    {
        var input = File.ReadLines(inputPath);
        var lrPattern = input.First();
        var map = ParseMap(input);

        var currentPosition = "AAA";
        var steps = 0;
        var arrived = false;
        while (!arrived)
        {
            var goLeft = lrPattern[steps % lrPattern.Length] == 'L';
            steps++;
            currentPosition = goLeft ? map[currentPosition].left : map[currentPosition].right;
            if (currentPosition == "ZZZ")
                arrived = true;
        }

        return steps.ToString();
    }

    // solved with the help of: https://www.reddit.com/r/adventofcode/comments/18df7px/comment/kcgwzjo/
    public static string Solve2(string inputPath)
    {
        var input = File.ReadLines(inputPath);
        var lrPattern = input.First();
        var map = ParseMap(input);

        var currentPositions = map.Keys.Where(x => x.EndsWith('A')).ToArray();
        var stepsToFirstZ = new int[currentPositions.Length];

        for (var i = 0; i < currentPositions.Length; i++)
        {
            var steps = 0;
            while (!currentPositions[i].EndsWith('Z'))
            {
                var goLeft = lrPattern[steps % lrPattern.Length] == 'L';
                steps++;
                stepsToFirstZ[i]++;
                currentPositions[i] = goLeft ? map[currentPositions[i]].left : map[currentPositions[i]].right;
            }
        }

        return GFG.lcm_of_array_elements(stepsToFirstZ).ToString();
    }

    private static Dictionary<string, (string left, string right)> ParseMap(IEnumerable<string> input)
    {
        return input.Skip(2).Select(line =>
        {
            var splitLine = line.Split("=");
            var key = splitLine[0].Trim();
            var lr = splitLine[1].Trim().Replace("(", string.Empty).Replace(")", string.Empty).Split(", ");
            return (key, lr[0], lr[1]);
        }).ToDictionary(x => x.key, x => (x.Item2, x.Item3));
    }
}