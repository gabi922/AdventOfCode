using AdventOfCode2017.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Test.Day6
{
    [TestClass]
    public class Day6SolverTest
    {
        Day6Solver day6Solver;

        [TestInitialize]
        public void Start()
        {
            day6Solver = new Day6Solver();
        }

        [TestMethod]
        public void Test1()
        {
            var inputFile = "./Day6/input1.txt";
            var result = day6Solver.Solve(Utils.ReadArray(inputFile));
            Assert.AreEqual(0, result);
        }
    }
}
