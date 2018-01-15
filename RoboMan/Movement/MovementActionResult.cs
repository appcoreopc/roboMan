
namespace RoboMan.Movement
{

    class MovementActionResult
    {
        public MovementActionResult(MovementStatus movementStatus)
        {
            Status = movementStatus;
        }

        public MovementActionResult(int? x, int? y,  FaceDirection facedirection, MovementStatus movementStatus)
        {
            LocationX = x;
            LocationY = y;
            Direction = facedirection;            
            Status = movementStatus;
        }

        public int? LocationX { get; set; }

        public int? LocationY { get; set; }

        public FaceDirection Direction { get; set; }

        public MovementStatus Status { get; set; }
    }

    
}
