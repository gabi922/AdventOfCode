using AdventOfCode2017.Day18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2017.Test.Day18
{
    [TestClass]
    public class ParallelProcessingTest
    {
        ParallelProcessing parallelProcessing;

        [TestInitialize]
        public void Start()
        {
            parallelProcessing = new ParallelProcessing();
        }

        [TestMethod]
        public void Test1()
        {
            var lines = File.ReadAllLines("./Day18/input1.txt");
            var result = parallelProcessing.Process(lines);
            Assert.AreEqual(4601, result);
        }

        [TestMethod]
        public void Test2()
        {
            var lines = File.ReadAllLines("./Day18/input1.txt");
            var result = parallelProcessing.Process2(lines);
            Assert.AreEqual(6858, result);
        }
    }
}
