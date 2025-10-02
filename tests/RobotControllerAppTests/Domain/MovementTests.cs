using RobotControllerApp.Domain;

namespace RobotControllerAppTests.Domain;

public sealed class MovementTests
{
    [Theory]
    [InlineData(Direction.N, Direction.W)]
    [InlineData(Direction.W, Direction.S)]
    [InlineData(Direction.S, Direction.E)]
    [InlineData(Direction.E, Direction.N)]
    public void TurnLeft_ShouldReturnExpectedDirection(Direction current, Direction expected)
    {
        //Act
        var actual = current.TurnLeft();
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Direction.N, Direction.E)]
    [InlineData(Direction.E, Direction.S)]
    [InlineData(Direction.S, Direction.W)]
    [InlineData(Direction.W, Direction.N)]
    public void TurnRight_ShouldReturnExpectedDirection(Direction current, Direction expected)
    {
        //Act
        var actual = current.TurnRight();
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Direction.N, 0, -1)]
    [InlineData(Direction.E, 1, 0)]
    [InlineData(Direction.S, 0, 1)]
    [InlineData(Direction.W, -1, 0)]
    public void WalkForward_ShouldReturnExpectedDelta(Direction current, int expectedDx, int expectedDy)
    {
        //Act
        var (actualDirectionX, actualDirectionY) = current.WalkForward();
        //Assert
        Assert.Equal(expectedDx, actualDirectionX);
        Assert.Equal(expectedDy, actualDirectionY);
    }
}
