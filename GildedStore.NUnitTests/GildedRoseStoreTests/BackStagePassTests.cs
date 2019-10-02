using GildedRose.Business;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using GildedRose.Business.Services;
using FluentAssertions;

namespace GildedRose.NUnitTests.GildedRoseStoreTests
{
    public class BackStagePassTests
    {
        private GildedRoseStore _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRoseStore(new StrategyFactory());
        }

        [Test]
        public void UpdateQuality_GivenBackStagePassWithHighSellIn_QualityShouldBePlusOne()
        {

           var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 30
                }
            };

            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(21);
        }

        [Test]
        public void UpdateQuality_GivenBackStagePass_SellInDecreasesNormally()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 30
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].SellIn.Should().Be(28);
           
        }

        [Test]
        public void UpdateQuality_GivenBackStagePassWithSellInLessThanTen_QualityIncreaseDoubles()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 11
                }
            };

            _gildedRose.UpdateQuality(items); //21
            _gildedRose.UpdateQuality(items); //23
            _gildedRose.UpdateQuality(items); //25

            items[0].Quality.Should().Be(25);

          
        }

        [Test]
        public void UpdateQuality_GivenBackStagePassWithSellInLessThanFive_QualityIncreaseTriples()
        {

          var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 6
                }
            };

            _gildedRose.UpdateQuality(items); //22
            _gildedRose.UpdateQuality(items); //25
            _gildedRose.UpdateQuality(items); //28

            items[0].Quality.Should().Be(28);
           
        }

        [Test]
        public void UpdateQuality_GivenBackStagePassWithNegativeSellIn_QualityDropsToZero()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = 2
                }
            };

            _gildedRose.UpdateQuality(items); 
            _gildedRose.UpdateQuality(items); 
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(0);
          
        }

        [Test]
        public void UpdateQuality_GivenBackStagePassWithMaxQuality_QualityStaysMax()
        {

            var items = new List<Item>()
            {
               new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 50,
                    SellIn = 10
                }
            };

            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);
            _gildedRose.UpdateQuality(items);

            items[0].Quality.Should().Be(50);
            
        }
    }
}
