using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal class PanzerBuilderFactory : IPanzerBuilderFactory
    {
        public PanzerBuilder GetBuilder(IPanzerCommander panzer)
        {
            switch (panzer.Type)
            {
                case CommanderType.ArmoredType:
                    return new ArmoredPanzerBuilder(panzer);
                case CommanderType.FasterType:
                    return new FasterPanzerBuilder(panzer);
                case CommanderType.PowerfulType:
                    return new PowerfulPanzerBuilder(panzer);
                default:
                    return new DefaultPanzerBuilder(panzer);
            }
        }
    }
}
