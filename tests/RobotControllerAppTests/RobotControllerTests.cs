using RobotControllerApp.Domain;

namespace RobotControllerAppTests;

public sealed class RobotControllerTests
{
    [Fact]
    public void ExecuteCommands_ShouldUpdateRobotPositionAndDirection()
    {
        // Arrange
        var room = new Room(5, 5);
        var robot = new Robot(1, 2, Direction.N);
        var controller = new RobotController(room, robot);
        var commands = "RFRFFRFRF";
        // Act
        controller.ExecuteCommands(commands);
        // Assert
        var (x, y, direction) = robot.GetStatus();
        Assert.Equal(1, x);
        Assert.Equal(3, y);
        Assert.Equal(Direction.N, direction);
    }
    [Fact]
    public void ExecuteCommands2_ShouldUpdateRobotPositionAndDirection()
    {
        // Arrange
        var room = new Room(5, 5);
        var robot = new Robot(0, 0, Direction.E);
        var controller = new RobotController(room, robot);
        var commands = "RFLFFLRF";
        // Act
        controller.ExecuteCommands(commands);
        // Assert
        var (x, y, direction) = robot.GetStatus();
        Assert.Equal(3, x);
        Assert.Equal(1, y);
        Assert.Equal(Direction.E, direction);
    }
    [Fact]
    public void ExecuteCommands_ShouldThrowException_WhenMovingOutOfBounds()
    {
        // Arrange
        var room = new Room(5, 5);
        var robot = new Robot(0, 0, Direction.N);
        var controller = new RobotController(room, robot);
        var commands = "F";
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => controller.ExecuteCommands(commands));
    }
    [Fact]
    public void ExecuteCommands_ShouldThrowException_OnInvalidCommand()
    {
        // Arrange
        var room = new Room(5, 5);
        var robot = new Robot(1, 2, Direction.N);
        var controller = new RobotController(room, robot);
        var commands = "LFX";
        // Act & Assert
        Assert.Throws<ArgumentException>(() => controller.ExecuteCommands(commands));
    }
}
