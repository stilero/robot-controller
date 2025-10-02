using RobotControllerApp;
using RobotControllerApp.Domain;

namespace RobotControllerAppTests;

public sealed class ParserTests
{
    [Fact]
    public void TryParseDimensions_ValidInput_ReturnsDimensions()
    {
        var input = "5 7";
        var (width, height) = Parser.TryParseDimensions(input);
        Assert.Equal(5, width);
        Assert.Equal(7, height);
    }
    [Fact]
    public void TryParseDimensions_InvalidInput_ThrowsFormatException()
    {
        var input = "5";
        Assert.Throws<FormatException>(() => Parser.TryParseDimensions(input));
    }

    [Fact]
    public void TryParseStartingPosition_ValidInput_ReturnsPositionAndDirection()
    {
        var input = "1 2 N";
        var (x, y, direction) = Parser.TryParseStartingPosition(input);
        Assert.Equal(1, x);
        Assert.Equal(2, y);
        Assert.Equal(Direction.N, direction);
    }

    [Fact]
    public void TryParseStartingPosition_InvalidInput_ThrowsFormatException()
    {
        var input = "1 2";
        Assert.Throws<FormatException>(() => Parser.TryParseStartingPosition(input));
    }
}
