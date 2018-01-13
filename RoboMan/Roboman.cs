using RoboMan.Movement;
using System;

namespace RoboMan
{
    class Roboman : IRobot
    {
        private FaceDirection _facingDirection;

        private IBoardRules _board;
        /// <summary>
        /// Park logic into the constructor     
        /// </summary>
        /// <param name="tableSize"></param>
        public Roboman(IBoardRules board)
        {
            _board = board;
        }

        public bool Left()
        {
            return _board.ChangeDirection(MovementType.Left);
        }

        public bool Move()
        {
            return _board.Move();
        }

        public bool ChangeDirection(MovementType movement)
        {
            return _board.ChangeDirection(movement);
        }

        public bool SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection)
        {
            return _board.SetPositionOnBoard(placementX, placementY, facingDirection);
        }

        public bool Right()
        {
            return _board.ChangeDirection(MovementType.Right);
        }

        public string ReportStatus()
        {
            return _board.ReportStatus();
        }
        
    }
}
