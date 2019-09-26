using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Business.Strategies
{
    public interface IStrategy
    {
        void ApplyStrategy(Item item);
    }
}
