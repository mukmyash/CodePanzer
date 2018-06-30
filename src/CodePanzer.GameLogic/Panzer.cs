using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic
{
    public class Panzer : IPanzer
    {
        public IPanzerCommander PanzerComander { get; }

        public ushort Fine { get; set; }

        public ushort Health { get; set; }

        public ushort StepsPerRound { get; set; }

        public ushort Damage { get; set; }

        public IPosition CurrentPosition { get; set; }
        public Direction CurrentDirection { get; set; }

        public CommanderType Type => PanzerComander.Type;

        private Guid _uid;
        public Guid UID
        {
            get
            {
                if (_uid == Guid.Empty)
                    _uid = Guid.NewGuid();
                return _uid;
            }
        }

        public Panzer(IPanzerCommander panzer)
        {
            PanzerComander = panzer;
        }

        public void Init(IMap map, IPosition startPosition, Direction startDirection)
        {
            CurrentPosition = startPosition;
            CurrentDirection = startDirection;

            PanzerComander.Init(map, startPosition, startDirection);
        }

        public (double elapsedMillisecond, CommanderCommand command) GetIntent(IMap map)
        {
            System.Diagnostics.Stopwatch actionTime = new System.Diagnostics.Stopwatch();
            actionTime.Start();
            var action = PanzerComander.GetCommand(map, CurrentPosition, CurrentDirection);
            actionTime.Stop();

            return (actionTime.Elapsed.TotalMilliseconds, action);
        }
    }
}
