using RobotControllerApp.Domain;
using RobotControllerApp.Input;

return Run(Console.In, Console.Out, Console.Error, default);

public static partial class Program
{
    internal static int Run(TextReader input, TextWriter output, TextWriter error, CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var room = GetRoom(input, output);
                    var robot = GetRobot(input, output, room);
                    var controller = new RobotController(room, robot);
                    controller.ExecuteCommands(GetCommandsInput(input, output));
                    output.WriteLine(robot.GenerateReport());
                }
                catch (Exception ex)
                {
                    error.WriteLine(ex.Message);
                }
                output.WriteLine(Prompts.ContinuePrompt);
                if(input.ReadLine()?.Trim().ToLower() != "y")
                {
                    break;
                }
            }
            return 0;
        }
        catch (Exception ex)
        {
            error.WriteLine(ErrorMessages.UnexpectedError, ex.Message);
            return 1;
        }
    }

    static Room GetRoom(TextReader input, TextWriter output)
    {
        output.WriteLine(Prompts.RoomSize);
        var roomSizeInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(roomSizeInput))
        {
            throw new InvalidOperationException(ErrorMessages.InvalidRoomDimensions);
        }
        var (width, height) = Parser.ParseDimensions(roomSizeInput);
        var room = new Room(width, height);
        if(!room.IsWithinBounds(width-1, height-1))
        {
             throw new InvalidOperationException(ErrorMessages.InvalidRoomDimensions);
        }
        return room;
    }

    static Robot GetRobot(TextReader input, TextWriter output, Room room)
    {
        output.WriteLine(Prompts.RobotStartingPosition);
        var startingPositionInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(startingPositionInput))
        {
            throw new InvalidOperationException(ErrorMessages.InvalidStartingPosition);
        }
        var (startX, startY, startDirection) = Parser.ParseStartingPosition(startingPositionInput);
        if (!room.IsWithinBounds(startX, startY))
        {
            throw new ArgumentException(ErrorMessages.StartingPositionOutOfBounds);
        }
        return new Robot(startX, startY, startDirection);
    }

    static string GetCommandsInput(TextReader input, TextWriter output)
    {
        output.WriteLine(Prompts.RobotCommands);
        var commandsInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(commandsInput))
        {
            throw new InvalidOperationException(ErrorMessages.CommandsInputEmpty);
        }
        return commandsInput;
    }
}
