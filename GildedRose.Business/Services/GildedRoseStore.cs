using GildedRose.Business.Extensions;
using GildedRose.Business.Services;
using System.Collections.Generic;

namespace GildedRose.Business
{
    public class GildedRoseStore
    {
        IList<Item> Items;

        private IStrategyFactory _strategyFactory;

        public GildedRoseStore(IList<Item> Items)
        {
            this.Items = Items;
            _strategyFactory = new StrategyFactory();
        }

        /// <summary>
        /// Since requirements do not allow editting Items List and making it public property I have to use 
        /// a function which returns items
        /// </summary>
        public IList<Item> GetItems()
        {
            return Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updateStrategy = _strategyFactory.BuildStrategy(item);
                item.ApplyStrategy(updateStrategy);
            }
        }

    }
}
