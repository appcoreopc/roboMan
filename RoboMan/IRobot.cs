using RoboMan.Movement;

namespace RoboMan
{
    internal interface IRobot
    {
        MovementActionResult Move();

        bool Left();

        bool Right();

        //bool ChangeDirection(MovementType direction);

        MovementActionResult ReportStatus();

        MovementActionResult SetPositionOnBoard(int x, int y, FaceDirection facingDirection);

    }

}