using RoboMan.Command;
using RoboMan.Movement;
using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("RoboManTest")]

namespace RoboMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Appconstant.WelcomeString);

            var robot = new Roboman(new Simple5x5Board(Appconstant.DefaultBoardSize));
            var command = new RoboCommand(robot, new ConsoleCommandResult());

            while (true)
            {
                var instructions = GetUserInstruction().ToLower();     
                
                if (instructions != Appconstant.AppExitCommandString)
                {
                    command.ExecuteCommand(instructions.Split());
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
