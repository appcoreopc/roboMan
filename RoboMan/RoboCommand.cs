using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMan
{

    /// <summary>
    ///  Implementatioin of Command pattern 
    /// </summary>
    class RoboCommand
    {

        private IRobo _robo;
        public RoboCommand(IRobo robo)
        {
            _robo = robo;
        }

    }
}
