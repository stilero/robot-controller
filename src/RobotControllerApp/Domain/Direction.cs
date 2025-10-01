namespace RobotControllerApp.Domain;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public static class DirectionOperation
{
    private static readonly int MaxDirectionValue = (int)Enum.GetValues<Direction>().Max();

    public static Direction TurnLeft(this Direction currentDirection) => 
        (Direction)((int)currentDirection -1 < 0 
        ? MaxDirectionValue
        : (int)currentDirection - 1);

    public static Direction TurnRight(this Direction currentDirection) => 
        (Direction)((int)currentDirection + 1 > MaxDirectionValue
        ? 0 
        : (int)currentDirection + 1);

    public static (int movementX, int movementY) WalkForward(this Direction currentDirection) => currentDirection switch
    {
        Direction.North => (0, -1),
        Direction.East => (1, 0),
        Direction.South => (0, 1),
        Direction.West => (-1, 0),
        _ => new(0, 0)
    };
}
