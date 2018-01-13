using System;
using CommandLine;

namespace RoboMan
{

    [Verb("place", HelpText = "Place robot on a given board")]
    class PlaceOptions
    {
        //normal options here
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
            var x = CommandLine.Parser.Default.ParseArguments<PlaceOptions, MoveOptions, LeftOptions, RightOptions, ReportOptions>(command)
           .MapResult(
           (PlaceOptions opts) => PlaceRobot(opts),
           (MoveOptions opts) => RunAddAndReturnExitCode(opts),
           (LeftOptions opts) => RunCommitAndReturnExitCode(opts),
           (RightOptions opts) => RunCloneAndReturnExitCode(opts),
           (ReportOptions opts) => RunReportOption(opts),
           errs => 1);
        }

        private object PlaceRobot(PlaceOptions opts)
        {
            throw new NotImplementedException();
        }

        private object RunReportOption(ReportOptions opts)
        {
            throw new NotImplementedException();
        }

        private object RunCloneAndReturnExitCode(RightOptions opts)
        {
            throw new NotImplementedException();
        }

        private object RunCommitAndReturnExitCode(LeftOptions opts)
        {
            return 1;
        }

        private object RunAddAndReturnExitCode(MoveOptions opts)
        {
            return 0;
        }
    }
}
