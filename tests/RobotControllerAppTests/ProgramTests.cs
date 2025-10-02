namespace RobotControllerAppTests;

public class ProgramTests
{

    [Theory]
    [InlineData("5 5", "1 2 N", "RFRFFRFRF", "1 3 N")]
    [InlineData("5 5", "0 0 E", "RFLFFLRF", "3 1 E")]
    public async Task Main_ValidInput_PrintsExpectedOutput(string roomSizeInput, string startPosition, string command, string expectedPosition)
    {
        // Arrange
        var input = $"{roomSizeInput}\n{startPosition}\n{command}\n";
        var expectedOutput = $"Report: {expectedPosition}\r";
        using var inputReader = new StringReader(input);
        using var outputWriter = new StringWriter();
        using var errorWriter = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(outputWriter);
        Console.SetError(errorWriter);

        // Act
        var result = await Program.RunAsync(inputReader, outputWriter, errorWriter, CancellationToken.None);
        // Assert
        var actualOutput = outputWriter.ToString();
        var reportResult = actualOutput.Split("\n",StringSplitOptions.RemoveEmptyEntries).Last();
        Assert.Equal(0, result);
        Assert.Equal(expectedOutput, reportResult);
    }

    [Fact]
    public async Task Main_InvalidRoomSizeInput_PrintsErrorMessage()
    {
        // Arrange
        var input = $"invalid input\n1 2 N\nRFRFFRFRF\n";
        using var inputReader = new StringReader(input);
        using var outputWriter = new StringWriter();
        using var errorWriter = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(outputWriter);
        Console.SetError(errorWriter);
        // Act
        var result = await Program.RunAsync(inputReader, outputWriter, errorWriter, CancellationToken.None);
        // Assert
        var actualErrorOutput = errorWriter.ToString();
        Assert.Equal(0, result);
        Assert.Contains("Error executing commands: Invalid room dimensions. Please enter valid dimensions in the format width height for example 5 7", actualErrorOutput);
    }

    [Fact]
    public async Task Main_InvalidStartingPositionInput_PrintsErrorMessage()
    {
        // Arrange
        var input = $"5 5\ninvalid input\nRFRFFRFRF\n";
        using var inputReader = new StringReader(input);
        using var outputWriter = new StringWriter();
        using var errorWriter = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(outputWriter);
        Console.SetError(errorWriter);
        // Act
        var result = await Program.RunAsync(inputReader, outputWriter, errorWriter, CancellationToken.None);
        // Assert
        var actualErrorOutput = errorWriter.ToString();
        Assert.Equal(0, result);
        Assert.Contains("Error executing commands: Invalid starting position. Please enter a valid position in the format x y direction for example 1 2 N", actualErrorOutput);
    }

    [Fact]
    public async Task Main_InvalidCommandInput_PrintsErrorMessage()
    {
        // Arrange
        var input = $"5 5\n1 2 N\nX\n";
        using var inputReader = new StringReader(input);
        using var outputWriter = new StringWriter();
        using var errorWriter = new StringWriter();
        Console.SetIn(inputReader);
        Console.SetOut(outputWriter);
        Console.SetError(errorWriter);
        
        // Act
        var result = await Program.RunAsync(inputReader, outputWriter, errorWriter, CancellationToken.None);
        // Assert
        var actualErrorOutput = errorWriter.ToString();
        Assert.Equal(0, result);
        Assert.Contains("Error executing commands: Invalid command: X", actualErrorOutput);
    }
}
