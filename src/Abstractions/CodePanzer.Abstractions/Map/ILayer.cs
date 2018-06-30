using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Map
{
    public interface ILayer<TLayerType> : IReadOnlyCollection<TLayerType>
    {
        TLayerType this[int x, int y] { get; }
        int Width { get; }
        int Heigth { get; }
    }
}
