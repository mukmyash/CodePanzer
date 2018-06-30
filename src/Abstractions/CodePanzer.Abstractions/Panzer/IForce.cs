using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.Abstractions.Panzer
{
    /// <summary>
    /// Боевая единица
    /// </summary>
    public interface IForce
    {
        Guid UID { get; }

        short Health { get; }

        ushort StepsPerRound { get; }

        ushort Damage { get; }

        CommanderType Type { get; }

        /// <summary>
        /// Текущее направление
        /// </summary>
        Direction CurrentDirection { get; }
    }
}
