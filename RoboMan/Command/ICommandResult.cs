using RoboMan.Movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMan.Command
{
    interface ICommandResult
    {

        void GetResult(MovementActionResult actionResult);
    }

}
