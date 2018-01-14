using RoboMan.Movement;

namespace RoboMan.Command
{
    class ConsoleCommandResult : ICommandResult
    {
        public void ProcessResult(MovementActionResult actionResult)
        {

            if (actionResult == null)
                return;

            switch (actionResult.Status)
            {
                case MovementStatus.RobotNotPlacedOnBoard:
                    System.Console.WriteLine(Appconstant.RobotNotPlaced);
                    break;
                case MovementStatus.RobotPlacementSuccessful:
                    System.Console.WriteLine(Appconstant.RobotPlacementSuccessful);
                    break;
                case MovementStatus.RobotPlamentOutOfBoardSize:
                    System.Console.WriteLine(Appconstant.RobotPlamentOutOfBoardSize);
                    break;
                case MovementStatus.RobotPlaceInvalidCommandParsed:
                    System.Console.WriteLine(Appconstant.RobotPlaceInvalidCommandParsed);
                    break;
                case MovementStatus.TurnLeftSuccessful:
                    System.Console.WriteLine(Appconstant.TurnLeftSuccessful);
                    break;
                case MovementStatus.TurnLeftUnable:
                    break;
                case MovementStatus.TurnRightSuccessful:
                    break;
                case MovementStatus.TurnRightFail:
                    break;
                case MovementStatus.MoveOk:
                    break;
                case MovementStatus.MoveXOutOfBoardMaxSize:
                    break;
                case MovementStatus.MoveXOutOfBoardMinSize:
                    break;
                case MovementStatus.UnableToMoveToTargetLocation:
                    break;
                case MovementStatus.MoveYOutOfBoardMaxSize:
                    break;
                case MovementStatus.MoveYOutOfBoardMinSize:
                    break;
                case MovementStatus.MoveCannotBeDetermined:
                    break;
                case MovementStatus.LeftTurnOk:
                    break;
                case MovementStatus.LeftTurnFail:
                    break;
                case MovementStatus.RightTurnOk:
                    break;
                case MovementStatus.RightTurnFail:
                    break;
                case MovementStatus.ChangeDirectionOk:
                    break;
                case MovementStatus.ChangeDirectionFailed:
                    break;
                case MovementStatus.InvalidInstructionGiven:
                    System.Console.WriteLine(Appconstant.InvalidInstructionGiven);
                    break;
                default:
                    break;
            }
        }
    }
}
