using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboMan;
using RoboMan.Command;
using NSubstitute;
using RoboMan.Movement;

namespace RoboManTest
{
    [TestClass]
    public class ControlCenterTest
    {
        private ICommandResult _commandResult;
        private IRobot _roboman;

        private IControlCenter _controlCenter;

        [TestInitialize]
        public void Setup()
        {
            _commandResult = Substitute.For<ICommandResult>();
            _roboman = Substitute.For<IRobot>();

            _controlCenter = new RoboControlCenter(_roboman, _commandResult);
        }

        [TestMethod]
        public void NullCommandTest()
        {

            _controlCenter.ExecuteCommand(null);

            // Assert IRobot 

            _roboman.DidNotReceive().Left();

            _roboman.DidNotReceive().Move();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            var expectedInvalidInstruction = new MovementActionResult(MovementStatus.InvalidInstructionGiven);

            _commandResult.Received().ProcessResult(Arg.Is<MovementActionResult>(x => x.Status == MovementStatus.InvalidInstructionGiven));
            
        }


        [TestMethod]
        public void InvalidCommandTest()
        {
            string[] commandStringInput = { "MOOVE" };

            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.DidNotReceive().Left();

            _roboman.DidNotReceive().Move();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert ICommandResult was never called 

            _commandResult.Received().ProcessResult(Arg.Is<MovementActionResult>(x => x.Status == MovementStatus.InvalidInstructionGiven));

        }


        [TestMethod]
        public void ExecuteMoveCommandSuccessfulTest()
        {
            string[] commandStringInput = { "move" };

            var expectedActionResult = new MovementActionResult(MovementStatus.MoveOk);

            _roboman.Move().Returns(expectedActionResult);

            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.Received().Move();

            _roboman.DidNotReceive().Left();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert ICommandResult was called with the proper actionResult

            _commandResult.Received().ProcessResult(expectedActionResult);

        }


        [TestMethod]
        public void ExecuteLeftCommandSuccessfulTest()
        {
            string[] commandStringInput = { "left" };

            var expectedActionResult = new MovementActionResult(MovementStatus.TurnLeftSuccessful);

            _roboman.Left().Returns(expectedActionResult);

            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.DidNotReceive().Move();

            _roboman.Received().Left();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert ICommandResult was called with the proper actionResult

            _commandResult.Received().ProcessResult(expectedActionResult);

        }

        [TestMethod]
        public void ExecuteRightCommandSuccessfulTest()
        {
            var subject = new RoboControlCenter(_roboman, _commandResult);

            string[] commandStringInput = { "right" };

            var expectedActionResult = new MovementActionResult(MovementStatus.TurnRightSuccessful);

            _roboman.Right().Returns(expectedActionResult);

            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.DidNotReceive().Move();

            _roboman.DidNotReceive().Left();

            _roboman.Received().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert ICommandResult was called with the proper actionResult

            _commandResult.Received().ProcessResult(expectedActionResult);
        }

        [TestMethod]
        public void ExecutePlaceCommandSuccessfulTest()
        {
            var subject = new RoboControlCenter(_roboman, _commandResult);

            string[] commandStringInput = { "place", "1,1,north" };

            var expectedActionResult = new MovementActionResult(MovementStatus.RobotPlacementSuccessful);

            _roboman.SetPositionOnBoard(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<FaceDirection>()).ReturnsForAnyArgs(expectedActionResult);

            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.DidNotReceive().Move();

            _roboman.DidNotReceive().Left();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert roboman is the same with given command string //
             
            _roboman.Received().SetPositionOnBoard(1, 1, FaceDirection.NORTH);
            
            // Assert ICommandResult was called with the proper actionResult

            _commandResult.Received().ProcessResult(expectedActionResult);
            
            
        }

        [TestMethod]
        public void ExecuteInvalidPlaceCommandSuccessfulTest()
        {
            var subject = new RoboControlCenter(_roboman, _commandResult);

            string[] commandStringInput = { "place", "1,1,DOWNTOWN" };          
                                               
            _controlCenter.ExecuteCommand(commandStringInput);

            // Assert IRobot 

            _roboman.DidNotReceive().Move();

            _roboman.DidNotReceive().Left();

            _roboman.DidNotReceive().Right();

            _roboman.DidNotReceive().ReportStatus();

            // Assert roboman is the same with given command string //

            _roboman.DidNotReceive().SetPositionOnBoard(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<FaceDirection>());

            // Assert ICommandResult was called with the proper actionResult

            _commandResult.Received().ProcessResult(Arg.Is<MovementActionResult>(x => x.Status == MovementStatus.RobotPlaceInvalidCommandParsed));

        }

    }
}


