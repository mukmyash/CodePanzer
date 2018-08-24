using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.Map.Generator;
using CodePanzer.GameLogic.Map.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map
{
    public class MapFactory
    {
        IMapGenerator mapGenerator;

        public MapFactory(IMapGenerator mapGenerator)
        {
            this.mapGenerator = mapGenerator;
        }

        public IMap GetMap(int width, int heigth, int countPanzer)
        {
            return mapGenerator.CreateMap(width, heigth, countPanzer);
        }
    }
}
