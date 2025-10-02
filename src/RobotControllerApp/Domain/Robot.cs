namespace RobotControllerApp.Domain;

internal sealed class Robot(int x, int y, Direction direction)
{

    public void TurnLeft() => direction = direction.TurnLeft();
    public void TurnRight() => direction = direction.TurnRight();

    public void WalkForward()
    {
        var (movementX, movementY) = direction.WalkForward();
        x += movementX;
        y += movementY;
    }

    public (int X, int Y, Direction Direction) GetStatus() => (x, y, direction);
}
