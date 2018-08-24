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
                throw new ArgumentException("Panzer commander can't be null.", nameof(panzer));
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
                    //Если уже кто-то там есть, то ни кого не устанавливаем
                    if (map.LocationOfForces[y, x] != null)
                        continue;
                    //Если в секцию невозможно разметить ни кого то ни чего и не делаем
                    if (!map.Sections[x, y].CanPositionTo)
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
