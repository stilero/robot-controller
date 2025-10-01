namespace RobotControllerApp.Domain;

public static class Reporter
{
    public static string GenerateReport(this Robot robot)
    {
        var (x, y, direction) = robot.GetStatus();
        return $"Report: {x} {y} {direction.ToString().ToUpper()[0]}";
    }
}
