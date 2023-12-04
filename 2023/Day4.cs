namespace _2023;

public static class Day4
{
    public static string Solve1(string inputPath)
    {
        using var sr = new StreamReader(inputPath);

        var totalPoints = 0;
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var matchingNumbers = GetMatchingNumbers(line);
            totalPoints += (int)Math.Pow(2, matchingNumbers-1);
        }
        return totalPoints.ToString();
    }

    public static string Solve2(string inputPath)
    {
        var cards = new int[File.ReadLines(inputPath).Count()];
        var cardIndex = 0;

        using var sr = new StreamReader(inputPath);
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            cards[cardIndex]++; // add original card
            var matchingNumbers = GetMatchingNumbers(line);
            for (var i = 0; i < matchingNumbers; i++)
            {
                cards[cardIndex + i + 1] += cards[cardIndex];
            }
            cardIndex++;
        }
        return cards.Sum().ToString();
    }

    private static int GetMatchingNumbers(string line)
    {
        var lineWithoutCardName = line.Split(":")[1].Replace("  ", " ");
        var numbers = lineWithoutCardName.Split("|");
        var winningNumbers = numbers[0].Trim().Split(" ").Select(x => int.Parse(x)).ToList();
        var myNumbers = numbers[1].Trim().Split(" ").Select(x => int.Parse(x)).ToList();
        return myNumbers.Count(x => winningNumbers.Contains(x));
    }
}