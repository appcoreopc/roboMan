using RoboMan.Movement;

namespace RoboMan
{
    internal interface IRobot
    {
        MovementActionResult Move();

        MovementActionResult Left();

        MovementActionResult Right();
        
        MovementActionResult ReportStatus();

        MovementActionResult SetPositionOnBoard(int x, int y, FaceDirection facingDirection);

    }

}