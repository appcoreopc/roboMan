
namespace RoboMan
{
    class Appconstant
    {
        public const int DefaultBoardSize = 5;

        public const char PlaceInstructionSeparator = ',';

        public const string AppExitCommandString = "exit";
        
        public const string RobotNotPlaced = "Robot is not place on the board. Please call place x,y,direction before moving robot";

        public const string RobotPlacementSuccessful = "Robot is placed on board.";
        
        public const string RobotPlamentOutOfBoardSize = "Robot is placed out of the board.";

        public const string RobotPlaceInvalidCommandParsed = "Command is not parsed correctly.";

        public const string TurnLeftSuccessful = "Turn left ok.";

        public const string WelcomeString = "Welcome to Roboman!";
        
        public const string InvalidInstructionGiven = "Invalid Instruction Given.";

        public const string CommandPrompt = ">:";
                
        public const string TurnLeftUnable = "Unable to turn left.";
        
        public const string TurnRightSuccessful = "Turn right ok.";

        public const string TurnRightFail = "Turn right failed.";
        
        public const string MoveOk = "Move ok";

        public const string MoveXOutOfBoardMaxSize = "Robot reached x-axis max size.";

        public const string MoveXOutOfBoardMinSize = "Robt reach x-axis min size.";

        public const string UnableToMoveToTargetLocation = "Unable to move to the target location.";

        public const string MoveYOutOfBoardMaxSize = "Robot reach y-axis max size.";

        public const string MoveYOutOfBoardMinSize = "Robot reach y-axis min size.";

        public const string MoveCannotBeDetermined  = "Unable to determine move";

        public const string ChangeDirectionFailed = "Change direction failed.";

        public const string ChangeDirectionOk = "Change direction ok.";

        public const string ContainerSetupBoardArgumentTableSize = "tableSize";

        public const string ReportStatusFailed = "Report status failed.";
        
        public const int LocationXIndex = 0;

        public const int LocationYIndex = 1;

        public const int DirectionIndex = 2;

    }

}
