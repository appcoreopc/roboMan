using RoboMan.Movement;
using System;

namespace RoboMan
{
    class Roboman : IRobot
    {
        private FaceDirection _facingDirection;

        private IMovementMechanics _movementMechanics;
        /// <summary>
        /// Park logic into the constructor 
        /// </summary>
        /// <param name="tableSize"></param>
        public Roboman(IMovementMechanics movementMechanics)
        {
            _movementMechanics = movementMechanics;
        }

        public bool Left()
        {
            return _movementMechanics.ChangeDirection(MovementType.Left);
        }

        public bool Move()
        {
            return _movementMechanics.Move();
        }

        public bool ChangeDirection(MovementType movement)
        {
            return _movementMechanics.ChangeDirection(movement);
        }

        public bool SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection)
        {
            return _movementMechanics.SetPositionOnBoard(placementX, placementY, facingDirection);
        }

        public bool Right()
        {
            return _movementMechanics.ChangeDirection(MovementType.Right);
        }

        public string ReportStatus()
        {
            return _movementMechanics.ReportStatus();
        }
        
    }
}
