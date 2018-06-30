using CodePanzer.GameLogic.Map;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodePanzer.GameLogic.UnitTest.Map
{
    public class EnumExtensionsUnitTest
    {
        public enum TestEnum
        {
            First,
            Second,
            Third,
            Fourth
        }

        [Theory(DisplayName = "(EnumExtensions) Next Value")]
        [InlineData(TestEnum.First, TestEnum.Second)]
        [InlineData(TestEnum.Second, TestEnum.Third)]
        [InlineData(TestEnum.Third, TestEnum.Fourth)]
        [InlineData(TestEnum.Fourth, TestEnum.First)]
        public void EnumExt_Next(TestEnum actual, TestEnum expected)
        {
            var nextEnum = actual.Next();
            nextEnum.Should().Be(expected);
        }

        [Theory(DisplayName = "(EnumExtensions) Prev Value")]
        [InlineData(TestEnum.First, TestEnum.Fourth)]
        [InlineData(TestEnum.Second, TestEnum.First)]
        [InlineData(TestEnum.Third, TestEnum.Second)]
        [InlineData(TestEnum.Fourth, TestEnum.Third)]
        public void EnumExt_Prev(TestEnum actual, TestEnum expected)
        {
            var nextEnum = actual.Prev();
            nextEnum.Should().Be(expected);
        }
    }
}
