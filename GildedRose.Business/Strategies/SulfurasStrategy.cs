using System;
using System.Collections.Generic;
using System.Text;
using GildedRose.Business.Dtos;

namespace GildedRose.Business.Strategies
{
    public class SulfurasStrategy : IStrategy
    {
        public StrategyResult GenerateStrategyResult(Item item)
        {
            return new StrategyResult()
            {
                Quality = item.Quality,
                SellIn = item.SellIn
            };
        }
    }
}
