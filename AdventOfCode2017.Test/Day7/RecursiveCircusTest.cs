using AdventOfCode2017.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2017.Test.Day7
{
    [TestClass]
    public class RecursiveCircusTest
    {
        RecursiveCircus recursiveCircus;

        [TestInitialize]
        public void Start()
        {
            recursiveCircus = new RecursiveCircus();
        }

        [TestMethod]
        public void Test1()
        {
            var lines = File.ReadAllLines("./Day7/input1.txt");
            var tree = recursiveCircus.BuildTree(lines);
            Assert.AreEqual("tknk", tree.Name);
        }

        [TestMethod]
        public void Test2()
        {
            var lines = File.ReadAllLines("./Day7/input2.txt");
            var tree = recursiveCircus.BuildTree(lines);
            Assert.AreEqual("qibuqqg", tree.Name);
        }

        [TestMethod]
        public void Test3()
        {
            var lines = File.ReadAllLines("./Day7/input1.txt");
            var tree = recursiveCircus.BuildTree(lines);
            var result = recursiveCircus.GetUnbalancedNodeNewWeight(tree);
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void Test4()
        {
            var lines = File.ReadAllLines("./Day7/input2.txt");
            var tree = recursiveCircus.BuildTree(lines);
            var result = recursiveCircus.GetUnbalancedNodeNewWeight(tree);
            Assert.AreEqual(1079, result);
        }
    }
}
