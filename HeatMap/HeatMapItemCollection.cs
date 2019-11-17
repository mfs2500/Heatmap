using System.Collections.Generic;

namespace HeatMap
{
    public class HeatMapItemCollection
    {
        const string noItem = "No Item Found";

        List<HeatMapItem> heatMapItems = new List<HeatMapItem>();

        int LoadItemCount(string group1Item, string group2Item)
        {
            return FindItem(group1Item, group2Item).Count;
        }

        public void Add(HeatMapItem heatMapItem)
        {
            heatMapItems.Add(heatMapItem);
        }

        public HeatMapItem FindItem(int i)
        {
            if (i < heatMapItems.Count)

                return heatMapItems[i];

            return NoItem();

        }

        public HeatMapItem FindItem(string group1Item, string group2Item)
        {
            foreach (HeatMapItem item in heatMapItems)
            {
                if (item.Group1Item == group1Item && item.Group2Item == group2Item)
                    return item;
            }
            return NoItem();

        }


        public int Length()
        {
            return heatMapItems.Count;
        }

        public HeatMapItem NoItem()
        {
            return new HeatMapItem(noItem, noItem);
        }
    }
}