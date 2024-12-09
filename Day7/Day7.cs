namespace AoC_2024.Days;

public sealed class Day7 : Day
{
    public override void Run()
    {
        // Part 1
        Console.WriteLine(GetCalibrationsResult());

        // Part 2
        Console.WriteLine(GetCalibrationsResult(isIncludeOr: true));
    }

    private long GetCalibrationsResult(bool isIncludeOr = false)
    {
        long result = 0;
        foreach (var line in Input)
        {
            var values = line.Split(":");
            var target = long.Parse(values[0]);
            var nodes = values[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var results = new List<long>();
            foreach (var n in nodes)
            {
                if (results.Count == 0)
                {
                    results.Add(n);
                    continue;
                }
                var resultsToAdd = new List<long>();
                foreach (var res in results)
                {
                    var add = res + n;
                    var mul = res * n;
                    if (add <= target)
                    {
                        resultsToAdd.Add(add);
                    }
                    if (mul <= target)
                    {
                        resultsToAdd.Add(mul);
                    }
                    if(isIncludeOr)
                    {
                        var concat = long.Parse(res.ToString() + n.ToString());
                        if (concat <= target)
                        {
                            resultsToAdd.Add(concat);
                        }
                    }
                }
                results = resultsToAdd;
            }
            var match = results.FirstOrDefault(x => x == target);
            result += match;
        }
        return result;
    }
}