namespace RobotControllerApp.Domain;

/// <summary>
/// The four directions a robot can face
/// </summary>
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

    /// <summary>
    /// Rotates the specified direction 90 degrees to the left.
    /// </summary>
    /// <param name="currentDirection">The current direction from which to turn left.</param>
    /// <returns>The new <see cref="Direction"/> after turning left.</returns>
    public static Direction TurnLeft(this Direction currentDirection) =>
        (Direction)((int)currentDirection -1 < 0
        ? MaxDirectionValue
        : (int)currentDirection - 1);

    /// <summary>
    /// Rotates the specified direction 90 degrees to the right.
    /// </summary>
    /// <returns>The direction resulting from a 90-degree clockwise rotation.<see cref="Direction"/></returns>
    public static Direction TurnRight(this Direction currentDirection) =>
        (Direction)((int)currentDirection + 1 > MaxDirectionValue
        ? 0
        : (int)currentDirection + 1);

    /// <summary>
    /// Calculates the coordinate delta for moving forward in the given direction.
    /// Coordinate system assumes (0,0) is at the top-left, X increases to the right, and Y increases downward.
    /// </summary>
    /// <param name="currentDirection">The current facing direction of the robot.</param>
    /// <returns>A tuple containing delta x and delta Y to add to the current position.</returns>
    public static (int movementX, int movementY) WalkForward(this Direction currentDirection) => currentDirection switch
    {
        Direction.N => (0, -1), // North: Y decreases (up)
        Direction.E => (1, 0),  // East: X increases (right)
        Direction.S => (0, 1),  // South: Y increases (down)
        Direction.W => (-1, 0), // West: X decreases (left)
        _ => new(0, 0)          // Default case (should not occur)
    };
}
