using CodePanzer.Abstractions.Map;
using CodePanzer.GameLogic.Map.Sections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodePanzer.GameLogic.Map.Generator
{
    public class FromFileMapGenerator : IMapGenerator
    {
        private static Random _rnd = new Random();

        public IMap CreateMap(int width, int heigth, int countPanzer)
        {
            var map = new GameMap(width, heigth);
            var sections = new MapLayer<ISection>(10, 10);

            var mapPath = GetMapPath(width, heigth, countPanzer);

            var fileLineNumber = 0;
            foreach (var fileLine in File.ReadAllLines(mapPath))
            {
                fileLineNumber++;
                if (fileLine.Length != width)
                    throw new FormatException($"Длина строки {fileLineNumber} не равна ширине карты {width}");

                var charNumber = 0;
                foreach (var sectionSymbol in fileLine)
                {
                    charNumber++;
                    sections[fileLineNumber - 1, charNumber - 1] = GetSection(sectionSymbol);
                }

            }

            map.Sections = sections;

            return map;
        }

        private ISection GetSection(char sectionSymbol)
        {
            switch (sectionSymbol)
            {
                case '+':
                    return new BrickWallSection();
                case '#':
                    return new IronWallSection();
                case '=':
                    return new RoadSection();
                case '~':
                    return new WaterSection();
                default:
                    return new GrassSection();

            }
        }

        private string GetMapPath(int width, int heigth, int countPanzer)
        {
            var directoryPath = $".\\maps\\{width}x{heigth}";

            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Не удалось найти каталог '{directoryPath}'");

            var mapPaths = Directory.GetFiles(directoryPath);

            mapPaths = mapPaths
                .Where(n => n.Split('\\').Last().StartsWith($"{countPanzer}-"))
                .ToArray();

            if (!mapPaths.Any())
                throw new FileNotFoundException("Осутствует карта размерности {width}x{heigth} и для {countPanzer} танов", $"{directoryPath}\\{countPanzer}-mapName");

            return mapPaths[_rnd.Next(0, mapPaths.Length)];
        }
    }
}
