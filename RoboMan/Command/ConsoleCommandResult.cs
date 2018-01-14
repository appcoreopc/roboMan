using RoboMan.Movement;

namespace RoboMan.Command
{
    class ConsoleCommandResult : ICommandResult
    {
        public void ProcessResult(MovementActionResult actionResult)
        {

            if (actionResult == null)
            {
                System.Console.WriteLine(Appconstant.InvalidInstructionGiven);
                return;
            }
            
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
                    System.Console.WriteLine(Appconstant.TurnLeftUnable);
                    break;
                case MovementStatus.TurnRightSuccessful:
                    System.Console.WriteLine(Appconstant.TurnRightSuccessful);
                    break;
                case MovementStatus.TurnRightFail:
                    System.Console.WriteLine(Appconstant.TurnRightFail);
                    break;
                case MovementStatus.MoveOk:
                    System.Console.WriteLine(Appconstant.MoveOk);
                    break;
                case MovementStatus.MoveXOutOfBoardMaxSize:
                    System.Console.WriteLine(Appconstant.MoveXOutOfBoardMaxSize);
                    break;
                case MovementStatus.MoveXOutOfBoardMinSize:
                    System.Console.WriteLine(Appconstant.MoveXOutOfBoardMinSize);
                    break;
                case MovementStatus.UnableToMoveToTargetLocation:
                    System.Console.WriteLine(Appconstant.UnableToMoveToTargetLocation);
                    break;
                case MovementStatus.MoveYOutOfBoardMaxSize:
                    System.Console.WriteLine(Appconstant.MoveYOutOfBoardMaxSize);
                    break;
                case MovementStatus.MoveYOutOfBoardMinSize:
                    System.Console.WriteLine(Appconstant.MoveYOutOfBoardMinSize);
                    break;
                case MovementStatus.MoveCannotBeDetermined:
                    System.Console.WriteLine(Appconstant.MoveCannotBeDetermined);
                    break;              
                case MovementStatus.ChangeDirectionOk:
                    System.Console.WriteLine(Appconstant.ChangeDirectionOk);
                    break;
                case MovementStatus.ChangeDirectionFailed:
                    System.Console.WriteLine(Appconstant.ChangeDirectionFailed);
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
