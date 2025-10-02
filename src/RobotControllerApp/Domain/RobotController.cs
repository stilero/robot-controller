using RobotControllerApp.Input;

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
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidCommand, command));
            }
        }
    }

    private static void ValidateCommandsLength(string commands)
    {
        if (commands.Length > MaxCommandsLength)
        {
            throw new ArgumentException(string.Format(ErrorMessages.CommandsTooLong, MaxCommandsLength));
        }
    }

    private static void ValidateCommandsInput(string commands)
    {
        if (string.IsNullOrWhiteSpace(commands))
        {
            throw new ArgumentException(ErrorMessages.CommandsInputEmpty);
        }
    }

    private void ValidatePositionWithinBounds()
    {
        var (x, y, _) = robot.GetStatus();
        if (!room.IsWithinBounds(x, y))
        {
            throw new InvalidOperationException(ErrorMessages.RobotOutOfBounds);
        }
    }
}
