using RoboMan.Movement;
using System.Runtime.CompilerServices;

namespace RoboMan.Command
{
   
    interface ICommandResult
    {
        void ProcessResult(MovementActionResult actionResult);
    }

}
