using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Strategies
{
    public class AgedBrieStrategy : IStrategy
    {
        public void ApplyStrategy(Item item)
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
        }
    }
}
