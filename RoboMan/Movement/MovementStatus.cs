
namespace RoboMan.Movement
{
    enum MovementStatus
    {
        RobotNotPlacedOnBoard,
        RobotPlacementSuccessful,
        RobotPlamentOutOfBoardSize,
        RobotPlaceInvalidCommandParsed,

        TurnLeftSuccessful,
        TurnLeftUnable,

        TurnRightSuccessful,
        TurnRightFail,

        MoveOk,
        MoveXOutOfBoardMaxSize,
        MoveXOutOfBoardMinSize,

        UnableToMoveToTargetLocation,

        MoveYOutOfBoardMaxSize,
        MoveYOutOfBoardMinSize,

        MoveCannotBeDetermined,

        LeftTurnOk,
        LeftTurnFail,

        RightTurnOk,
        RightTurnFail,

        ChangeDirectionOk,
        ChangeDirectionFailed,

        InvalidInstructionGiven
    }
}
