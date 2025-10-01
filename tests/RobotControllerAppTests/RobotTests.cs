using RobotControllerApp.Domain;

namespace RobotControllerAppTests;

public sealed class RobotTests
{
    [Fact]
    public void WalkForward_ShouldUpdatePositionCorrectly()
    {
        // Arrange
        var robot = new Robot(1, 1, Direction.North);
        // Act
        robot.WalkForward();
        var (x, y, direction) = robot.GetStatus();
        // Assert
        Assert.Equal(1, x);
        Assert.Equal(0, y);
        Assert.Equal(Direction.North, direction);
    }

    [Fact]
    public void TurnLeftAndWalkForward_ShouldUpdatePositionAndDirectionCorrectly()
    {
        // Arrange
        var robot = new Robot(1, 1, Direction.North);
        // Act
        robot.TurnLeft();
        robot.WalkForward();
        var (x, y, direction) = robot.GetStatus();
        // Assert
        Assert.Equal(0, x);
        Assert.Equal(1, y);
        Assert.Equal(Direction.West, direction);
    }

    [Fact]
    public void FullCircleTurns_ShouldReturnToOriginalDirection()
    {
        // Arrange
        var robot = new Robot(1, 1, Direction.North);
        // Act
        for (int i = 0; i < 4; i++)
        {
            robot.TurnRight();
        }
        var (x, y, direction) = robot.GetStatus();
        // Assert
        Assert.Equal(1, x);
        Assert.Equal(1, y);
        Assert.Equal(Direction.North, direction);
    }
}
