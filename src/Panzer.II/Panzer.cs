using CodePanzer.Abstractions;
using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.Abstractions.Panzer.Types;
using System;

namespace Panzer.II
{
    public class Panzer : PanzerCommanderDefaultType
    {
        private static Random _rnd = new Random();
        public override CommanderCommand GetCommand(IMap map, IPosition currentPosition, Direction currentDirection)
        {
            return  (CommanderCommand)_rnd.Next(0, 5);
        }

        public override void Init(IMap map, IPosition startPosition, Direction currentDirection)
        {

        }
    }
}
