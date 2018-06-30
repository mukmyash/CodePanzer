using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal abstract class MoveBaseIntentMapModifyer : BaseIntentMapModifyer
    {
        public MoveBaseIntentMapModifyer(GameMap currentMap) : base(currentMap)
        {
        }

        public override void Modify(IPanzer panzer)
        {
            var sections = _currentMap.Sections;
            var enemies = _currentMap.LocationOfForces;

            var (positionX, positionY) = ModifyPosition(panzer.CurrentPosition, panzer.CurrentDirection);

            //Вышли за пределы карты
            if (positionX < 0 || _currentMap.Width <= positionX)
                return;
            if (positionY < 0 || _currentMap.Heigth <= positionY)
                return;

            //В секцию невозможно встать
            if (!sections[positionY, positionX].CanPositionTo)
                return;

            //Танка в области
            if (enemies[positionY, positionX] != null)
                return;

            enemies.MoveElement(
                new Position(panzer.CurrentPosition.X, panzer.CurrentPosition.Y),
                new Position(positionX, positionY));

            panzer.CurrentPosition.X = positionX;
            panzer.CurrentPosition.Y = positionY;
        }

        protected abstract (int positionX, int positionY) ModifyPosition(IPosition currentPosition, Direction currentDirection);
    }
}
