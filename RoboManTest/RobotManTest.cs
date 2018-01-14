using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboMan;
using RoboMan.Movement;

namespace RoboManTest
{
    [TestClass]
    public class RobotManTest
    {

        private IBoardRules _board;
        private Roboman _roboman;

        [TestInitialize]
        public void Setup()
        {
            _board = new Simple5x5Board(Appconstant.DefaultBoardSize);
            _roboman = new Roboman(_board);
        }

        [TestMethod]
        public void PlaceRobotWithinBoardTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 0, FaceDirection.NORTH);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Status == MovementStatus.RobotPlacementSuccessful);
        }

        [TestMethod]
        public void PlaceRobotOutOfBoardSizeTest()
        {
            var result = _roboman.SetPositionOnBoard(10, 10, FaceDirection.NORTH);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Status == MovementStatus.MoveXOutOfBoardMaxSize || result.Status == MovementStatus.MoveYOutOfBoardMaxSize);
        }

        [TestMethod]
        public void MoveWithinYAxiValidTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);
            var validMovement = _roboman.Move();
            Assert.IsTrue(validMovement.Status == MovementStatus.MoveOk);

        }

        [TestMethod]
        public void MoveOutsideYAxiTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);

            _roboman.Move();

            var invalidMovement = _roboman.Move();

            Assert.IsTrue(invalidMovement.Status == MovementStatus.UnableToMoveToTargetLocation);
        }

        
        [TestMethod]
        public void LeftTurnDirectionValidTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);

            _roboman.Left();

            var currentDirection = _roboman.ReportStatus();

            Assert.IsTrue(currentDirection.Direction == FaceDirection.WEST);
        }

        [TestMethod]
        public void LeftTurnSouthValidTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);

            _roboman.Left();

            _roboman.Left();

            var currentDirection = _roboman.ReportStatus();

            Assert.IsTrue(currentDirection.Direction == FaceDirection.SOUTH);
        }



        [TestMethod]
        public void RightTurnDirectionValidTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);

            _roboman.Right();

            var currentDirection = _roboman.ReportStatus();

            Assert.IsTrue(currentDirection.Direction == FaceDirection.EAST);
        }


        [TestMethod]
        public void ThreeSixtyTurnDirectionValidTest()
        {
            var result = _roboman.SetPositionOnBoard(0, 3, FaceDirection.NORTH);

            _roboman.Right();
            _roboman.Right();
            _roboman.Right();
            _roboman.Right();

            var currentDirection = _roboman.ReportStatus();

            Assert.IsTrue(currentDirection.Direction == FaceDirection.NORTH);
        }

        [TestMethod]
        public void XAxisMovementTest()
        {
            var result = _roboman.SetPositionOnBoard(3, 0, FaceDirection.EAST);
            
            var validMovementResult = _roboman.Move();

            var outOfXAxisMovementResult = _roboman.Move();

            Assert.IsTrue(validMovementResult.Status == MovementStatus.MoveOk);

            Assert.IsTrue(outOfXAxisMovementResult.Status == MovementStatus.UnableToMoveToTargetLocation);

        }
        

        [TestMethod]
        public void XAxisMovementToWestDirectionOutOfArea()
        {
            var result = _roboman.SetPositionOnBoard(3, 1, FaceDirection.EAST);

            _roboman.Right();

            _roboman.Right();

            var testDirectionResult = _roboman.ReportStatus();
            
            Assert.IsTrue(testDirectionResult.Direction == FaceDirection.WEST);

            _roboman.Move();

            _roboman.Move();

            var expectedMovementValidResult = _roboman.Move();

            Assert.IsTrue(expectedMovementValidResult.Status == MovementStatus.MoveOk);

            var expectedInValidResult = _roboman.Move();

            Assert.IsTrue(expectedInValidResult.Status == MovementStatus.UnableToMoveToTargetLocation);









        }







    }
}
