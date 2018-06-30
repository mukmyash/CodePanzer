using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Map
{
    /// <summary>
    /// Секция на карте
    /// </summary>
    public interface ISection
    {
        /// <summary>
        /// Тип секции
        /// </summary>
        SectionType Type { get; }
        
        /// <summary>
        /// Разрушена ли секция.
        /// </summary>
        bool IsDestroy { get; }

        /// <summary>
        /// Можно ли разрушить секцию.
        /// </summary>
        bool CanDestroy { get; }

        /// <summary>
        /// Можно ли переместиться в секцию
        /// </summary>
        bool CanPositionTo { get; }

        /// <summary>
        /// Может ли пуля пролететь область
        /// </summary>
        bool CanBuletThrought { get; }
    }
}
