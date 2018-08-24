using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic
{
    public interface IPanzer : IForce
    {
        /// <summary>
        /// Здоровье
        /// </summary>
        new short Health { get; set; }

        /// <summary>
        /// Штраф за долгий алгоритм =)
        /// </summary>
        ushort Fine { get; set; }

        /// <summary>
        /// Скорость танка (кол-во шагов за ход)
        /// </summary>
        new ushort StepsPerRound { get; set; }

        /// <summary>
        /// Скорость передвижения
        /// </summary>
        new ushort Damage { get; set; }

        /// <summary>
        /// Текущая позиция
        /// </summary>
        new IPosition CurrentPosition { get; set; }

        /// <summary>
        /// Текущее направление
        /// </summary>
        new Direction CurrentDirection { get; set; }

        /// <summary>
        /// Подготовка танка
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="startPosition">Начальная позиция</param>
        void Init(IMap map, IPosition startPosition, Direction startDirection);

        /// <summary>
        /// Желаемое действие танка
        /// </summary>
        /// <param name="map">Карта</param>
        (double elapsedMillisecond, CommanderCommand command) GetIntent(IMap map);
    }
}
