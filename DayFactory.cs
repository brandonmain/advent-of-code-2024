using AoC_2024.Days;

namespace AoC_2024;

public static class DayFactory
{
    public static Day GetAndInitDay(string day)
    {
        Day obj = day?.Trim() switch
        {
            "1" => new Day1(),
            "2" => new Day2(),
            "3" => new Day3(),
            "4" => new Day4(),
            "5" => new Day5(),
            "6" => new Day6(),
            "7" => new Day7(),
            _ => throw new NotImplementedException(),
        };

        obj.Init(folder: $"Day{day}", "input.txt");
        return obj;
    }
}
