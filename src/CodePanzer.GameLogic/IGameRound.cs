using System.Collections.Generic;
using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.PanzerAction;

namespace CodePanzer.GameLogic
{
    internal interface IGameRound
    {
        void StartRound(IMap currentMap, IEnumerable<IPanzer> panzers);
    }
}