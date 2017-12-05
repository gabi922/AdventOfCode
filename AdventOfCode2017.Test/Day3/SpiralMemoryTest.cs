using AdventOfCode2017.Day3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Test.Day3
{
    [TestClass]
    public class SpiralMemoryTest
    {
        SpiralMemory spiralMemory;

        [TestInitialize]
        public void Start()
        {
            spiralMemory = new SpiralMemory();
        }

        [TestMethod]
        public void Test1()
        {
            var result = spiralMemory.GetDistance(1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test2()
        {
            var result = spiralMemory.GetDistance(12);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test3()
        {
            var result = spiralMemory.GetDistance(23);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test4()
        {
            var result = spiralMemory.GetDistance(1024);
            Assert.AreEqual(31, result);
        }

        [TestMethod]
        public void Test5()
        {
            var result = spiralMemory.GetDistance(361527);
            Assert.AreEqual(326, result);
        }
    }
}
