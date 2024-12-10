namespace AoC_2024.Utilities;

public sealed record Coordinate(int Row, int Col)
{
    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.Row + b.Row, a.Col + b.Col);

    public static Coordinate operator -(Coordinate a, Coordinate b) => new(a.Row - b.Row, a.Col - b.Col);
}
