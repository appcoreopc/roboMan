using RoboMan.Command;
using RoboMan.Movement;
using StructureMap;
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
            
            var container = new Container(_ =>
            {               
                var boardSetup = _.For<IBoardRules>().Use<Simple5x5Board>().
                Ctor<int>(Appconstant.ContainerSetupBoardArgumentTableSize).Is(Appconstant.DefaultBoardSize);

                var commandResult = _.For<ICommandResult>().Use<ConsoleCommandResult>();

                var roboCharacter = _.For<IRobot>().Use<Roboman>().Ctor<IBoardRules>().Is(boardSetup);

                var commandCenter = _.For<IControlCenter>().Use<RoboControlCenter>().
                Ctor<IRobot>().Is(roboCharacter).Ctor<ICommandResult>().Is(commandResult);
                
            });


            var controlCenter = container.GetInstance<IControlCenter>();
          
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
