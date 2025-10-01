namespace RobotControllerApp.Domain;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public static class DirectionOperation
{
    public static Direction TurnLeft(this Direction currentDirection) => (Direction)((int)currentDirection -1 < 0 ? (int)Enum.GetValues<Direction>().Max() : (int)currentDirection - 1);
    public static Direction TurnRight(this Direction currentDirection) => (Direction)((int)currentDirection + 1 > (int)Enum.GetValues<Direction>().Max() ? 0 : (int)currentDirection + 1);

}
