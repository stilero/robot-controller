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

    [Theory]
    [InlineData(Direction.North, 0, -1)]
    [InlineData(Direction.East, 1, 0)]
    [InlineData(Direction.South, 0, 1)]
    [InlineData(Direction.West, -1, 0)]
    public void WalkForward_ShouldReturnExpectedDelta(Direction current, int expectedDx, int expectedDy)
    {
        //Act
        var (actualDirectionX, actualDirectionY) = DirectionOperation.WalkForward(current);
        //Assert
        Assert.Equal(expectedDx, actualDirectionX);
        Assert.Equal(expectedDy, actualDirectionY);
    }
}
