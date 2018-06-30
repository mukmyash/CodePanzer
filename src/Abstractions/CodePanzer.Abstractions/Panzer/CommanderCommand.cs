using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Panzer
{
    /// <summary>
    /// Приказы командира танка
    /// </summary>
    public enum CommanderCommand
    {
        /// <summary>
        /// Повернуть налево
        /// </summary>
        TurnLeft,

        /// <summary>
        /// Повернуть направо
        /// </summary>
        TurnRight,

        /// <summary>
        /// Движение вперед
        /// </summary>
        MoveForward,

        /// <summary>
        /// Движение назад
        /// </summary>
        MoveBackward,

        /// <summary>
        /// Огонь
        /// </summary>
        Attack,

        /// <summary>
        /// Ждать
        /// </summary>
        Wait,
    }
}
