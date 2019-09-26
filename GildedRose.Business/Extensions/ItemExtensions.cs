using GildedRose.Business.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Extensions
{
    public static class ItemExtensions
    {
        public static void ApplyStrategy(this Item item, IStrategy strategy)
        {
            strategy.ApplyStrategy(item);
        }
    }
}
