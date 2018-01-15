using System;
using System.Collections.Generic;
using System.Text;

namespace RoboManTest
{
    class AppTestConstants
    {
        public const string InvalidMoveCommandString = "MOOVE";
        
        public const string MoveCommandString = "move";

        public const string LeftCommandString = "left";

        public const string RightCommandString = "right";

        public const string PlaceCommandString = "place";

        public const string ReportCommandString = "report";
        
        public const string ValidPlaceCommandStringArgument = "1,1,north";

        public const string NotValidPlaceCommandStringArgument = "1,1, DOWNTOWN";
    }
}
