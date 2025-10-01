namespace RobotControllerApp.Domain;

public sealed class RobotController(Room room, Robot robot)
{
    public void ExecuteCommands(string commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case 'L':
                    robot.TurnLeft();
                    break;
                case 'R':
                    robot.TurnRight();
                    break;
                case 'F':
                    robot.WalkForward();
                    ValidatePositionWithinBounds();
                    break;
                default:
                    throw new ArgumentException($"Invalid command: {command}");
            }
        }
    }

    private void ValidatePositionWithinBounds()
    {
        var (x, y, _) = robot.GetStatus();
        if (!room.IsWithinBounds(x, y))
        {
            throw new InvalidOperationException("Robot moved out of room bounds.");
        }
    }
}
