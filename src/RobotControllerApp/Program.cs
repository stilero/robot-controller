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
                    error.WriteLine($"Error executing commands: {ex.Message}");
                }
                output.WriteLine("Do you want to run another simulation? (y/n)");
                if(input.ReadLine()?.Trim().ToLower() != "y")
                {
                    break;
                }
            }
            return 0;

        }
        catch (Exception ex)
        {
            error.WriteLine($"Unexpected error: {ex.Message}");
            return 1;
        }
    }

    static Room GetRoom(TextReader input, TextWriter output)
    {
        output.WriteLine("Enter size of room 'x y' for example '5 5'.");
        var roomSizeInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(roomSizeInput))
        {
            throw new InvalidOperationException("Room dimensions input cannot be null.");
        }
        var (width, height) = Parser.ParseDimensions(roomSizeInput);
        var room = new Room(width, height);
        if(!room.IsWithinBounds(width-1, height-1))
        {
             throw new InvalidOperationException("Room dimensions must be positive integers.");
        }
        return room;
    }

    static Robot GetRobot(TextReader input, TextWriter output, Room room)
    {
        output.WriteLine("Enter Robot Starting position and facing direction 'x y d' for example '1 2 N'.");
        var startingPositionInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(startingPositionInput))
        {
            throw new InvalidOperationException("Robot starting position input cannot be null.");
        }
        var (startX, startY, startDirection) = Parser.ParseStartingPosition(startingPositionInput);
        if (!room.IsWithinBounds(startX, startY))
        {
            throw new ArgumentException("Robot starting position is out of room bounds.");
        }
        return new Robot(startX, startY, startDirection);
    }

    static string GetCommandsInput(TextReader input, TextWriter output)
    {
        output.WriteLine("Enter Command input. Valid commands are L (Left) R (Right) F (Forward). for example 'LFRFFLRF'.");
        var commandsInput = input.ReadLine();
        if (string.IsNullOrWhiteSpace(commandsInput))
        {
            throw new InvalidOperationException("Commands input cannot be null.");
        }
        return commandsInput;
    }
}
