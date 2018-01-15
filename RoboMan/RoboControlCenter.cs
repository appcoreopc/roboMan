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
    class RoboControlCenter : IControlCenter
    {
        private IRobot _robo;
        private ICommandResult _commandResultHandler;

        public RoboControlCenter(IRobot robo, ICommandResult commandResult)
        {
            _robo = robo;
            _commandResultHandler = commandResult;
        }

        public void ExecuteCommand(string[] command)
        {
            MovementActionResult executionResult;

            if (command == null)
                executionResult = new MovementActionResult(MovementStatus.InvalidInstructionGiven);
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

                        errs => new MovementActionResult(MovementStatus.InvalidInstructionGiven));

                executionResult = actionResult as MovementActionResult;

            }

            _commandResultHandler.ProcessResult(executionResult);
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
                var locationInfo = placementCommandArgument?.Split(Appconstant.PlaceInstructionSeparator);
                if (locationInfo.Length == 3)
                {
                    var xlocation = locationInfo[Appconstant.LocationXIndex].ToInt();
                    var ylocation = locationInfo[Appconstant.LocationYIndex].ToInt();
                    var direction = locationInfo[Appconstant.DirectionIndex].ToDirection();
                 
                    if (direction != null && xlocation != null && ylocation != null)
                    {
                        return new ParsedPositionInstruction
                        {
                            LocationX = xlocation.Value,
                            LocationY = ylocation.Value,
                            Direction = direction.Value
                        };
                    }
                    else
                        return null;
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
