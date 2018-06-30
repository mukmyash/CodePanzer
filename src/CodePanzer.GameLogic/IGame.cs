using System.Collections.Generic;
using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;

namespace CodePanzer.GameLogic
{
    public interface IGame
    {
        event EndRoundEventHandler EndRound;

        IMap CurrentMap { get; }

        void Init(IMap currentMap, IEnumerable<IPanzerCommander> commanders);
        void Start();
    }
}