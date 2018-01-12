namespace RoboMan
{
    internal interface IRobo
    {
        bool Move();

        bool Left();

        bool Right();

        bool Turn(Direction direction);

        string ReportStatus();

        bool Place(int x, int y, FaceDirection facingDirection);

    }

}