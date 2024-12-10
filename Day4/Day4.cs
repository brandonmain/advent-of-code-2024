using AoC_2024.Utilities;
using static AoC_2024.Utilities.Utilities;

namespace AoC_2024.Days;

public class Day4 : Day
{
    public override void Run()
    {
        var rowLen = Input.Length;
        var colLen = Input[0].Length;

        // Part 1
        var result = 0;
        for (var i = 0; i < rowLen; i++)
        {
            for (var j = 0; j < colLen; j++)
            {
                if (Input[i][j] == 'X')
                {
                    var strings = new List<string>();
                    // Build list in all 8 directions then check for XMAS
                    foreach (var d in Directions)
                    {
                        strings.Add(BuildStringInDir(i, j, d, rowLen, colLen));
                    }
                    foreach (var s in strings)
                    {
                        if (s.Equals("XMAS"))
                        {
                            result++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(result);

        // Part 2
        result = 0;
        for (var i = 0; i < rowLen; i++)
        {
            for (var j = 0; j < colLen; j++)
            {
                if (Input[i][j] == 'A')
                {
                    var leftDiagToFind = new HashSet<char>() { 'M', 'S' };
                    var rightDiagToFind = leftDiagToFind.ToHashSet();
                    var bottomLeft = GetNextCoordinate(coord: new(i, j), direction: Direction.BottomLeft);
                    var topRight = GetNextCoordinate(coord: new(i, j), direction: Direction.TopRight);

                    // Check for bottom left to top right diag
                    if (IsInGrid(bottomLeft, rowLen, colLen)
                        && leftDiagToFind.Remove(Input[bottomLeft.Row][bottomLeft.Col])
                        && IsInGrid(topRight, rowLen, colLen)
                        && leftDiagToFind.Remove(Input[topRight.Row][topRight.Col]))
                    {
                        var bottomRight = GetNextCoordinate(coord: new(i, j), direction: Direction.BottomRight);
                        var topLeft = GetNextCoordinate(coord: new(i, j), direction: Direction.TopLeft);
                        // Check for bottom right to top left diag
                        if (IsInGrid(bottomRight, rowLen, colLen)
                            && rightDiagToFind.Remove(Input[bottomRight.Row][bottomRight.Col])
                            && IsInGrid(topLeft, rowLen, colLen)
                            && rightDiagToFind.Remove(Input[topLeft.Row][topLeft.Col]))
                        {
                            result++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(result);
    }

    private string BuildStringInDir(int row, int col, Direction dir, int rowLen, int colLen)
    {
        var result = "X";
        for (var i = 0; i < 3; i++)
        {
            var nextCoord = GetNextCoordinate(coord: new(row, col), dir);
            if (IsInGrid(nextCoord, rowLen, colLen))
            {
                result += Input[nextCoord.Row][nextCoord.Col];
            }
            row = nextCoord.Row;
            col = nextCoord.Col;
        }
        return result;
    }
}
