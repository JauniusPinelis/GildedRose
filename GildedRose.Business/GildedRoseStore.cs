using System.Collections.Generic;

namespace GildedRose.Business
{
    public class GildedRoseStore
    {
        IList<Item> Items;
        public GildedRoseStore(IList<Item> Items)
        {
            this.Items = Items;
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
            foreach (Item item in Items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }
    }
}
