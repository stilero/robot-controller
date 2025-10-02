using RobotControllerApp.Input;

namespace RobotControllerApp.Domain;

internal sealed record Room
{
    public int Width { get; init; }
    public int Height { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Room"/> class with the specified dimensions.
    /// </summary>
    /// <param name="width">The width of the room. Must be a positive integer.</param>
    /// <param name="height">The height of the room. Must be a positive integer.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="width"/> or <paramref name="height"/> is less than or equal to zero.</exception>
    public Room(int width, int height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), ErrorMessages.WidthHeightPositive);
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), ErrorMessages.WidthHeightPositive);
        }

        Width = width;
        Height = height;
    }

    /// <summary>
    /// Determines whether the specified coordinates are within the bounds of the defined area.
    /// </summary>
    /// <remarks>The bounds are defined by the <c>Width</c> and <c>Height</c> properties.  The method checks
    /// if <paramref name="x"/> is less than <c>Width</c> and  <paramref name="y"/> is less than
    /// <c>Height</c>.</remarks>
    /// <param name="x">The x-coordinate to check. Must be a non-negative integer.</param>
    /// <param name="y">The y-coordinate to check. Must be a non-negative integer.</param>
    /// <returns><see langword="true"/> if the specified coordinates are within the bounds of the area;  otherwise, <see
    /// langword="false"/>.</returns>
    public bool IsWithinBounds(int x, int y) =>
        x >= 0 && x < Width && y >= 0 && y < Height;
}