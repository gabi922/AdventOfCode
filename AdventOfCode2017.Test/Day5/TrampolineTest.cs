using AdventOfCode2017.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Test.Day5
{
    [TestClass]
    public class TrampolineTest
    {
        Trampoline trampoline; 

        [TestInitialize]
        public void Start()
        {
            trampoline = new Trampoline();
        }

        [TestMethod]
        public void Test1()
        {
            var inputFile = "./Day5/input1.txt";
            var result = trampoline.PerformJumps(Utils.ReadArray(inputFile));
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Test2()
        {
            var inputFile = "./Day5/input2.txt";
            var result = trampoline.PerformJumps(Utils.ReadArray(inputFile));
            Assert.AreEqual(373160, result);
        }

        [TestMethod]
        public void Test3()
        {
            var inputFile = "./Day5/input1.txt";
            var result = trampoline.PerformJumps2(Utils.ReadArray(inputFile));
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Test4()
        {
            var inputFile = "./Day5/input2.txt";
            var result = trampoline.PerformJumps2(Utils.ReadArray(inputFile));
            Assert.AreEqual(26395586, result);
        }
    }
}
