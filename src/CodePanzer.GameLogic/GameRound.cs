using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic.Fine;
using CodePanzer.GameLogic.Map;
using CodePanzer.GameLogic.Map.Modifyer;
using CodePanzer.GameLogic.PanzerAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic
{
    internal class GameRound : IGameRound
    {
        private IMapModifyer _mapModifyer;
        public GameRound(IMapModifyer mapModifyer)
        {
            _mapModifyer = mapModifyer;
        }

        public IDictionary<IPanzer, Intent> StartRound(IMap currentMap, IEnumerable<IPanzer> panzers)
        {
            var intents = GetIntents(currentMap, panzers);
            CulcFine(intents);
            _mapModifyer.Modify(currentMap as GameMap, intents);
            return intents;
        }

        private void CulcFine(IDictionary<IPanzer, Intent> intents)
        {
            //TODO: Все это вынести в отдельное место
            foreach (var intent in intents)
            {
                var panzer = intent.Key;
                var fineContext = new FineContext()
                {
                    Panzer = panzer,
                    Intent = intent.Value,
                };


                panzer.Fine = new FineForSlowAlgorithm(null).CalcFine(panzer.Fine, fineContext);
            }
        }

        private IDictionary<IPanzer, Intent> GetIntents(IMap currentMap, IEnumerable<IPanzer> panzers)
        {
            IDictionary<IPanzer, Intent> allIntents
                = new Dictionary<IPanzer, Intent>(panzers.Count());

            foreach (var panzer in panzers)
            {
                if (panzer.Health == 0)
                {
                    allIntents.Add(
                        panzer,
                        new Intent(
                            panzer,
                            new List<(double, CommanderCommand)>()
                            {
                                (0, CommanderCommand.Wait)
                            }
                        )
                    );
                    continue;
                }

                if (panzer.Fine > 0)
                {
                    panzer.Fine--;
                    allIntents.Add(
                        panzer,
                        new Intent(
                            panzer,
                            new List<(double, CommanderCommand)>()
                            {
                                (0, CommanderCommand.Wait)
                            }
                        )
                    );
                    continue;
                }

                List<(double, CommanderCommand)> panzerActionsPerRound = new List<(double, CommanderCommand)>(panzer.StepsPerRound);
                for (int i = 0; i < panzer.StepsPerRound; i++)
                {
                    var panzerAction = panzer.GetIntent(currentMap);
                    panzerActionsPerRound.Add(panzerAction);
                }

                allIntents.Add(panzer, new Intent(panzer, panzerActionsPerRound));
            }

            return allIntents;
        }
    }
}
