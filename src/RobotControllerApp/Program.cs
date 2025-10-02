using RobotControllerApp;
using RobotControllerApp.Domain;

try
{    
    while (true)
    {      
        try
        {
            var room = GetRoom();
            var robot = GetRobot();
            var controller = new RobotController(room, robot);
            controller.ExecuteCommands(GetCommandsInput());
            Console.WriteLine(robot.GenerateReport());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing commands: {ex.Message}");
        }
        continue;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}

static Room GetRoom()
{
    Console.WriteLine("Enter size of room 'x y' for example '5 5'.");
    var roomSizeInput = Console.ReadLine() ?? throw new InvalidOperationException("Room dimensions input cannot be null.");
    var (width, height) = Parser.TryParseDimensions(roomSizeInput);
    return new Room(width, height);
}

static Robot GetRobot()
{
    Console.WriteLine("Enter Robot Starting position and facing direction 'x y d' for example '1 2 N'.");
    var startingPositionInput = Console.ReadLine() ?? throw new InvalidOperationException("Starting position input cannot be null.");
    var (startX, startY, startDirection) = Parser.TryParseStartingPosition(startingPositionInput);
    return new Robot(startX, startY, startDirection);
}

static string GetCommandsInput()
{
    Console.WriteLine("Enter Command input. Valid commands are L (Left) R (Right) F (Forward). for example 'LFRFFLRF'.");
    var commandsInput = Console.ReadLine() ?? throw new InvalidOperationException("Commands input cannot be null.");
    return commandsInput;
}