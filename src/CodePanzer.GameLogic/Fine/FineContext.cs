using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.PanzerAction;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Fine
{
    internal class FineContext
    {
        public IPanzer Panzer { get; set; }
        public Intent Intent { get; set; }
    }
}
