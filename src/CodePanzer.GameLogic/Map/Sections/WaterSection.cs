using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Sections
{
    /// <summary>
    /// Секция с водой
    /// </summary>
    internal class WaterSection : SectionBase
    {
        public override bool IsDestroy
        {
            get => false;
            set { throw new NotSupportedException("Невозможно разрушить воду"); }
        }

        public override bool CanDestroy => false;

        public override bool CanPositionTo => false;

        public override bool CanBuletThrought => true;
        public override SectionType Type => SectionType.Water;
    }
}
