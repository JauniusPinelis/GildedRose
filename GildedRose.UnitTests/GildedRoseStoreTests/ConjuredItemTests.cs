using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Business.Strategies
{
    public class ConjuredItemTests
    {
        private GildedRoseStore _gildedRose;

        

        [Fact]
        public void UpdateQuality_GivenConjuredItem_QualityShouldBeMinusTwo()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(18, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenConjuredItem_SellInShouldBeMinusOne()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(9, _gildedRose.GetItems()[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_GivenConjuredItem_QualityDoesNotGoBelowZero()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 0,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(0, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenConjuredItemRanTwice_SellInIsNegative()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 10,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(-1, _gildedRose.GetItems()[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_GivenConjuredItemRanThreeTimes_QualityDecreaseisQuadripledWhenSellInIsNegative()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Conjured Mana Cake",
                    Quality = 20,
                    SellIn = 1
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();

            Assert.Equal(10, _gildedRose.GetItems()[0].Quality);
        }

        
    }
}
