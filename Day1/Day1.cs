namespace AoC_2024.Days;

public class Day1 : Day
{
    public override void Run()
    {
        // Part 1
        var xArr = new List<int>();
        var yArr = new List<int>();
        foreach (var line in Input)
        {
            var data = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
            var x = int.Parse(data[0]);
            xArr.Add(x);
            var y = int.Parse(data[1]);
            yArr.Add(y);
        }

        xArr.Sort();
        yArr.Sort();

        var totalDistance = 0;
        for (int i = 0; i < xArr.Count; i++)
        {
            totalDistance += Math.Abs(xArr[i] - yArr[i]);
        }

        Console.WriteLine(totalDistance);

        // Part 2
        var yDups = new Dictionary<int, int>();
        foreach (var y in yArr)
        {
            if (yDups.TryGetValue(y, out int value))
            {
                yDups[y] = ++value;
            }
            else
            {
                yDups[y] = 1;
            }
        }

        var similiarityScore = 0;
        foreach (var x in xArr)
        {
            if (yDups.TryGetValue(x, out var score))
            {
                similiarityScore += x * score;
            }
        }

        Console.WriteLine(similiarityScore);
    }
}