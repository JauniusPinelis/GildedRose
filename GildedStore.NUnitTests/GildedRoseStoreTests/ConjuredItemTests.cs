using FluentAssertions;
using GildedRose.Business;
using GildedRose.Business.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.NUnitTests.GildedRoseStoreTests
{
    public class ConjuredItemTests
    {
        private GildedRoseStore _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRoseStore(new StrategyFactory());
        }

        [Test]
        public void UpdateQuality_GivenConjuredItem_QualityShouldBeMinusTwo()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(18);
        }

        [Test]
        public void UpdateQuality_GivenConjuredItem_SellInShouldBeMinusOne()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(9);
        }

        [Test]
        public void UpdateQuality_GivenConjuredItem_QualityDoesNotGoBelowZero()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 0,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(0);
        }

        [Test]
        public void UpdateQuality_GivenConjuredItemRanTwice_SellInIsNegative()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 10,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(-1);
        }

        [Test]
        public void UpdateQuality_GivenConjuredItemRanThreeTimes_QualityDecreaseisQuadripledWhenSellInIsNegative()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(10);

          
        }

        
    }
}
