using System.Collections.Generic;
using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.PanzerAction;

namespace CodePanzer.GameLogic
{
    public delegate void EndRoundEventHandler(IMap map, IDictionary<IPanzer, Intent> intents);
    public interface IGame
    {
        event EndRoundEventHandler EndRound;

        IMap CurrentMap { get; }

        void Init(IMap currentMap, IEnumerable<IPanzerCommander> commanders);
        void Start();
    }
}