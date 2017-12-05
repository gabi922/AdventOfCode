using AdventOfCode2017.Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Test.Day2
{
    [TestClass]
    public class ChecksumCalculatorTest
    {
        ChecksumCalculator checksumCalculator;

        [TestInitialize]
        public void Start()
        {
            checksumCalculator = new ChecksumCalculator();
        }

        [TestMethod]
        public void Test1()
        {
            var inputFile = "./Day2/input1.txt";
            var result = checksumCalculator.GetChecksum(Utils.ReadMatrix(inputFile));
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void Test2()
        {
            var inputFile = "./Day2/input2.txt";
            var result = checksumCalculator.GetChecksum(Utils.ReadMatrix(inputFile));
            Assert.AreEqual(44887, result);
        }

        [TestMethod]
        public void Test3()
        {
            var inputFile = "./Day2/input3.txt";
            var result = checksumCalculator.GetChecksum2(Utils.ReadMatrix(inputFile));
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Test4()
        {
            var inputFile = "./Day2/input2.txt";
            var result = checksumCalculator.GetChecksum2(Utils.ReadMatrix(inputFile));
            Assert.AreEqual(242, result);
        }
    }
}
