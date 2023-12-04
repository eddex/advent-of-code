namespace _2023;

public static class Day3
{
    public static string Solve1(string inputPath)
    {
        var map = File.ReadLines(inputPath).ToArray();
        var mapHeight = map.Length;
        var mapWidth = map[0].Length;

        var numbersAdjacentToSymbol = new List<int>();
        for (var h = 0; h < mapHeight; h++)
        {
            var number = string.Empty;
            var hasAdjacentSymbol = false;
            for (var w = 0; w < mapWidth; w++)
            {
                var field = map[h][w];
                if (char.IsNumber(field))
                {
                    number += field;
                    hasAdjacentSymbol = hasAdjacentSymbol || HasAdjacentSymbol(h, w, map, mapHeight, mapWidth);
                    if (w == mapWidth-1 && hasAdjacentSymbol)
                    {
                        numbersAdjacentToSymbol.Add(int.Parse(number));
                        number = string.Empty;
                        hasAdjacentSymbol = false;
                    }
                }
                else
                {
                    if (number != string.Empty)
                    {
                        if (hasAdjacentSymbol)
                        {
                            numbersAdjacentToSymbol.Add(int.Parse(number));
                        }
                        number = string.Empty;
                        hasAdjacentSymbol = false;
                    }
                }

            }
        }

        return numbersAdjacentToSymbol.Sum().ToString();
    }

    public static string Solve2(string inputPath)
    {
        return "todo";
    }

    private static bool HasAdjacentSymbol(int h, int w, string[] map, int mapHeight, int mapWidth)
    {
        return
            CheckPositionForSymbol(h - 1, w, map, mapHeight, mapWidth) ||     // top
            CheckPositionForSymbol(h - 1, w - 1, map, mapHeight, mapWidth) || // top left
            CheckPositionForSymbol(h - 1, w + 1, map, mapHeight, mapWidth) || // top right
            CheckPositionForSymbol(h + 1, w, map, mapHeight, mapWidth) ||     // bottom
            CheckPositionForSymbol(h + 1, w - 1, map, mapHeight, mapWidth) || // bottom left
            CheckPositionForSymbol(h + 1, w + 1, map, mapHeight, mapWidth) || // bottom right
            CheckPositionForSymbol(h, w - 1, map, mapHeight, mapWidth) ||     // left
            CheckPositionForSymbol(h, w + 1, map, mapHeight, mapWidth);       // right
    }

    private static bool CheckPositionForSymbol(int h, int w, string[] map, int mapHeight, int mapWidth)
    {
        if (h < 0 || h >= mapHeight || w < 0 || w >= mapWidth)
            return false;
        return IsSymbol(map[h][w]);
    }

    private static bool IsSymbol(char c) => c != '.' && !char.IsNumber(c);
}