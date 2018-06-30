using System;
using System.Collections.Generic;
using System.Text;
using CodePanzer.Abstractions.Map;

namespace CodePanzer.Abstractions.Panzer
{
    public abstract class PanzerCommanderBase : IPanzerCommander
    {
        public abstract CommanderType Type { get; }

        public abstract CommanderCommand GetCommand(IMap map, IPosition currentPosition, Direction currentDirection);
        
        public abstract void Init(IMap map, IPosition startPosition, Direction currentDirection);
        
    }
}
