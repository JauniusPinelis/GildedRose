using GildedRose.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.UnitTests.GildedRoseStoreTests
{
    public class AgedBrieItemTests
    {
        private GildedRoseStore _gildedRose;

        [Fact]
        public void UpdateQuality_GivenAgedBrieItem_QualityShouldBePlusOne()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(21, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenAgedBrieItemWithMaxQuality_QualityShouldRemainTheSame()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 50,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(50, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenAgedBrieItemWithLowSellIn_QualityIncreaseDoublesAfterSellInZero()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(23, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenAgedBrieItem_SellInDecreaseNormally()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Aged Brie",
                    Quality = 20,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(-2, _gildedRose.GetItems()[0].SellIn);
        }
    }
}
