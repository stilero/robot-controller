using RobotControllerApp.Input;

namespace RobotControllerApp.Domain;

internal sealed record Room
{
    public int Width { get; init; }
    public int Height { get; init; }

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
    public bool IsWithinBounds(int x, int y) =>
        x >= 0 && x < Width && y >= 0 && y < Height;
}