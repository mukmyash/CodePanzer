using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal class FasterPanzerBuilder : PanzerBuilder
    {
        public FasterPanzerBuilder(IPanzerCommander panzer) : base(panzer)
        {
        }

        public override void InitCharacteristics()
        {
            base._panzer.Health = 60;
            base._panzer.Damage = 6;
            base._panzer.StepsPerRound = 2;
        }
    }
}
