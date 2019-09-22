using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Business.Dtos;

namespace GildedRose.Business.Strategies
{
    public class AgedBrieStrategy : IStrategy
    {
        public StrategyResult GenerateStrategyResult(Item item)
        {

            if (item.Quality < 50)
            {
                item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality += 1;
            }

            return new StrategyResult()
            {
                Quality = item.Quality,
                SellIn = item.SellIn
            };
        }
    }
}
