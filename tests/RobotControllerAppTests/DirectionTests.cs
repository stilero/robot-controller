using RobotControllerApp.Domain;

namespace RobotControllerAppTests;

public sealed class DirectionTests
{
    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.West, Direction.South)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.East, Direction.North)]
    public void TurnLeft_ShouldReturnExpectedDirection(Direction current, Direction expected)
    {
        //Act
        var actual = DirectionOperation.TurnLeft(current);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West, Direction.North)]
    public void TurnRight_ShouldReturnExpectedDirection(Direction current, Direction expected)
    {
        //Act
        var actual = DirectionOperation.TurnRight(current);
        //Assert
        Assert.Equal(expected, actual);
    }
}
