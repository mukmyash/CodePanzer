using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using CodePanzer.GameLogic;
using CodePanzer.GameLogic.Infrastructure;
using CodePanzer.GameLogic.Map;
using CodePanzer.GameLogic.Map.Generator;
using Microsoft.Extensions.DependencyInjection;
using Panzer.II;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodePanzer.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddGameLogic();
            var game = services.BuildServiceProvider().GetRequiredService<IGame>();
            var map = new MapFactory(new FromFileMapGenerator()).GetMap(10, 10, 5);

            var commander = new List<IPanzerCommander>()
            {
                new Panzer.II.Panzer(),
                new Panzer.II.Panzer(),
                new Panzer.II.Panzer(),
                new Panzer.II.Panzer(),
                new Panzer.II.Panzer()
            };

            game.Init(map, commander);
            game.EndRound += Game_EndRound;
            foreach (var line in GetMapDraw(map))
            {
                Console.WriteLine(line);
            }
            Console.SetCursorPosition(0, Console.CursorTop - 10);
            game.Start();
            Console.ReadLine();
        }

        private static void Game_EndRound(IMap map, IDictionary<IPanzer, GameLogic.PanzerAction.Intent> intents)
        {
            foreach (var line in GetMapDraw(map))
            {
                Console.WriteLine(line);
            }

            foreach (var intent in intents)
            {
                Console.WriteLine($"Panzer \t{intent.Key.UID}\t Health: \t{intent.Key.Health}\t Position: \t{intent.Key.CurrentPosition}");
                foreach (var cpmmand in intent.Value.CommandInfo)
                {
                    Console.WriteLine($"{cpmmand.Command}");
                }
            }
            Console.SetCursorPosition(0, Console.CursorTop - (10 + intents.Count * 2));
            Thread.Sleep(100);
        }

        static IEnumerable<string> GetMapDraw(IMap map)
        {
            var panzers = map.LocationOfForces;
            var sections = map.Sections;

            for (int y = 0; y < map.Heigth; y++)
            {
                StringBuilder lineString = new StringBuilder();
                for (int x = 0; x < map.Heigth; x++)
                {
                    var panzer = panzers[y, x];
                    if (panzer != null)
                    {
                        lineString.Append(GetSymbolPanzer(panzer.CurrentDirection));
                    }
                    else
                    {
                        var section = sections[y, x];
                        lineString.Append(GetSymbolSection(section.Type, section.IsDestroy));
                    }
                }
                yield return lineString.ToString();
            }
        }
        static char GetSymbolPanzer(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return 'E';// '►';
                case Direction.North:
                    return 'N';// '▲';
                case Direction.South:
                    return 'S';// '▼';
                case Direction.West:
                    return 'W';// '◄';
                default:
                    throw new NotSupportedException("Данный тип секции не поддерживается");
            }
        }

        static char GetSymbolSection(SectionType sectionType, bool isDestroy)
        {
            switch (sectionType)
            {
                case SectionType.BrickWall when !isDestroy:
                    return '+';
                case SectionType.BrickWall when isDestroy:
                    return '-';
                case SectionType.IronWall:
                    return '#';
                case SectionType.Road:
                    return '=';
                case SectionType.Water:
                    return '~';
                case SectionType.Grass:
                    return '`';
                default:
                    throw new NotSupportedException("Данный тип секции не поддерживается");
            }
        }
    }
}
