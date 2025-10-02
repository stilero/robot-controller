namespace RobotControllerApp.Domain;

public enum Direction
{
    N = 0,
    E = 1,
    S = 2,
    W = 3
}

internal static class Movement
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
        Direction.N => (0, -1), // North: Y decreases (up)
        Direction.E => (1, 0),  // East: X increases (right)
        Direction.S => (0, 1),  // South: Y increases (down)
        Direction.W => (-1, 0), // West: X decreases (left)
        _ => new(0, 0)          // Default case (should not occur)
    };
}
