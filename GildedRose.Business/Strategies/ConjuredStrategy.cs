using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Strategies
{
    public class ConjuredStrategy : IStrategy
    {
        public void ApplyStrategy(Item item)
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
        }
    }
}
