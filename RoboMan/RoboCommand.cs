﻿using CommandLine;
using RoboMan.Movement;
using RoboMan.Parser;
using RoboMan.Util;

namespace RoboMan
{
    [Verb("place", HelpText = "Place robot on a given board")]
    class PlaceOptions
    {
        // Alternative implementation /
        //[Value(0)]
        //public int LocationX { get; set; }

        //[Value(1)]
        //public int LocationY { get; set; }

        //[Value(2)]
        //public FaceDirection direction { get; set; }

        //[Value(0, Min = 1, Max = 1)]
        //public IEnumerable<string> PlacementCommandArgument { get; set; }

        [Value(0)]
        public string PlacementCommandArgument { get; set; }

    }

    [Verb("move", HelpText = "Move forward in the facing direction")]
    class MoveOptions
    {
        //normal options here
    }
    [Verb("left", HelpText = "Left Turn.")]
    class LeftOptions
    {
        //normal options here
    }
    [Verb("right", HelpText = "Right Turn.")]
    class RightOptions
    {
        //normal options here
    }

    [Verb("report", HelpText = "Report a robot.")]
    class ReportOptions
    {
        //normal options here
    }

    /// <summary>
    ///  Implementatioin of Command pattern 
    /// </summary>
    class RoboCommand
    {
        private IRobot _robo;

        public RoboCommand(IRobot robo)
        {
            _robo = robo;
        }

        public void ExecuteCommand(string[] command)
        {

            var actionResult = CommandLine.Parser.Default.ParseArguments<PlaceOptions, MoveOptions, 
                LeftOptions, RightOptions, ReportOptions>(command)
           
                .MapResult(

                    (PlaceOptions opts) => PlaceRobot(opts),

                    (MoveOptions opts) => Move(opts),

                    (LeftOptions opts) => TurnLeft(opts),

                    (RightOptions opts) => TurnRight(opts),

                    (ReportOptions opts) => ReportStatus(opts),

                    errs => 1);
        }

        private object PlaceRobot(PlaceOptions opts)
        {
            var placementActionResult = GetPlacementDirection(opts.PlacementCommandArgument);
            if (placementActionResult != null)
            {
                return _robo.SetPositionOnBoard(placementActionResult.LocationX, placementActionResult.LocationY,
                    placementActionResult.Direction);
            }
            return new MovementActionResult(MovementStatus.RobotPlaceInvalidCommandParsed);
        }

        private ParsedPositionInstruction GetPlacementDirection(string placementCommandArgument)
        {
            if (!string.IsNullOrEmpty(placementCommandArgument))
            {
                var result = placementCommandArgument?.Split(Appconstant.PlaceInstructionSeparator);
                if (result.Length == 3)
                {
                    return new ParsedPositionInstruction
                    {
                        LocationX = result[0].ToInt() ?? 0,
                        LocationY = result[1].ToInt() ?? 0,
                        Direction = result[2].ToDirection() ?? FaceDirection.North
                    };
                }
            }
            return null;
        }

        private object ReportStatus(ReportOptions opts)
        {
            var statusReport = _robo.ReportStatus();
            return statusReport; 
        }

        private object TurnRight(RightOptions opts)
        {
            return _robo.Right();
        }

        private object TurnLeft(LeftOptions opts)
        {
            return _robo.Left();
        }

        private object Move(MoveOptions opts)
        {
            return _robo.Move();
        }
    }
}
