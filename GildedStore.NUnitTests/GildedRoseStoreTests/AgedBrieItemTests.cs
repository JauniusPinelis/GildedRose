
using GildedRose.Business;
using GildedRose.Business.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace GildedRose.NUnitTests.GildedRoseStoreTests
{
    public class AgedBrieItemTests
    {
        private GildedRoseStore _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRoseStore(new StrategyFactory());
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieItem_QualityShouldBePlusOne()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(21);
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieItemWithMaxQuality_QualityShouldRemainTheSame()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 50,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(50);
          
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieItemWithLowSellIn_QualityIncreaseDoublesAfterSellInZero()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(23);

        
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieItem_SellInDecreaseNormally()
        {

           var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 1
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(-2);
        }
    }
}
