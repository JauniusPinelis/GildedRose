using GildedRose.Business.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Services
{
    public interface IStrategyFactory
    {
        IStrategy BuildStrategy(Item item);
    }
}
