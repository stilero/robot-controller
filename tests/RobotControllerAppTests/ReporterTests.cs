using RobotControllerApp.Domain;

namespace RobotControllerAppTests;

public sealed class ReporterTests
{
    [Fact]
    public void GenerateReport_ShouldReturnCorrectFormat()
    {
        // Arrange
        var robot = new Robot(3, 4, Direction.E);
        
        // Act
        var report = robot.GenerateReport();
        // Assert
        Assert.Equal("Report: 3 4 E", report);
    }
}
