namespace _2023;

public static class Day1
{
    public static string Solve(string inputPath)
    {
        using var sr = new StreamReader(inputPath);

        var numbers = new List<int>();
        var textNumbers = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            char? first = null;
            char? last = null;

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (char.IsNumber(c))
                    if (first == null)
                        first = last = c;
                    else
                        last = c;
                for (var j = 0; j < textNumbers.Length; j++)
                {
                    if (line.Substring(i, line.Length-i).StartsWith(textNumbers[j]))
                    {
                        c = (j + 1).ToString()[0];
                        if (first == null)
                            first = last = c;
                        else
                            last = c;
                    }
                }
            }
            numbers.Add(int.Parse($"{first}{last}"));
        }
        return numbers.Sum().ToString();
    }
}