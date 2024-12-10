namespace AoC_2024.Utilities;

public static class Utilities
{
    public static Direction[] Directions => Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray();

    public static bool IsInGrid(Coordinate coord, int rowLen, int colLen) => 0 <= coord.Row && coord.Row < rowLen && 0 <= coord.Col && coord.Col < colLen;

    public static Coordinate GetNextCoordinate(Coordinate coord, Direction direction) => direction switch
    {
        Direction.Up => coord with { Row = coord.Row - 1 },
        Direction.Down => coord with { Row = coord.Row + 1 },
        Direction.Left => coord with { Col = coord.Col - 1 },
        Direction.Right => coord with { Col = coord.Col + 1 },
        Direction.TopLeft => new(coord.Row - 1, coord.Col - 1),
        Direction.TopRight => new(coord.Row - 1, coord.Col + 1),
        Direction.BottomLeft => new(coord.Row + 1, coord.Col - 1),
        Direction.BottomRight => new(coord.Row + 1, coord.Col + 1),
        _ => throw new NotImplementedException(),
    };

    public static Coordinate GetPrevCoordinate(Coordinate coord, Direction direction) => direction switch
    {
        Direction.Up => GetNextCoordinate(coord, Direction.Down),
        Direction.Down => GetNextCoordinate(coord, Direction.Up),
        Direction.Left => GetNextCoordinate(coord, Direction.Right),
        Direction.Right => GetNextCoordinate(coord, Direction.Left),
        Direction.TopLeft => GetNextCoordinate(coord, Direction.BottomRight),
        Direction.TopRight => GetNextCoordinate(coord, Direction.BottomLeft),
        Direction.BottomLeft => GetNextCoordinate(coord, Direction.TopRight),
        Direction.BottomRight => GetNextCoordinate(coord, Direction.TopLeft),
        _ => throw new NotImplementedException(),
    };
}
