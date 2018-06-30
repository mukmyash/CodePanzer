using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal class PanzerFactory : IPanzerFactory
    {
        IPanzerBuilderFactory _builderFactory;
        public PanzerFactory(IPanzerBuilderFactory builderFactory)
        {
            _builderFactory = builderFactory;
        }

        public IPanzer GetPanzer(IMap map, IPanzerCommander panzer)
        {
            PanzerBuilder builder = _builderFactory.GetBuilder(panzer);

            builder.InitCharacteristics();
            builder.InitPosition(map);

            return builder.GetResult();
        }
    }
}
