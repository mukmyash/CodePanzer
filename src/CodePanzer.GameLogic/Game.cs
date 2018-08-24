using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.PanzerAction;
using CodePanzer.GameLogic.PanzerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic
{
    internal class Game : IGame
    {
        public event EndRoundEventHandler EndRound;

        public IMap CurrentMap { get; private set; }
        private IPanzerFactory _panzerFactory;
        private IGameRound _gemeRound { get; }
        private IEnumerable<IPanzer> _panzers;

        public Game(IPanzerFactory panzerFactory, IGameRound gemeRound)
        {
            _gemeRound = gemeRound;
            _panzerFactory = panzerFactory;
        }

        public void Init(IMap currentMap, IEnumerable<IPanzerCommander> commanders)
        {
            CurrentMap = currentMap;
            var panzers = new List<IPanzer>(commanders.Count());

            foreach (var comander in commanders)
            {
                panzers.Add(_panzerFactory.GetPanzer(CurrentMap, comander));
            }
            _panzers = panzers;
        }

        public void Start()
        {
            while (_panzers.Where(n => n.Health > 0).Count() != 1)
            {
                var intents = _gemeRound.StartRound(CurrentMap, _panzers);
                EndRound?.Invoke(CurrentMap, intents);
            }
        }

    }
}
