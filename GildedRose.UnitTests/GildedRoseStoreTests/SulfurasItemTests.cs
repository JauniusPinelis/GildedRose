using GildedRose.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.UnitTests.GildedRoseStoreTests
{
    public class SulfurasItemTests
    {
        private GildedRoseStore _gildedRose;

        [Fact]
        public void UpdateQuality_GivenSulfurasItem_QualityShouldNotChange()
        {
            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    Quality = 80,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(80, _gildedRose.GetItems()[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GivenSulfurasItem_SellInShouldNotChange()
        {
            _gildedRose = new GildedRoseStore(new List<Item>()
            {
               new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    Quality = 80,
                    SellIn = 10
                }
            });

            _gildedRose.UpdateQuality();

            Assert.Equal(10, _gildedRose.GetItems()[0].SellIn);
        }
    }
}
