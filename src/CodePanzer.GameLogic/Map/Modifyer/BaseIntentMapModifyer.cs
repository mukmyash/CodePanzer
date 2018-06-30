using System;
using System.Collections.Generic;
using System.Text;
using CodePanzer.Abstractions.Map;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal abstract class BaseIntentMapModifyer : IIntentMapModifyer
    {
        protected GameMap _currentMap;
        public BaseIntentMapModifyer(GameMap currentMap)
        {
            _currentMap = currentMap;
        }

        public abstract void Modify(IPanzer panzer);
    }
}
