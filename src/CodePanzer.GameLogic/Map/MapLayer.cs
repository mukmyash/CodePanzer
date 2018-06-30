using CodePanzer.Abstractions.Map;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map
{
    public class MapLayer<TLayerType> : ILayer<TLayerType>
    {
        private TLayerType[,] _layerInfo;

        public MapLayer(int width, int heigth)
        {
            _layerInfo = new TLayerType[width, heigth];
        }

        public TLayerType this[int x, int y]
        {
            get => _layerInfo[x, y];
            set => _layerInfo[x, y] = value;
        }

        public void MoveElement(IPosition prevPosition, IPosition newPosition)
        {
            //Вышли за пределы карты
            if (newPosition.X < 0 || Width > newPosition.X)
                throw new ArgumentException("Вышли за пределы карты X", nameof(newPosition.X));
            if (newPosition.Y < 0 || Heigth > newPosition.Y)
                throw new ArgumentException("Вышли за пределы карты Y", nameof(newPosition.Y));

            var obj = _layerInfo[prevPosition.X, prevPosition.Y];
            _layerInfo[newPosition.X, newPosition.Y] = obj;
            _layerInfo[prevPosition.X, prevPosition.Y] = default(TLayerType);

        }

        public int Width => _layerInfo.GetLength(0);
        public int Heigth => _layerInfo.GetLength(1);

        public int Count => _layerInfo.Length;

        public IEnumerator<TLayerType> GetEnumerator() => new CastEnumerator<TLayerType>(_layerInfo.GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator() => _layerInfo.GetEnumerator();
    }
}
