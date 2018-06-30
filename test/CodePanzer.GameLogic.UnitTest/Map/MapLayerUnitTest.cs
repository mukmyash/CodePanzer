using CodePanzer.GameLogic.Map;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodePanzer.GameLogic.UnitTest.Map
{
    public class MapLayerUnitTest
    {
        [Fact(DisplayName = "(MapLayer) Успешное создание инстанса")]
        public void MapLayer_CreateInstans()
        {
            var instance = new MapLayer<int>(2, 3);
        }

        [Theory(DisplayName = "(MapLayer) Корректная ширина")]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void MapLayer_CorrectWidth(int width)
        {
            var instance = new MapLayer<int>(width, 3);
            instance.Width.Should().Be(width);
        }

        [Theory(DisplayName = "(MapLayer) Корректная высота")]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void MapLayer_CorrectHeigth(int heigth)
        {
            var instance = new MapLayer<int>(2, heigth);
            instance.Heigth.Should().Be(heigth);
        }

        [Fact(DisplayName = "(MapLayer) установка значений")]
        public void MapLayer_SetValue()
        {
            var instance = new MapLayer<int>(10, 10);

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    instance[i, j] = i * 10 + j;
                }

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    instance[i, j].Should().Be(i * 10 + j);
                }
        }

        [Fact(DisplayName = "(MapLayer) тип перечисления")]
        public void MapLayer_EnumeratorType()
        {
            var instance = new MapLayer<int>(10, 10);

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    instance[i, j] = i * 10 + j;
                }

            int counter = 0;
            foreach (var i in instance)
            {
                i.Should().Be(counter);
                counter++;
            }

        }
    }
}
