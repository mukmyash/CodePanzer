using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePanzer.GameLogic.Map
{
    internal class GameMap : IMap
    {
        public GameMap(int width, int heigth)
        {
            Width = width;
            Heigth = heigth;
            Sections = new MapLayer<ISection>(width, heigth);
            LocationOfForces = new MapLayer<IForce>(width, heigth);
        }

        public int Width { get; }

        public int Heigth { get; }

        ILayer<ISection> IMap.Sections => this.Sections;
        private MapLayer<ISection> _sections;
        public MapLayer<ISection> Sections
        {
            get
            {
                return _sections;
            }
            set
            {
                if (value.Count != Width * Heigth)
                    throw new ArgumentException("Неверно указано кол-во секций", nameof(Sections));
                if (value.Width != Width)
                    throw new ArgumentException("Неверная ширина слоя", nameof(Sections));
                if (value.Heigth != Heigth)
                    throw new ArgumentException("Неверная высота слоя", nameof(Sections));

                _sections = value;
            }
        }


        ILayer<IForce> IMap.LocationOfForces => this.LocationOfForces;
        private MapLayer<IForce> _locationOfForces;
        public MapLayer<IForce> LocationOfForces
        {
            get
            {
                return _locationOfForces;
            }
            set
            {
                if (value.Count != Width * Heigth)
                    throw new ArgumentException("Неверно указано кол-во секций", nameof(LocationOfForces));
                if (value.Width != Width)
                    throw new ArgumentException("Неверная ширина слоя", nameof(LocationOfForces));
                if (value.Heigth != Heigth)
                    throw new ArgumentException("Неверная высота слоя", nameof(LocationOfForces));

                _locationOfForces = value;
            }
        }
    }
}
