using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal class ArmoredPanzerBuilder : PanzerBuilder
    {
        public ArmoredPanzerBuilder(IPanzerCommander panzer) : base(panzer)
        {
        }

        public override void InitCharacteristics()
        {
            base._panzer.Health = 200;
            base._panzer.Damage = 10; 
            base._panzer.StepsPerRound = 1;
        }
    }
}
