namespace HeatMap
{
    public class HeatMapItem
    {
        string group1Item;
        string group2Item;
        int count;

        public HeatMapItem(string group1Item, string group2Item)
        {
            this.group1Item = group1Item;
            this.group2Item = group2Item;
            this.count = 0;
        }

        public void Increment()
        {
            this.count++;
        }

        public string Group1Item { get => group1Item; set => group1Item = value; }
        public string Group2Item { get => group2Item; set => group2Item = value; }
        public int Count { get => count; set => count = value; }
    }
}