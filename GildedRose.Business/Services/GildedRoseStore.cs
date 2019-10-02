using GildedRose.Business.Extensions;
using GildedRose.Business.Services;
using System.Collections.Generic;

namespace GildedRose.Business
{
    public class GildedRoseStore
    {
        private IStrategyFactory _strategyFactory;

        public GildedRoseStore(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var updateStrategy = _strategyFactory.BuildStrategy(item);

                item.ApplyStrategy(updateStrategy);
            }
        }

    }
}
