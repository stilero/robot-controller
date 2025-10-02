namespace RobotControllerApp.Domain;

internal sealed class Robot(int x, int y, Direction direction)
{
    /// <summary>
    /// Rotates the current direction 90 degrees to the left.
    /// </summary>
    /// <remarks>This method updates the internal direction to reflect a left turn.  The new direction is
    /// determined based on the current direction.</remarks>
    public void TurnLeft() => direction = direction.TurnLeft();

    /// <summary>
    /// Rotates the current direction 90 degrees to the right.
    /// </summary>
    /// <remarks>Updates the internal direction to reflect the new orientation after turning right. This
    /// method assumes that the current direction supports a right-turn operation.</remarks>
    public void TurnRight() => direction = direction.TurnRight();

    /// <summary>
    /// Updates the current position by moving forward in the current facing direction.
    /// </summary>
    /// <remarks>The movement is determined by the current direction, which provides the change in X and Y
    /// coordinates. This method modifies the internal state of the object by updating the position.</remarks>
    public void WalkForward()
    {
        var (movementX, movementY) = direction.WalkForward();
        x += movementX;
        y += movementY;
    }

    /// <summary>
    /// Retrieves the current position and direction of the Robot.
    /// </summary>
    /// <returns>A tuple containing the current X-coordinate, Y-coordinate, and facing direction of the Robot.</returns>
    public (int X, int Y, Direction Direction) GetStatus() => (x, y, direction);
}
