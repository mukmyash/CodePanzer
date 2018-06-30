using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal class MoveForwardIntentMapModifyer : MoveBaseIntentMapModifyer
    {
        public MoveForwardIntentMapModifyer(GameMap currentMap) : base(currentMap)
        {
        }

        protected override (int positionX, int positionY) ModifyPosition(IPosition currentPosition, Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.East:
                    return (currentPosition.X + 1, currentPosition.Y);
                case Direction.North:
                    return (currentPosition.X, currentPosition.Y + 1);
                case Direction.South:
                    return (currentPosition.X, currentPosition.Y - 1);
                case Direction.West:
                    return (currentPosition.X - 1, currentPosition.Y);
                default:
                    throw new NotImplementedException("Данное направление не поддерживается");
            }
        }
    }
}
