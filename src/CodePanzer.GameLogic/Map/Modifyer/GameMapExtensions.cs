using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal static class GameMapExtensions
    {
        public static IIntentMapModifyer Modificator(this GameMap map, CommanderCommand command)
        {
            switch (command)
            {
                case CommanderCommand.Attack:
                    return new AttackIntentMapModifyer(map);
                case CommanderCommand.MoveBackward:
                    return new MoveBackwardIntentMapModifyer(map);
                case CommanderCommand.MoveForward:
                    return new MoveForwardIntentMapModifyer(map);
                case CommanderCommand.TurnLeft:
                    return new TurnLeftIntentMapModifyer(map);
                case CommanderCommand.TurnRight:
                    return new TurnRightIntentMapModifyer(map);
                case CommanderCommand.Wait:
                    return new WaitIntentMapModifyer(map);
                default:
                    throw new NotSupportedException("Данная команда не поддерживается");

            }
        }
    }
}
