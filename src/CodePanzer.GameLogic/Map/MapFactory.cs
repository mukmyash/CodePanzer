using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.Map.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map
{
    public class MapFactory
    {
        public IMap GetMap()
        {
            var map = new GameMap(10, 10);
            var sections= new MapLayer<ISection>(10, 10);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    sections[i, j] = new RoadSection(); 
            }
            sections[0, 0] = new WaterSection();
            sections[0, 9] = new BrickWallSection();
            sections[9, 9] = new IronWallSection();

            map.Sections = sections;
            
            return map;
        }
    }
}
