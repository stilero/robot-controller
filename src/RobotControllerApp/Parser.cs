using RobotControllerApp.Domain;

namespace RobotControllerApp;

internal static class Parser
{
    public static (int width, int height) TryParseDimensions(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2 || !int.TryParse(parts[0], out var width) || !int.TryParse(parts[1], out var height))
        {
            throw new FormatException("Invalid room dimensions. Please enter valid dimensions in the format width height for example 5 7 ");
        }
        return (width, height);
    }

    public static (int x, int y, Direction direction) TryParseStartingPosition(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 3 || !int.TryParse(parts[0], out var x) || !int.TryParse(parts[1], out var y) || !Enum.TryParse<Direction>(parts[2], true, out var direction))
        {
            throw new FormatException("Invalid starting position. Please enter a valid position in the format x y direction for example 1 2 N");
        }
        return (x, y, direction);
    }

}
