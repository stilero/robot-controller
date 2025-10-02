using RobotControllerApp.Domain;

namespace RobotControllerApp.Input;

internal static class Parser
{
    public static (int width, int height) ParseDimensions(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2 || !int.TryParse(parts[0], out var width) || !int.TryParse(parts[1], out var height))
        {
            throw new FormatException(ErrorMessages.InvalidRoomDimensions);
        }
        return (width, height);
    }

    public static (int x, int y, Direction direction) ParseStartingPosition(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3 || !int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y) || !Enum.TryParse<Direction>(parts[2], true, out var direction))
        {
            throw new FormatException(ErrorMessages.InvalidStartingPosition);
        }
        return (x, y, direction);
    }
}
