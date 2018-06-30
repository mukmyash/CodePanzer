using CodePanzer.Abstractions.Map;
using System;

namespace CodePanzer.Abstractions.Panzer
{
    /// <summary>
    /// Командир танка
    /// </summary>
    public interface IPanzerCommander
    {
        /// <summary>
        /// Каким танком управляет командир
        /// </summary>
        CommanderType Type { get; }

        /// <summary>
        /// Получение исходных данных
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="startPosition">Начальная позиция</param>
        /// <param name="startDirection">Начальное направление</param>
        void Init(IMap map, IPosition startPosition, Direction startDirection);

        /// <summary>
        /// Отдать приказ
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="currentPosition">Текущая позиция</param>
        /// <param name="currentDirection">Текущее направление</param>
        CommanderCommand GetCommand(IMap map, IPosition currentPosition, Direction currentDirection);
    }
}
