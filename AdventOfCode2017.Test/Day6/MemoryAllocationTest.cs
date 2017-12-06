using AdventOfCode2017.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode2017.Test.Day6
{
    [TestClass]
    public class MemoryAllocationTest
    {
        MemoryAllocation memoryAllocation;

        [TestInitialize]
        public void Start()
        {
            memoryAllocation = new MemoryAllocation();
        }

        [TestMethod]
        public void Test1()
        {
            var result = memoryAllocation.Reallocate(new List<int> { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 });
            Assert.AreEqual(4074, result);
        }

        [TestMethod]
        public void Test2()
        {
            var result = memoryAllocation.Reallocate2(new List<int> { 11, 11, 13, 7, 0, 15, 5, 5, 4, 4, 1, 1, 7, 1, 15, 11 });
            Assert.AreEqual(2793, result);
        }
    }
}
