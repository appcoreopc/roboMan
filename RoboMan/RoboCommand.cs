using CommandLine;
using RoboMan.Command;
using RoboMan.Movement;
using RoboMan.Parser;
using RoboMan.Util;

namespace RoboMan
{    
    /// <summary>
    ///  Implementatioin of Command pattern 
    /// </summary>
    class RoboCommand
    {
        private IRobot _robo;
        private ICommandResult _commandResult;

        public RoboCommand(IRobot robo, ICommandResult commandResult)
        {
            _robo = robo;
            _commandResult = commandResult;
        }

        public void ExecuteCommand(string[] command)
        {
            MovementActionResult executionResult;

            if (command == null)
                executionResult = new MovementActionResult(MovementStatus.RobotPlaceInvalidCommandParsed);
            else
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

                executionResult = actionResult as MovementActionResult;

            }

            _commandResult.ProcessResult(executionResult);
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
                        Direction = result[2].ToDirection() ?? FaceDirection.NORTH
                    };
                }
            }
            return null;
        }

        private object ReportStatus(ReportOptions opts)
        {
            return _robo.ReportStatus();
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
