using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Panzer.Types
{
    public abstract class PanzerCommanderFasterType : PanzerCommanderBase
    {
        public override CommanderType Type => CommanderType.FasterType;
    }
}
