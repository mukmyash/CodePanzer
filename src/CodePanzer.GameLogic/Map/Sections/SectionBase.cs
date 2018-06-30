using CodePanzer.Abstractions.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map.Sections
{
    internal abstract class SectionBase : ISection
    {
        public abstract bool IsDestroy { get; set; }

        public abstract bool CanDestroy { get; }

        public abstract bool CanPositionTo { get; }

        public abstract bool CanBuletThrought { get; }

        public abstract SectionType Type { get; };
    }
}
