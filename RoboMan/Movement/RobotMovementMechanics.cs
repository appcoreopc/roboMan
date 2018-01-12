using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMan.Movement
{
    class RobotMovementMechanics : IMovementMechanics
    {
        private int? _locationX;
        private int? _locationY;
        private int _tableSize;
        private FaceDirection _facingDirection;

        public RobotMovementMechanics(int tableSize)
        {
            _tableSize = tableSize;
        }

        public bool Left()
        {
            return ChangeDirection(MovementType.Left);
        }

        public bool Move()
        {
            if (IsRobotPlacedOnTheBoard())
            {
                var xNewPosition = GetXMoved();
                var yNewPosition = GetYMoved();

                if (IsLocationWithinBoard(xNewPosition, yNewPosition))
                {
                    _locationX = xNewPosition;
                    _locationY = yNewPosition;
                    return true;
                }
            }
            return false;
        }

        public bool ChangeDirection(MovementType movement)
        {
            if (IsRobotPlacedOnTheBoard())
            {
                var currentRobotFacingDirection = (int)_facingDirection;
                currentRobotFacingDirection += 1 * (movement == MovementType.Right ? 1 : -1);

                if (currentRobotFacingDirection == 5)
                    currentRobotFacingDirection = (int)FaceDirection.North;

                if (currentRobotFacingDirection == 0)
                    currentRobotFacingDirection = (int)FaceDirection.West;

                _facingDirection = (FaceDirection)currentRobotFacingDirection;

                return true;
            }
            return false;
        }

        public bool SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection)
        {
            if (IsLocationWithinBoard(placementX, placementY))
            {
                _locationX = placementX;
                _locationY = placementY;
                _facingDirection = facingDirection;
                return true;
            }
            return false;
        }

        public bool Right()
        {
            return ChangeDirection(MovementType.Right);
        }

        public string ReportStatus()
        {
            if (IsRobotPlacedOnTheBoard())
            {
                return "";
            }
            return string.Empty;
        }

        private bool IsLocationWithinBoard(int x, int y)
        {
            return (x > 0 || y > 0 || x >= _tableSize && y >= _tableSize);
        }

        private bool IsRobotPlacedOnTheBoard()
        {
            return _locationX.HasValue && _locationY.HasValue;
        }

        private int GetXMoved()
        {
            return _facingDirection == FaceDirection.West ? _locationX.Value - 1
                : _facingDirection == FaceDirection.East ? _locationX.Value + 1 : _locationX.Value;
        }

        private int GetYMoved()
        {
            return _facingDirection == FaceDirection.South ? _locationY.Value - 1
                : _facingDirection == FaceDirection.North ? _locationX.Value + 1 : _locationX.Value;
        }
    }
}
