namespace AoC_2024.Days;

public class Day2 : Day
{
    public override void Run()
    {
        // Part 1
        var safeCount = 0;
        foreach (var line in Input)
        {
            var data = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);

            if (data.Length <= 1)
            {
                continue;
            }

            if (IsSafe([.. data]))
            {
                safeCount++;
            }
        }

        Console.WriteLine(safeCount);

        // Part 2
        safeCount = 0;
        foreach (var line in Input)
        {
            var data = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);

            if (data.Length <= 1)
            {
                continue;
            }

            if (IsSafe([.. data]))
            {
                safeCount++;
            }
            else
            {
                for (var i = 0; i < data.Length; i++)
                {
                    var temp = data.ToList();
                    temp.RemoveAt(i);
                    if (IsSafe(temp))
                    {
                        safeCount++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(safeCount);
    }

    private static bool IsSafe(List<string> data)
    {
        var direction = Math.Sign(int.Parse(data[0]) - int.Parse(data[1]));
        var left = 0;
        var right = 1;
        while (left < data.Count - 1 && right < data.Count)
        {
            var rawDiff = int.Parse(data[left]) - int.Parse(data[right]);
            var diff = Math.Abs(rawDiff);
            if (direction != Math.Sign(rawDiff) || diff == 0 || diff > 3)
            {
                return false;
            }
            left++;
            right++;
        }
        return true;
    }
}