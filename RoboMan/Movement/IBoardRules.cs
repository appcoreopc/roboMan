
namespace RoboMan.Movement
{
    interface IBoardRules
    {
        MovementActionResult Move();

        MovementActionResult Left();

        MovementActionResult Right();

        bool ChangeDirection(MovementType direction);

        MovementActionResult ReportStatus();

        MovementActionResult SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection);

    }
}
