using RoboMan.Util;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RoboManTest")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace RoboMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Appconstant.WelcomeString);

            var componentContainer = AppFac.Setup();

            var controlCenter = componentContainer.GetInstance<IControlCenter>();
          
            while (true)
            {
                var instructions = GetUserInstruction().ToLower();     
                
                if (instructions != Appconstant.AppExitCommandString)
                {
                    controlCenter.ExecuteCommand(instructions.Split());
                }
            }
        }

        private static string GetUserInstruction()
        {
            Console.Write(Appconstant.CommandPrompt);
            return Console.ReadLine();
        }
    }
}
