namespace AoC_2024.Days;

public class Day3 : Day
{
    public override void Run()
    {
        var input = string.Join(string.Empty, Input);

        // Part 1
        Console.WriteLine(ParseMuls(input));

        // Part 2
        var result = 0;
        var donts = input.Split("don't()");
        var isFirst = true;
        foreach (var dont in donts)
        {
            // First is garuanteed to be a "do()"
            if (isFirst)
            {
                result += ParseMuls(dont);
                isFirst = false;
            }
            else
            {
                // Split on "do()". First garuanteed to be a "don't()" so skip and look for muls
                var dos = dont.Split("do()").Skip(1);
                foreach (var toDo in dos)
                {
                    result += ParseMuls(toDo);
                }
            }
        }

        Console.WriteLine(result);
    }

    private static int ParseMuls(string input)
    {
        var result = 0;
        var muls = input.Split("mul(");
        foreach (var mul in muls)
        {
            var mulArr = mul.Split(")").First().Split(",");
            if (mulArr.Length == 2
                && mulArr[0].Length <= 3
                && mulArr[1].Length <= 3
                && int.TryParse(mulArr[0], out var left)
                && int.TryParse(mulArr[1], out var right))
            {
                result += left * right;
            }
        }

        return result;
    }
}
