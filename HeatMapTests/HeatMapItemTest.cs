using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeatMap;

namespace HeatMapTests
{
    [TestClass]
    public class HeatMapItemTest
    {
        [TestMethod]
        public void HeatMapItemIncrementTest()
        {
            HeatMapItem heatMapItem = new HeatMapItem("A", "B");
            heatMapItem.Increment();
            heatMapItem.Increment();

            Assert.AreEqual(2, heatMapItem.Count);

        }

    }
}
