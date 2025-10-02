using RobotControllerApp.Domain;

namespace RobotControllerApp.Input;

internal static class Parser
{
    /// <summary>
    /// Parses a string containing two space-separated integers into width and height dimensions.
    /// </summary>
    /// <param name="input">A string containing two integers separated by a space, representing the width and height.</param>
    /// <returns>A tuple containing the parsed width and height as integers.</returns>
    /// <exception cref="FormatException">Thrown if the input string does not contain exactly two space-separated integers  or if the integers cannot be
    /// parsed.</exception>
    public static (int width, int height) ParseDimensions(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2 || !int.TryParse(parts[0], out var width) || !int.TryParse(parts[1], out var height))
        {
            throw new FormatException(ErrorMessages.InvalidRoomDimensions);
        }
        return (width, height);
    }

    /// <summary>
    /// Parses a string representing a starting position and direction into a tuple of coordinates and direction.
    /// </summary>
    /// <param name="input">A string containing the starting position and direction, formatted as "X Y D", where X and Y are integers
    /// representing the coordinates, and D is a case-insensitive string representing the direction.</param>
    /// <returns>A tuple containing the parsed X coordinate, Y coordinate, and direction. The direction is parsed as an
    /// enumeration value of type <see cref="Direction"/>.</returns>
    /// <exception cref="FormatException">Thrown if the input string is not in the expected format, if the coordinates are not valid integers, or if the
    /// direction cannot be parsed into a valid <see cref="Direction"/> value.</exception>
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
