using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.PanzerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic
{
    internal class Game
    {
        public IMap CurrentMap { get; private set; }
        private IPanzerFactory _panzerFactory;
        private IGameRound _gemeRound { get; }
        private IEnumerable<IPanzer> _panzers;

        public Game(IMap currentMap, IPanzerFactory panzerFactory, IGameRound gemeRound)
        {
            _gemeRound = gemeRound;
            CurrentMap = currentMap;
            _panzerFactory = panzerFactory;
        }

        public void Init(IEnumerable<IPanzerCommander> commanders)
        {
            var panzers = new List<IPanzer>(commanders.Count());

            foreach (var comander in commanders)
            {
                panzers.Add(_panzerFactory.GetPanzer(CurrentMap, comander));
            }
            _panzers = panzers;
        }

        public void Start()
        {
            while (_panzers.Any(n => n.Health > 0))
            {
                _gemeRound.StartRound(CurrentMap, _panzers.Where(n => n.Health > 0));
            }
        }

    }
}
