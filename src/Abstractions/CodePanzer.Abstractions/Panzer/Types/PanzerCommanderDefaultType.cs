using System;
using System.Collections.Generic;
using System.Text;
using CodePanzer.Abstractions.Map;

namespace CodePanzer.Abstractions.Panzer.Types
{
    public abstract class PanzerCommanderDefaultType : PanzerCommanderBase
    {
        public override CommanderType Type => CommanderType.DefaultType;
    }
}
