using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Sections
{
    /// <summary>
    /// Железная стена
    /// </summary>
    internal class IronWallSection : SectionBase
    {
        public override bool CanDestroy => false;

        public override bool CanPositionTo => false;

        public override bool IsDestroy
        {
            get => false;
            set { throw new NotSupportedException("Невозможно разрушить железную стену"); }
        }

        public override bool CanBuletThrought => false;

        public override SectionType Type => SectionType.IronWall;
    }
}
