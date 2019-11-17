using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeatMap;
using System.Collections.Generic;

namespace HeatMapTests
{
    [TestClass]
    public class HeatMapBuilder_3x3_Test
    {
        string[] Group1 = { "A", "B", "C" };
        string[] Group2 = { "E", "F", "G" };
        HeatMapBuilder heatMapBuilder;

        [TestInitialize]
        public void Init()
        {
            heatMapBuilder = new HeatMapBuilder(Group1, Group2);
        }

        [TestMethod]
        public void EmptyHeatMap_3x3()
        {
      
           
            HeatMapItemCollection emptyheatMap = heatMapBuilder.InitMap();

            Assert.AreEqual(0, emptyheatMap.FindItem(0).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(1).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(2).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(3).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(4).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(5).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(6).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(7).Count);
            Assert.AreEqual(0, emptyheatMap.FindItem(8).Count);

            Assert.AreEqual("No Item Found", emptyheatMap.FindItem(9).Group1Item);

            Assert.AreEqual(9, emptyheatMap.Length());


        }

        [TestMethod]
        public void BuildHeatMap_2_A_B()
        {
            HeatMapItemCollection Relations = new HeatMapItemCollection();
            Relations.Add(new HeatMapItem("A", "F"));
            Relations.Add(new HeatMapItem("A", "F"));

            heatMapBuilder.InitMap();
            HeatMapItemCollection heatMap_3x3=heatMapBuilder.BuildMap(Relations);

            Assert.AreEqual(2, heatMap_3x3.FindItem("A","F").Count);
            
        }


        [TestMethod]
        public void WriteHeatMap_3x3()
        {
            HeatMapItemCollection Relations = new HeatMapItemCollection();
            Relations.Add(new HeatMapItem("A", "F"));
            Relations.Add(new HeatMapItem("A", "F"));
            Relations.Add(new HeatMapItem("A", "F"));
            Relations.Add(new HeatMapItem("A", "G"));
            Relations.Add(new HeatMapItem("A", "G"));
            Relations.Add(new HeatMapItem("B", "E"));
            Relations.Add(new HeatMapItem("A", "G"));
            Relations.Add(new HeatMapItem("C", "E"));
            Relations.Add(new HeatMapItem("C", "F"));
            Relations.Add(new HeatMapItem("C", "G"));
            Relations.Add(new HeatMapItem("C", "E"));
            Relations.Add(new HeatMapItem("C", "F"));
            Relations.Add(new HeatMapItem("C", "G"));


            heatMapBuilder.InitMap();
            heatMapBuilder.BuildMap(Relations);
            List<string> Map=heatMapBuilder.WriteMap();

            Assert.AreEqual("x,A,B,C",Map[0]);
            Assert.AreEqual("E,0,1,2", Map[1]);
            Assert.AreEqual("F,3,0,2", Map[2]);
            Assert.AreEqual("G,3,0,2", Map[3]);

        }

        [TestMethod]
        public void WriteHeatMap_3x3_Dynamic_Initalization()
        {
            HeatMapItemCollection collection = new HeatMapItemCollection();
            collection.Add(new HeatMapItem("A", "F"));
            collection.Add(new HeatMapItem("A", "F"));
            collection.Add(new HeatMapItem("A", "F"));
            collection.Add(new HeatMapItem("A", "G"));
            collection.Add(new HeatMapItem("A", "G"));
            collection.Add(new HeatMapItem("B", "E"));
            collection.Add(new HeatMapItem("A", "G"));
            collection.Add(new HeatMapItem("C", "E"));
            collection.Add(new HeatMapItem("C", "F"));
            collection.Add(new HeatMapItem("C", "G"));
            collection.Add(new HeatMapItem("C", "E"));
            collection.Add(new HeatMapItem("C", "F"));
            collection.Add(new HeatMapItem("B", "G"));


            heatMapBuilder.InitMap(collection);
            heatMapBuilder.BuildMap(collection);
            List<string> Map = heatMapBuilder.WriteMap();

            Assert.AreEqual("x,A,B,C", Map[0]);
            Assert.AreEqual("E,0,1,2", Map[1]);
            Assert.AreEqual("F,3,0,2", Map[2]);
            Assert.AreEqual("G,3,1,1", Map[3]);

        }

    }
}
