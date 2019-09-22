using GildedRose.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.UnitTests.GildedRoseStoreTests
{
    public class BackStagePassTests
    {
        private GildedRoseStore _gildedRose;

        [Fact]
        public void UpdateQuality_GivenBackStagePassWithHighSellIn_QualityShouldBePlusOne()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 30
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(21, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenBackStagePass_SellInDecreasesNormally()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 30
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();


            Assert.Equal(28, _gildedRose.GetItems()[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_GivenBackStagePassWithSellInLessThanTen_QualityIncreaseDoubles()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 11
                }
            });

            _gildedRose.UpdateQuality(); //21
            _gildedRose.UpdateQuality(); //23
            _gildedRose.UpdateQuality(); //25


            Assert.Equal(25, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenBackStagePassWithSellInLessThanFive_QualityIncreaseTriples()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 6
                }
            });

            _gildedRose.UpdateQuality(); //22
            _gildedRose.UpdateQuality(); //25
            _gildedRose.UpdateQuality(); //28


            Assert.Equal(28, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenBackStagePassWithNegativeSellIn_QualityDropsToZero()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 2
                }
            });

            _gildedRose.UpdateQuality(); 
            _gildedRose.UpdateQuality(); 
            _gildedRose.UpdateQuality(); 


            Assert.Equal(0, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenBackStagePassWithMaxQuality_QualityStaysMax()
        {

            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 50,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();
            _gildedRose.UpdateQuality();


            Assert.Equal(50, _gildedRose.GetItems()[0].Quality);
        }
    }
}
