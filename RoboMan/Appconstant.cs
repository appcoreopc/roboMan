using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMan
{
    class Appconstant
    {
        public const int DefaultBoardSize = 5;

        public const char PlaceInstructionSeparator = ',';

        public const string AppExitCommandString = "exit";
        
        public const string RobotNotPlaced = "Robot is not place on the board. Please call place x,y,direction first";

        public const string RobotPlacementSuccessful = "Robot is placed on board.";
        
        public const string RobotPlamentOutOfBoardSize = "Robot is placed out of the board.";

        public const string RobotPlaceInvalidCommandParsed = "Command is not parsed correctly.";

        public const string TurnLeftSuccessful = "Turn left ok.";

        public const string TurnLeftUnable = "Unable Turn left.";

        public const string TurnRightSuccessful = "Turn right ok";

        public const string TurnRightFail = "Unable Turn right.";

        public const string MoveOk = "Move Ok";

        public const string MoveXOutOfBoardMaxSize = "Moving on x-axis out of board.";

        public const string LeftTurnFail = "Turn left failed.";

        public const string RightTurnOk = "Right turn ok.";

        public const string RightTurnFail = "Right turn failed";

        public const string ChangeDirectionOk = "Change direction ok";

        public const string ChangeDirectionFailed = "Change direction failed.";

        public const string MoveXOutOfBoardMinSize = "Move x-axis is negative";

        public const string UnableToMoveToTargetLocation = "Unable to move out of board";

        public const string MoveYOutOfBoardMaxSize = "Moving y-axis out of board size.";

        public const string MoveYOutOfBoardMinSize = "Move y-axis is negative.";

        public const string MoveCannotBeDetermined = "Move cannot be determined.";
    }


}
