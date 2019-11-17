using System.Collections.Generic;

namespace HeatMap
{
    public class HeatMapBuilder
    {
        string[] group1;
        string[] group2;
        HeatMapItemCollection collection = new HeatMapItemCollection();
        List<string> heatMap = new List<string>();
        public HeatMapBuilder()
        {

        }

        public HeatMapBuilder(string[] group1, string[] group2)
        {
            this.group1 = group1;
            this.group2 = group2;

        }

        public HeatMapItemCollection InitMap()
        {
            foreach (string group1Item in group1)
                foreach (string group2item in group2)
                {
                    collection.Add(new HeatMapItem(group1Item, group2item));
                }
            return collection;
        }

        public HeatMapItemCollection InitMap(HeatMapItemCollection relations)
        {
            List<string> group1List = new List<string>();
            List<string> group2List = new List<string>();

            for (int i = 0; i < relations.Length(); i++)
            {
                if (!group1List.Contains(relations.FindItem(i).Group1Item))
                    group1List.Add(relations.FindItem(i).Group1Item);

                if (!group2List.Contains(relations.FindItem(i).Group2Item))
                    group2List.Add(relations.FindItem(i).Group2Item);

            }

            group1 = new string[group1List.Count];
            group2 = new string[group2List.Count];

            group1List.Sort();
            group2List.Sort();

            group1List.CopyTo(group1);
            group2List.CopyTo(group2);

            this.InitMap();

            return collection;
        }

        public HeatMapItemCollection BuildMap(HeatMapItemCollection relations)
        {
            for (int i = 0; i < relations.Length(); i++)
                collection.FindItem(relations.FindItem(i).Group1Item, relations.FindItem(i).Group2Item).Increment();

            return collection;
        }

        public List<string> WriteMap()
        {
            writeHeader();
            writeRows();

            return heatMap;
        }

        private void writeHeader()
        {
            string heatMapHeader = "x";

            foreach (string group1Item in group1)
            {
                heatMapHeader += "," + group1Item;
            }

            heatMap.Add(heatMapHeader);

        }
        private void writeRows()
        {
            List<string> heatMapRow = new List<string>();

            foreach (string group2Item in group2)
            {
                string row = "";
                foreach (string group1Item in group1)
                {
                    if (row == "") row += group2Item;
                    row += "," + collection.FindItem(group1Item, group2Item).Count.ToString();
                }
                heatMapRow.Add(row);
            }

            heatMap.AddRange(heatMapRow);

        }
    }
}