namespace RobotControllerApp.Domain;

public sealed record Room
{   
    public int Width { get; init; }
    public int Height { get; init; }

    public Room(int width, int height)
    {
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than zero.");
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero.");
        Width = width;
        Height = height;
    }
    public bool IsWithinBounds(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height;
}