namespace RoboMan.Movement
{
    class Simple5x5Board : IBoardRules
    {
        private int? _locationX;
        private int? _locationY;
        private int _tableSize;
        private FaceDirection _facingDirection;

        public Simple5x5Board(int tableSize)
        {
            this._tableSize = tableSize;
        }

        public MovementActionResult Left()
        {
            return ChangeDirection(MovementType.Left);
        }

        public MovementActionResult Move()
        {
            if (IsRobotPlacedOnTheBoard())
            {
                var xNewPosition = GetXMoved();
                var yNewPosition = GetYMoved();

                if (IsLocationWithinBoard(xNewPosition, yNewPosition))
                {
                    _locationX = xNewPosition;
                    _locationY = yNewPosition;
                    return new MovementActionResult(MovementStatus.MoveOk);
                }
            }
            return new MovementActionResult(MovementStatus.UnableToMoveToTargetLocation);
        }

        public MovementActionResult ChangeDirection(MovementType movement)
        {
            if (IsRobotPlacedOnTheBoard())
            {
                var currentRobotFacingDirection = (int)_facingDirection;
                currentRobotFacingDirection += 1 * (movement == MovementType.Right ? 1 : -1);

                if (currentRobotFacingDirection == 5)
                    currentRobotFacingDirection = (int)FaceDirection.North;

                if (currentRobotFacingDirection == 0)
                    currentRobotFacingDirection = (int)FaceDirection.West;

                _facingDirection = (FaceDirection) currentRobotFacingDirection;

                return movement == MovementType.Left ? new MovementActionResult(MovementStatus.LeftTurnOk) : 
                    new MovementActionResult(MovementStatus.RightTurnOk);
            }
            return new MovementActionResult(MovementStatus.ChangeDirectionFailed);
        }

        public MovementActionResult SetPositionOnBoard(int placementX, int placementY, FaceDirection facingDirection)
        {
            if (IsLocationWithinBoard(placementX, placementY))
            {
                _locationX = placementX;
                _locationY = placementY;
                _facingDirection = facingDirection;
                return new MovementActionResult(MovementStatus.RobotPlacementSuccessful);
            }
            else if (placementX > _tableSize - 1)
                return new MovementActionResult(MovementStatus.MoveXOutOfBoardMaxSize);
            else if (placementX < 0)
                return new MovementActionResult(MovementStatus.MoveXOutOfBoardMinSize);
            else if (placementY > _tableSize - 1)
                return new MovementActionResult(MovementStatus.MoveYOutOfBoardMaxSize);
            else if (placementY < 0)
                return new MovementActionResult(MovementStatus.MoveYOutOfBoardMinSize);

            return new MovementActionResult(MovementStatus.MoveCannotBeDetermined);
        }

        public MovementActionResult Right()
        {
            return ChangeDirection(MovementType.Right);
        }

        public MovementActionResult ReportStatus()
        {
            if (IsRobotPlacedOnTheBoard())
            {
                return new MovementActionResult(_locationX, _locationY,
                    _facingDirection, MovementStatus.RobotPlacementSuccessful);
            }
            return new MovementActionResult(MovementStatus.RobotNotPlaced);
        }

        private bool IsLocationWithinBoard(int x, int y)
        {
            return (x >= 0 && y >= 0 && x <= _tableSize - 1 && y <= _tableSize - 1);
        }

        private bool IsRobotPlacedOnTheBoard()
        {
            return _locationX.HasValue && _locationY.HasValue;
        }

        private int GetXMoved()
        {
            //return _facingDirection == FaceDirection.West ? _locationX.Value - 1
            //    : _facingDirection == FaceDirection.East ? _locationX.Value + 1 : _locationX.Value;

            if (_facingDirection == FaceDirection.West)
                return _locationX.Value - 1;
            else if (_facingDirection == FaceDirection.East)
                return _locationX.Value + 1;
            else
                return _locationX.Value;
        }

        private int GetYMoved()
        {
            if (_facingDirection == FaceDirection.South)
                return _locationY.Value - 1;
            else if (_facingDirection == FaceDirection.North)
                return _locationY.Value + 1;
            else
                return _locationY.Value;

            //return _facingDirection == FaceDirection.South ? _locationY.Value - 1
            //    : _facingDirection == FaceDirection.North ? _locationY.Value + 1 : _locationY.Value;
        }
    }
}
