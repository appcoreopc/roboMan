
namespace RoboMan
{

    /// <summary>
    ///  Implementatioin of Command pattern 
    /// </summary>
    class RoboCommand
    {
        private IRobot _robo;

        public RoboCommand(IRobot robo)
        {
            _robo = robo;
        }

    }
}
