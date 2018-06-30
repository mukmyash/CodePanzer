using System;
using System.Collections.Generic;
using System.Text;
using CodePanzer.Abstractions.Map;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal class TurnLeftIntentMapModifyer : BaseIntentMapModifyer
    {
        public TurnLeftIntentMapModifyer(GameMap currentMap) : base(currentMap)
        {
        }

        public override void Modify(IPanzer panzer)
        {
            panzer.CurrentDirection = panzer.CurrentDirection.Prev();
        }
    }
}
