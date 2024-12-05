namespace AoC_2024.Days;

public class Day5 : Day
{
    public override void Run()
    {
        var result = 0;

        // Part 1
        var pageToNextPages = new Dictionary<int, HashSet<int>>();
        var i = 0;
        for (; i < Input.Length && Input[i].Length > 0; i++)
        {
            var rule = Input[i].Split('|');
            var x = int.Parse(rule[0]);
            var y = int.Parse(rule[1]);
            if (!pageToNextPages.TryGetValue(x, out var _))
            {
                pageToNextPages[x] = [];
            }
            pageToNextPages[x].Add(y);
        }

        var updatesIndex = i + 1; // Skip index for empty row
        for (i = updatesIndex; i < Input.Length; i++)
        {
            var updates = Input[i].Split(",").Select(int.Parse).ToArray();

            if (IsCorrectOrder(updates, pageToNextPages))
            {
                var mid = updates[updates.Length / 2];
                result += mid;
            }
        }

        Console.WriteLine(result);

        // Part 2
        result = 0;
        i = updatesIndex;
        var pageComparer = new PageComparer(pageToNextPages);
        for (; i < Input.Length; i++)
        {
            var updates = Input[i].Split(",").Select(int.Parse).ToArray();

            if (!IsCorrectOrder(updates, pageToNextPages))
            {
                var sortedUpdates = updates.Order(pageComparer).ToArray();
                var mid = sortedUpdates[sortedUpdates.Length / 2];
                result += mid;
            }
        }

        Console.WriteLine(result);
    }

    private static bool IsCorrectOrder(int[] updates, Dictionary<int, HashSet<int>> pageToNextPages)
    {
        var isCorrect = true;
        var seen = new HashSet<int>();
        foreach (var page in updates)
        {
            if (pageToNextPages.TryGetValue(page, out var pagesThatMustNotPreceed)
                && seen.Any(pagesThatMustNotPreceed.Contains))
            {
                isCorrect = false;
            }
            seen.Add(page);
        }
        return isCorrect;
    }

    private class PageComparer(Dictionary<int, HashSet<int>> pageToNextPages) : Comparer<int>
    {
        private readonly Dictionary<int, HashSet<int>> _pageToNextPages = pageToNextPages;

        public override int Compare(int x, int y)
        {
            if (_pageToNextPages.TryGetValue(x, out var pagesThatMustNotPreceedX)
                && pagesThatMustNotPreceedX.Contains(y))
            {
                return -1;
            }
            if (_pageToNextPages.TryGetValue(y, out var pagesThatMustNotPreceedY)
                && pagesThatMustNotPreceedY.Contains(x))
            {
                return 1;
            }
            return 0;
        }
    }
}
