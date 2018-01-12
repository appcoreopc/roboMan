namespace RoboMan
{
    internal interface IRobot
    {
        bool Move();

        bool Left();

        bool Right();

        bool ChangeDirection(MovementType direction);

        string ReportStatus();

        bool SetPositionOnBoard(int x, int y, FaceDirection facingDirection);

    }

}