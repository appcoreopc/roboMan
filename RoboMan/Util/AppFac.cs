using RoboMan.Command;
using RoboMan.Movement;
using StructureMap;

namespace RoboMan.Util
{
    class AppFac
    {       
        public static Container Setup()
        {            
            return new Container(_ =>
            {
                var boardSetup = _.For<IBoardRules>().Use<Simple5x5Board>().
                Ctor<int>(Appconstant.ContainerSetupBoardArgumentTableSize).Is(Appconstant.DefaultBoardSize);

                var commandResult = _.For<ICommandResult>().Use<ConsoleCommandResult>();

                var roboCharacter = _.For<IRobot>().Use<Roboman>().Ctor<IBoardRules>().Is(boardSetup);

                var commandCenter = _.For<IControlCenter>().Use<RoboControlCenter>().
                Ctor<IRobot>().Is(roboCharacter).Ctor<ICommandResult>().Is(commandResult);

            });
        }
    }
}
