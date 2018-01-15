using CommandLine;

namespace RoboMan.Command
{
    [Verb("place", HelpText = "Place robot on a given board")]
    class PlaceOptions
    {        
        [Value(0)]
        public string PlacementCommandArgument { get; set; }

    }
}
