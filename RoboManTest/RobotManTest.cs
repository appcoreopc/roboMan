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
            var result = _roboman.SetPositionOnBoard(0, 0, FaceDirection.North);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Status == MovementStatus.RobotPlacementSuccessful);
        }

        [TestMethod]
        public void PlaceRobotOutOfBoardSize()
        {
            var result = _roboman.SetPositionOnBoard(10, 10, FaceDirection.North);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Status == MovementStatus.MoveXOutOfBoardMaxSize || result.Status == MovementStatus.MoveYOutOfBoardMaxSize);
        }


    }
}
