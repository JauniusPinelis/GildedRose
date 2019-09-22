using GildedRose.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Strategies
{
    public interface IStrategy
    {
        StrategyResult GenerateStrategyResult(Item item);
    }
}
