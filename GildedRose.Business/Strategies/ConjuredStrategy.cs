using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Business.Dtos;

namespace GildedRose.Business.Strategies
{
    public class ConjuredStrategy : IStrategy
    {
        public StrategyResult GenerateStrategyResult(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 2;
            }
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality -= 2;
            }

            return new StrategyResult()
            {
                Quality = item.Quality,
                SellIn = item.SellIn
            };
        }
    }
}
