namespace RobotControllerApp.Domain;

public sealed class Robot(int x, int y, Direction direction)
{

    public void TurnLeft() => direction = DirectionOperation.TurnLeft(direction);
    public void TurnRight() => direction = DirectionOperation.TurnRight(direction);
   
    public void WalkForward()
    {
        var (movementX, movementY) = DirectionOperation.WalkForward(direction);
        x += movementX;
        y += movementY;
    }

    public (int X, int Y, Direction Direction) GetStatus() => (x, y, direction);
}
