namespace RobotControllerApp.Domain;

internal sealed class Robot(int x, int y, Direction direction)
{

    public void TurnLeft() => direction = Movement.TurnLeft(direction);
    public void TurnRight() => direction = Movement.TurnRight(direction);
   
    public void WalkForward()
    {
        var (movementX, movementY) = Movement.WalkForward(direction);
        x += movementX;
        y += movementY;
    }

    public (int X, int Y, Direction Direction) GetStatus() => (x, y, direction);
}
