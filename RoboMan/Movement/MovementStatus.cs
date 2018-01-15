
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
         
        ChangeDirectionOk,
        ChangeDirectionFailed,

        InvalidInstructionGiven, 

        ReportStatusOk, 
        ReportStatusFailed
    }
}
