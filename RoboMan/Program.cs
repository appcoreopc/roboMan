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
            Console.WriteLine("Welome to Robo World !");

            var robot = new Roboman(new Simple5x5Board(5));
            var command = new RoboCommand(robot, new ConsoleCommandResult());

            while (true)
            {
                var instructions = GetUserInstruction();
                if (instructions?.ToLower() != Appconstant.AppExitCommandString)
                {
                    command.ExecuteCommand(instructions.Split());
                }
            }
        }

        private static string GetUserInstruction()
        {
            Console.Write("#:");
            return Console.ReadLine();
        }
    }
}
