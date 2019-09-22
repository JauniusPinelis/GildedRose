using GildedRose.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.UnitTests.GildedRoseStoreTests
{
    public class NormalItemTests
    {
        private GildedRoseStore _gildedRose;

        [Fact]
        public void UpdateQuality_GiveEmptyList_ShouldNotCrash()
        {
            _gildedRose = new GildedRoseStore(new List<Item>());
            _gildedRose.UpdateQuality();
        }

        [Fact]
        public void UpdateQuality_GivenNormalItem_QualityShouldBeMinusOne()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 20,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(19, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenNormalItem_SellInShouldBeMinusOne()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 20,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(9, _gildedRose.GetItems()[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_GivenNormalItem_QualityDoesNotGoBelowZero()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 0,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(0, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenNormalItemRanTwice_SellInIsNegative()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 10,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(-1, _gildedRose.GetItems()[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_GivenNormalItemRanThreeTimes_QualityDecreasedTwiceWhenSellInIsNegative()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 10,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(5, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenNormalWithQualityTooHigh_QualityDecreaseNormally()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 60,
                    SellIn = 20
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(57, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenNormalWithQualityZero_QualityDoesNotGoBelowZero()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Normal",
                    Quality = 0,
                    SellIn = 20
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(0, _gildedRose.GetItems()[0].Quality);
        }
    }
}
