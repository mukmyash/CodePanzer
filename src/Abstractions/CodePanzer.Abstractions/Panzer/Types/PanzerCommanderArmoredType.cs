using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Panzer.Types
{
    public abstract class PanzerCommanderArmoredType : PanzerCommanderBase
    {
        public override CommanderType Type => CommanderType.ArmoredType;
    }
}
