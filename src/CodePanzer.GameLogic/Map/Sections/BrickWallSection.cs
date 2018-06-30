using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Sections
{
    /// <summary>
    /// Кирпичная стена
    /// </summary>
    internal class BrickWallSection : SectionBase
    {
        public override bool CanDestroy => !IsDestroy;
        public override bool CanPositionTo => IsDestroy;
        public override bool IsDestroy { get; set; } = false;
        public override bool CanBuletThrought => IsDestroy;

        public override SectionType Type => SectionType.BrickWall;
    }
}
