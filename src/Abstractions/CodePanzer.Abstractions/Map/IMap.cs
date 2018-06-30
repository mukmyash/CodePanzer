using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Map
{
    /// <summary>
    /// Карта
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// Кол-во секций по горизонтали
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Кол-во секций по вертифкали
        /// </summary>
        int Heigth { get; }

        /// <summary>
        /// Описание секций на карте
        /// </summary>
        ILayer<ISection> Sections { get; }

        /// <summary>
        /// Расположение сил.
        /// </summary>
        ILayer<IForce> LocationOfForces { get; }

    }
}
