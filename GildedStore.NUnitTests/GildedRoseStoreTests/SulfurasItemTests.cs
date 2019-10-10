using FluentAssertions;
using GildedRose.Business;
using GildedRose.Business.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.NUnitTests.GildedRoseStoreTests
{
    public class SulfurasItemTests
    {
        private GildedRoseStore _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRoseStore(new StrategyFactory());
        }

        [Test]
        public void UpdateQuality_GivenSulfurasItem_QualityShouldNotChange()
        {
            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    Quality = 80,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(80);
        }

        [Test]
        public void UpdateQuality_GivenSulfurasItem_SellInShouldNotChange()
        {
            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    Quality = 80,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(80);
        }
    }
}
