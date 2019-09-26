using System;
namespace GildedRose.Business.Strategies
{
    public class NormalStrategy : IStrategy
    {
        public void ApplyStrategy(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality -= 1;
            }

            
        }
    }
}
