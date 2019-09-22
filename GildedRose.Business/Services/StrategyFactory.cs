using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Business.Strategies;

namespace GildedRose.Business.Services
{
    public class StrategyFactory : IStrategyFactory
    {
        public IStrategy BuildStrategy(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieStrategy();
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasStrategy();
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStagePassStrategy();
                
                default:
                    return new NormalStrategy();
            }
        }
    }
}
