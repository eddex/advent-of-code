namespace _2023;

public static class Day5
{
    public static string Solve1(string inputPath)
    {
        using var sr = new StreamReader(inputPath);
        var seeds = sr.ReadLine().Split(": ")[1].Split(" ").Select(x => long.Parse(x.Trim())).ToList();
        sr.ReadLine(); // skip empty line
        sr.ReadLine(); // skip first title line
        var seedToSoilMap = ReadRanges(sr);
        var soilToFertilizerMap = ReadRanges(sr);
        var fertilizerToWaterMap = ReadRanges(sr);
        var waterToLightMap = ReadRanges(sr);
        var lightToTemperatureMap = ReadRanges(sr);
        var temperatureToHumidityMap = ReadRanges(sr);
        var humidityToLocationMap = ReadRanges(sr);

        var locations = new List<long>();
        foreach (var seed in seeds)
        {
            var soil = Map(seedToSoilMap, seed);
            var fertilizer = Map(soilToFertilizerMap, soil);
            var water = Map(fertilizerToWaterMap, fertilizer);
            var light = Map(waterToLightMap, water);
            var temp = Map(lightToTemperatureMap, light);
            var hum = Map(temperatureToHumidityMap, temp);
            var location = Map(humidityToLocationMap, hum);
            locations.Add(location);
        }

        return locations.Min().ToString();
    }

    public static string Solve2(string inputPath)
    {
        using var sr = new StreamReader(inputPath);
        var seedData = sr.ReadLine().Split(": ")[1].Split(" ").Select(x => long.Parse(x.Trim())).ToList();


        sr.ReadLine(); // skip empty line
        sr.ReadLine(); // skip first title line
        var seedToSoilMap = ReadRanges(sr);
        var soilToFertilizerMap = ReadRanges(sr);
        var fertilizerToWaterMap = ReadRanges(sr);
        var waterToLightMap = ReadRanges(sr);
        var lightToTemperatureMap = ReadRanges(sr);
        var temperatureToHumidityMap = ReadRanges(sr);
        var humidityToLocationMap = ReadRanges(sr);

        var minLocation = long.MaxValue;

        // this is really stupid, took > 1h to process
        for (var i = 0; i < seedData.Count / 2; i++)
        {
            for (var j = 0; j < seedData[i*2+1]; j++)
            {
                var seed = seedData[i*2]+j;
                var soil = Map(seedToSoilMap, seed);
                var fertilizer = Map(soilToFertilizerMap, soil);
                var water = Map(fertilizerToWaterMap, fertilizer);
                var light = Map(waterToLightMap, water);
                var temperature = Map(lightToTemperatureMap, light);
                var humidity = Map(temperatureToHumidityMap, temperature);
                var location = Map(humidityToLocationMap, humidity);
                if (location < minLocation)
                    minLocation = location;
            }
        }

        return minLocation.ToString();
    }

    private static long Map(List<Range> map, long source)
    {
        var range = map.LastOrDefault(x => x.Source <= source);
        if (range == null || source - range.Source > range.Length)
            return source;
        return range.Destination + source - range.Source;
    }

    private static List<Range> ReadRanges(StreamReader sr)
    {
        string line;
        var ranges = new List<Range>();
        do
        {
            line = sr.ReadLine();
            if (line.Length < 3)
                continue;
            var splitLine = line.Split(" ").Select(x => long.Parse(x)).ToList();
            ranges.Add(new Range(splitLine[1], splitLine[0], splitLine[2]));
        } while (line.Trim() != string.Empty && !sr.EndOfStream);

        if (!sr.EndOfStream)
            sr.ReadLine(); // skip title
        return ranges.OrderBy(x => x.Source).ToList();
    }

    private record Range(long Source, long Destination, long Length);
}