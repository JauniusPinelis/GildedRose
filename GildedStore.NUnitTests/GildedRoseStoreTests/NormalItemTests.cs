using FluentAssertions;
using GildedRose.Business;
using GildedRose.Business.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.NUnitTests.GildedRoseStoreTests
{
    public class NormalItemTests
    {
        private GildedRoseStore _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRoseStore(new StrategyFactory());
        }

        [Test]
        public void UpdateQuality_GivenNormalItem_QualityShouldBeMinusOne()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 20,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(19);
        }

        [Test]
        public void UpdateQuality_GivenNormalItem_SellInShouldBeMinusOne()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 20,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(9);
        }

        [Test]
        public void UpdateQuality_GivenNormalItem_QualityDoesNotGoBelowZero()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 0,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

             items[0].Quality.Should().Be(0);
        }

        [Test]
        public void UpdateQuality_GivenNormalItemRanTwice_SellInIsNegative()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 10,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(-1);
        }

        [Test]
        public void UpdateQuality_GivenNormalItemRanThreeTimes_QualityDecreasedTwiceWhenSellInIsNegative()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 10,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(5);
        }

        [Test]
        public void UpdateQuality_GivenNormalWithQualityTooHigh_QualityDecreaseNormally()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 60,
                    SellIn = 20
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(57);
        }

        [Test]
        public void UpdateQuality_GivenNormalWithQualityZero_QualityDoesNotGoBelowZero()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 0,
                    SellIn = 20
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(0);
        }
    }
}
