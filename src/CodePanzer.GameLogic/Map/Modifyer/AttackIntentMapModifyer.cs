using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.Map.Sections;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal class AttackIntentMapModifyer : BaseIntentMapModifyer
    {
        const int BULLET_SPEED = 3;

        public AttackIntentMapModifyer(GameMap currentMap) : base(currentMap)
        {
        }

        public override void Modify(IPanzer panzer)
        {
            var panzerLayer = _currentMap.LocationOfForces;
            var sectionLayer = _currentMap.Sections;

            for (int i = 1; i <= BULLET_SPEED; i++)
            {
                var (positionX, positionY) = CalcPosition(panzer.CurrentPosition, panzer.CurrentDirection, i);

                //Вышли за пределы карты
                if (positionX < 0 || _currentMap.Width <= positionX)
                    break;
                if (positionY < 0 || _currentMap.Heigth <= positionY)
                    break;

                var enemy = panzerLayer[positionY, positionX] as Panzer;
                if (enemy != null && enemy.Health != 0)
                {
                    enemy.Health -= (short)panzer.Damage;
                    if (enemy.Health < 0)
                        enemy.Health = 0;
                    break;
                }

                var section = sectionLayer[positionY, positionX] as SectionBase;
                if (!section.CanBuletThrought)
                {
                    if (section.CanDestroy)
                        section.IsDestroy = true;
                    break;
                }

            }
        }

        private (int positionX, int positionY) CalcPosition(IPosition currentPosition, Direction currentDirection, int step)
        {
            switch (currentDirection)
            {
                case Direction.East:
                    return (currentPosition.X + step, currentPosition.Y);
                case Direction.North:
                    return (currentPosition.X, currentPosition.Y + step);
                case Direction.South:
                    return (currentPosition.X, currentPosition.Y - step);
                case Direction.West:
                    return (currentPosition.X - step, currentPosition.Y);
                default:
                    throw new NotImplementedException("Данное направление не поддерживается");
            }
        }
    }
}