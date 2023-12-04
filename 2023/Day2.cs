namespace _2023;

public static class Day2
{
    private const string red = "red";
    private const string green = "green";
    private const string blue = "blue";
    public static string Solve1(string inputPath)
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;
        var games = ParseGames(inputPath);
        return games
            .Where(g =>
                !(g.CubeSets.Any(s => s.ContainsKey(red) && s[red] > maxRed) ||
                g.CubeSets.Any(s => s.ContainsKey(green) && s[green] > maxGreen) ||
                g.CubeSets.Any(s => s.ContainsKey(blue) && s[blue] > maxBlue)))
            .Select(g => g.Id)
            .Sum()
            .ToString();
    }

    public static string Solve2(string inputPath)
    {
        var games = ParseGames(inputPath);
        var gameMinPower = 0;
        foreach (var game in games)
        {
            var maxRed = 0;
            var maxGreen = 0;
            var maxBlue = 0;
            foreach (var cubeSet in game.CubeSets)
            {
                if (cubeSet.ContainsKey(red) && cubeSet[red] > maxRed)
                    maxRed = cubeSet[red];
                if (cubeSet.ContainsKey(green) && cubeSet[green] > maxGreen)
                    maxGreen = cubeSet[green];
                if (cubeSet.ContainsKey(blue) && cubeSet[blue] > maxBlue)
                    maxBlue = cubeSet[blue];
            }
            gameMinPower += maxRed * maxBlue * maxGreen;
        }

        return gameMinPower.ToString();
    }

    private record Game
    {
        public int Id { get; set; }
        public List<Dictionary<string, int>> CubeSets { get; set; }
    }

    private static IEnumerable<Game> ParseGames(string inputPath)
    {
        using var sr = new StreamReader(inputPath);
        var games = new List<Game>();
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            games.Add(new Game
            {
                Id = int.Parse(line.Split(":")[0].Split(" ")[1]),
                CubeSets = GetCubeSets(line)
            });
        }
        return games;
    }

    private static List<Dictionary<string, int>> GetCubeSets(string line)
    {
        var cubeSetsRaw = line.Split(": ")[1].Split(";").Select(x => x.Trim());
        var cubeSets = new List<Dictionary<string, int>>();
        foreach (var cubeSetRaw in cubeSetsRaw)
        {
            var cubeSet = new Dictionary<string, int>();
            var cubes = cubeSetRaw.Split(",").Select(x => x.Trim());
            foreach (var cube in cubes)
            {
                var cubeInfo = cube.Split(" ");
                cubeSet.Add(cubeInfo[1], int.Parse(cubeInfo[0]));
            }
            cubeSets.Add(cubeSet);
        }
        return cubeSets;
    }
}