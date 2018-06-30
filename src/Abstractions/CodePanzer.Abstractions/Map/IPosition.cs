using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Map
{
    /// <summary>
    /// Координаты
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Координата X
        /// </summary>
        int X { get; }

        /// <summary>
        /// Координата Y
        /// </summary>
        int Y { get; }
    }
}
