namespace RobotControllerApp.Input;

internal static class ErrorMessages
{
    public const string InvalidRoomDimensions = "Invalid room dimensions. Room dimensions must be positive integers.";
    public const string InvalidStartingPosition = "Invalid starting position. Please enter a valid position in the format x y direction for example '1 2 N'.";
    public const string StartingPositionOutOfBounds = "Starting position is out of room bounds.";
    public const string CommandsInputEmpty = "Commands input cannot be null or empty.";
    public const string InvalidCommand = "Invalid Command: {0}";
    public const string UnexpectedError = "Unexpected error: {0}";
    public const string CommandsTooLong = "Commands input exceeds maximum length of {0} characters.";
    public const string RobotOutOfBounds = "Robot moved out of room bounds.";
    public const string WidthHeightPositive = "Width and Height must be positive integers.";
}
