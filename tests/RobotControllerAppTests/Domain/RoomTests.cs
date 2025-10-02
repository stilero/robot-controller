using RobotControllerApp.Domain;

namespace RobotControllerAppTests.Domain;

public sealed class RoomTests
{
    [Theory]
    [InlineData(5, 5, 5, 5, false)]
    [InlineData(5, 5, 4, 4, true)]
    [InlineData(5, 5, 6, 5, false)]
    [InlineData(5, 5, 5, 6, false)]
    [InlineData(5, 5, 0, 0, true)]
    [InlineData(5, 5, -1, 0, false)]
    [InlineData(5, 5, 0, -1, false)]
    [InlineData(10, 10, 9, 9, true)]
    public void IsWithinBounds_ShouldReturnExpectedResult(int width, int height, int x, int y, bool expected)
    {
        // Arrange
        var room = new Room(width, height);

        // Act
        var result = room.IsWithinBounds(x, y);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(5, 0)]
    [InlineData(-1, 5)]
    [InlineData(5, -1)]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_ForInvalidDimensions(int width, int height)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Room(width, height));
    }
}
