using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal abstract class PanzerBuilder
    {
        protected IPanzer _panzer;

        public PanzerBuilder(IPanzerCommander panzer)
        {
            if (panzer == null)
                throw new ArgumentException("Panzer can't be null.", nameof(panzer));
            _panzer = new Panzer(panzer);
        }

        /// <summary>
        /// Установка характеристик танка
        /// </summary>
        public abstract void InitCharacteristics();

        /// <summary>
        /// Установка начального положения
        /// </summary>
        /// <param name="map"></param>
        public void InitPosition(IMap map)
        {
            for (int y = 0; y < map.Heigth; y++)
                for (int x = 0; x < map.Width; x++)
                {
                    if (map.LocationOfForces[y, x] != null)
                        continue;
                    _panzer.Init(map, new Position(x, y), Direction.West);
                    return;
                }
        }

        public IPanzer GetResult()
        {
            return _panzer;
        }
    }
}
