namespace RobotControllerApp.Domain;

internal sealed class RobotController(Room room, Robot robot)
{
    private const int MaxCommandsLength = 100;

    public void ExecuteCommands(string commands)
    {
        ValidateCommandsInput(commands);
        ValidateCommandsLength(commands);
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

    private static void ValidateCommandsLength(string commands)
    {
        if (commands.Length > MaxCommandsLength)
        {
            throw new ArgumentException($"Commands input exceeds maximum length of {MaxCommandsLength} characters.");
        }
    }

    private static void ValidateCommandsInput(string commands)
    {
        if (string.IsNullOrWhiteSpace(commands))
        {
            throw new ArgumentException("Commands input cannot be null or empty.");
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
