using AdventOfCode2017.Day8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2017.Test.Day8
{
    [TestClass]
    public class RegistersTest
    {
        Registers registers;

        [TestInitialize]
        public void Start()
        {
            registers = new Registers();
        }
        
        [TestMethod]
        public void Test1()
        {
            var instructions = File.ReadAllLines("./Day8/input1.txt");
            int allTimeMax;
            var result = registers.GetMaximumRegisterValue(instructions, out allTimeMax);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test2()
        {
            var instructions = File.ReadAllLines("./Day8/input2.txt");
            int allTimeMax;
            var result = registers.GetMaximumRegisterValue(instructions, out allTimeMax);
            Assert.AreEqual(2971, result);
        }

        [TestMethod]
        public void Test3()
        {
            var instructions = File.ReadAllLines("./Day8/input1.txt");
            int allTimeMax;
            registers.GetMaximumRegisterValue(instructions, out allTimeMax);
            Assert.AreEqual(10, allTimeMax);
        }

        [TestMethod]
        public void Test4()
        {
            var instructions = File.ReadAllLines("./Day8/input2.txt");
            int allTimeMax;
            registers.GetMaximumRegisterValue(instructions, out allTimeMax);
            Assert.AreEqual(4254, allTimeMax);
        }
    }
}
