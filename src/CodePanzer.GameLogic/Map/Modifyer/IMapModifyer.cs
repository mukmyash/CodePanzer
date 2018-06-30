using System.Collections.Generic;
using CodePanzer.GameLogic.PanzerAction;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal interface IMapModifyer
    {
        void Modify(GameMap currentMap, IDictionary<IPanzer, Intent> intents);
    }
}