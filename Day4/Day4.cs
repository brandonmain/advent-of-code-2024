namespace AoC_2024.Days;

public class Day4 : Day
{
    private static (int row, int col)[] Directions => [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 0), (0, 1), (1, -1), (1, 0), (1, 1)];
    
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
                    var bottomLeft = (row: i - 1, col: j - 1);
                    var topRight = (row: i + 1, col: j + 1);
                    
                    // Check for bottom left to top right diag
                    if (IsInGrid(bottomLeft, rowLen, colLen)
                        && leftDiagToFind.Remove(Input[bottomLeft.row][bottomLeft.col])
                        && IsInGrid(topRight, rowLen, colLen)
                        && leftDiagToFind.Remove(Input[topRight.row][topRight.col]))
                    {
                        var bottomRight = (row: i - 1, col: j + 1);
                        var topLeft = (row: i + 1, col: j - 1);
                        // Check for bottom right to top left diag
                        if (IsInGrid(bottomRight, rowLen, colLen)
                            && rightDiagToFind.Remove(Input[bottomRight.row][bottomRight.col])
                            && IsInGrid(topLeft, rowLen, colLen)
                            && rightDiagToFind.Remove(Input[topLeft.row][topLeft.col]))
                        {
                            result++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(result);
    }

    private string BuildStringInDir(int row, int col, (int row, int col) dir, int rowLen, int colLen)
    {
        var result = "X";
        for (var i = 0; i < 3; i++)
        {
            var nextCoord = (row: row + dir.row, col: col + dir.col);
            if (IsInGrid(nextCoord, rowLen, colLen))
            {
                result += Input[nextCoord.row][nextCoord.col];
            }
            row = nextCoord.row;
            col = nextCoord.col;
        }
        return result;
    }

    private static bool IsInGrid((int row, int col) coord, int rowLen, int colLen) => 0 <= coord.row
        && coord.row < rowLen
        && 0 <= coord.col
        && coord.col < colLen;
}
