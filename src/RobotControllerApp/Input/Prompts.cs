namespace RobotControllerApp.Input;

internal static class Prompts
{
    public const string RoomSize = "Enter size of room 'x y' for example '5 5'.";
    public const string RobotStartingPosition = "Enter Robot Starting position and facing direction 'x y d' for example '1 2 N'.";
    public const string RobotCommands = "Enter Command input. Valid commands are L (Left) R (Right) F (Forward). for example 'LFRFFLRF'.";
    public const string ContinuePrompt = "Do you want to run another simulation? (y/n)";
}
