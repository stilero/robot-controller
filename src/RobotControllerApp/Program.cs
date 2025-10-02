using RobotControllerApp;
using RobotControllerApp.Domain;

return await RunAsync(Console.In, Console.Out, Console.Error, default);

public static partial class Program
{
    internal static Task<int> RunAsync(TextReader input, TextWriter output, TextWriter error, CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var room = GetRoom(input, output);
                    var robot = GetRobot(input, output);
                    var controller = new RobotController(room, robot);
                    controller.ExecuteCommands(GetCommandsInput(input, output));
                    output.WriteLine(robot.GenerateReport());
                }
                catch (Exception ex)
                {
                    error.WriteLine($"Error executing commands: {ex.Message}");
                }
                return Task.FromResult(0);
            }
            return Task.FromResult(0);

        }
        catch (Exception ex)
        {
            error.WriteLine($"Unexpected error: {ex.Message}");
            return Task.FromResult(1);
        }
    }

    static Room GetRoom(TextReader input, TextWriter output)
    {
        output.WriteLine("Enter size of room 'x y' for example '5 5'.");
        var roomSizeInput = input.ReadLine() ?? throw new InvalidOperationException("Room dimensions input cannot be null.");
        var (width, height) = Parser.TryParseDimensions(roomSizeInput);
        return new Room(width, height);
    }

    static Robot GetRobot(TextReader input, TextWriter output)
    {
        output.WriteLine("Enter Robot Starting position and facing direction 'x y d' for example '1 2 N'.");
        var startingPositionInput = input.ReadLine() ?? throw new InvalidOperationException("Starting position input cannot be null.");
        var (startX, startY, startDirection) = Parser.TryParseStartingPosition(startingPositionInput);
        return new Robot(startX, startY, startDirection);
    }

    static string GetCommandsInput(TextReader input, TextWriter output)
    {
        output.WriteLine("Enter Command input. Valid commands are L (Left) R (Right) F (Forward). for example 'LFRFFLRF'.");
        var commandsInput = input.ReadLine() ?? throw new InvalidOperationException("Commands input cannot be null.");
        return commandsInput;
    }
}
