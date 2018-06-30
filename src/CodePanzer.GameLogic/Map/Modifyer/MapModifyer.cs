using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.PanzerAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal class MapModifyer : IMapModifyer
    {
        public void Modify(GameMap currentMap, IDictionary<IPanzer, Intent> intents)
        {
            foreach (var panzerIntent in intents.OrderBy(n => n.Value.AVGMillesecondsOnStep))
            {
                foreach (var (MillesecondsOnStep, Command) in panzerIntent.Value.CommandInfo)
                {
                    currentMap.Modificator(Command).Modify(panzerIntent.Key);
                }
            }
        }
    }
}
