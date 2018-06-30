using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Panzer
{
    public enum CommanderType
    {
        /// <summary>
        /// Стандартный танк
        /// </summary>
        DefaultType,

        /// <summary>
        /// Танк с увеличенной атакой
        /// </summary>
        PowerfulType,

        /// <summary>
        /// Танк делающий несколько шагов за ход
        /// </summary>
        FasterType,

        /// <summary>
        /// Бронированный танк
        /// </summary>
        ArmoredType,
    }
}
