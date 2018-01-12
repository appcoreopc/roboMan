
namespace RoboMan.Movement
{
    interface IMovementMechanics
    {
        bool Move();

        bool Left();

        bool Right();

        bool ChangeDirection(MovementType direction);

        string ReportStatus();

        bool SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection);

    }
}
