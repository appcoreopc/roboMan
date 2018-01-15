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
                else
                    return new MovementActionResult(MovementStatus.UnableToMoveToTargetLocation);

            }
            return new MovementActionResult(MovementStatus.RobotNotPlacedOnBoard);
        }

        public MovementActionResult ChangeDirection(MovementType movement)
        {
            if (IsRobotPlacedOnTheBoard())
            {
                var currentRobotFacingDirection = (int)_facingDirection;
                currentRobotFacingDirection += 1 * (movement == MovementType.Right ? 1 : -1);

                if (currentRobotFacingDirection == 5)
                    currentRobotFacingDirection = (int)FaceDirection.NORTH;

                if (currentRobotFacingDirection == 0)
                    currentRobotFacingDirection = (int)FaceDirection.WEST;

                _facingDirection = (FaceDirection)currentRobotFacingDirection;

                return movement == MovementType.Left ? new MovementActionResult(MovementStatus.TurnLeftSuccessful) :
                    new MovementActionResult(MovementStatus.TurnRightSuccessful);
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
                    _facingDirection, MovementStatus.ReportStatusOk);
            }
            return new MovementActionResult(MovementStatus.ReportStatusFailed);
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
         
            if (_facingDirection == FaceDirection.WEST)
                return _locationX.Value - 1;
            else if (_facingDirection == FaceDirection.EAST)
                return _locationX.Value + 1;
            else
                return _locationX.Value;
        }

        private int GetYMoved()
        {
            if (_facingDirection == FaceDirection.SOUTH)
                return _locationY.Value - 1;
            else if (_facingDirection == FaceDirection.NORTH)
                return _locationY.Value + 1;
            else
                return _locationY.Value;

        }
    }
}
