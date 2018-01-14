using RoboMan.Movement;

namespace RoboMan
{
    class Roboman : IRobot
    {
        private IBoardRules _board;
        /// <summary>
        /// Park logic into the constructor     
        /// </summary>
        /// <param name="tableSize"></param>
        public Roboman(IBoardRules board)
        {
            _board = board;
        }

        public MovementActionResult Left()
        {
            return _board.ChangeDirection(MovementType.Left);
        }

        public MovementActionResult Move()
        {
            return _board.Move();
        }

        public MovementActionResult SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection)
        {
            return _board.SetPositionOnBoard(placementX, placementY, facingDirection);
        }

        public MovementActionResult Right()
        {
            return _board.ChangeDirection(MovementType.Right);
        }

        public MovementActionResult ReportStatus()
        {
            return _board.ReportStatus();
        }

        private MovementActionResult ChangeDirection(MovementType movement)
        {
            return _board.ChangeDirection(movement);
        }

    }
}
