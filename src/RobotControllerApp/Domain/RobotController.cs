using RobotControllerApp.Input;

namespace RobotControllerApp.Domain;

internal sealed class RobotController(Room room, Robot robot)
{
    /// <summary>
    /// Represents the maximum number of commands that can be processed at once.
    /// </summary>
    /// <remarks>This constant defines an upper limit for the number of commands to ensure efficient
    /// processing and prevent excessive resource usage. It is used internally to enforce this constraint.</remarks>
    private const int MaxCommandsLength = 100;

    /// <summary>
    /// Executes a sequence of commands to control the robot's movement and orientation.
    /// </summary>
    /// <remarks>The method processes the commands in the order they appear in the string. After executing a
    /// forward movement ('F'), the robot's position is validated to ensure it remains within the defined bounds. If the
    /// position is out of bounds, an exception may be thrown by the validation logic.</remarks>
    /// <param name="commands">A string containing the sequence of commands to execute. Each character in the string represents a command: 'L'
    /// to turn the robot left, 'R' to turn the robot right, and 'F' to move the robot forward.</param>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="commands"/> string contains an invalid command character. Valid commands are 'L',
    /// 'R', and 'F'.</exception>
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
