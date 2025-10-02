namespace RobotControllerApp.Domain;

internal static class Reporter
{
    /// <summary>
    /// Extension method to generate a status report for the robot.
    /// </summary>
    /// <param name="robot">The Robot</param>
    /// <returns>A formatted string report of the robots current position and direction</returns>
    public static string GenerateReport(this Robot robot)
    {
        var (x, y, direction) = robot.GetStatus();
        return $"Report: {x} {y} {direction}";
    }
}
