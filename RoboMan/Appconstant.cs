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

        public const string TurnLeftSuccessful = "Turn left ok";

    }


}
