using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic.PanzerAction
{
    internal class Intent
    {
        public Intent(IPanzer panzer, IEnumerable<(double MillesecondsOnStep, CommanderCommand Command)> commandInfo)
        {
            Panzer = panzer;
            AVGMillesecondsOnStep = commandInfo.Sum(n => n.MillesecondsOnStep) / commandInfo.Count();
            CommandInfo = commandInfo;
        }

        public IPanzer Panzer { get; }
        public double AVGMillesecondsOnStep { get; }
        public IEnumerable<(double MillesecondsOnStep, CommanderCommand Command)> CommandInfo { get; }
    }
}
