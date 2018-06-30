using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal class TurnRightIntentMapModifyer : BaseIntentMapModifyer
    {
        public TurnRightIntentMapModifyer(GameMap currentMap) : base(currentMap)
        {
        }

        public override void Modify(IPanzer panzer)
        {
            panzer.CurrentDirection = panzer.CurrentDirection.Next();
        }
    }
}
