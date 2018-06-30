using System.Collections.Generic;
using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.PanzerAction;

namespace CodePanzer.GameLogic
{
    internal interface IGameRound
    {
        IDictionary<IPanzer, Intent> StartRound(IMap currentMap, IEnumerable<IPanzer> panzers);
    }
}