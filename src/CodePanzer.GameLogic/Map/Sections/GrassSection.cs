using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Sections
{
    internal class GrassSection : SectionBase
    {
        public override bool IsDestroy
        {
            get => false;
            set { throw new NotSupportedException("Невозможно разрушить траву"); }
        }

        public override bool CanDestroy => false;

        public override bool CanPositionTo => true;

        public override bool CanBuletThrought => true;

        public override SectionType Type => SectionType.Grass;
    }
}
