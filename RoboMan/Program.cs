using RoboMan.Movement;
using System;

namespace RoboMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var robot = new Roboman(new Simple5x5Board(5));
            var command = new RoboCommand(robot);

            while (true)
            {
                var instructions = GetUserInstruction();
                if (instructions?.ToLower() != "exit")
                {
                    command.ExecuteCommand(instructions.Split());
                }
            }
        }

        private static string GetUserInstruction()
        {
            Console.WriteLine("#:");
            return Console.ReadLine();
        }
    }
}
