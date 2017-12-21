using AdventOfCode2017.Day21;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AdventOfCode2017.Test.Day21
{
    [TestClass]
    public class FractalArtTest
    {
        FractalArt fractalArt;

        [TestInitialize]
        public void Start()
        {
            fractalArt = new FractalArt();
        }

        [TestMethod]
        public void Test_Flip_Horizontally_Odd()
        {
            var input = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var expected = new int[,] { { 3, 2, 1 }, { 6, 5, 4 }, { 9, 8, 7 } };

            var actual = fractalArt.FlipHorizontally(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_Flip_Horizontally_Even()
        {
            var input = new int[,] { { 1, 2}, { 3, 4 } };
            var expected = new int[,] { { 2, 1 }, { 4, 3 } };

            var actual = fractalArt.FlipHorizontally(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_Flip_Vertically_Odd()
        {
            var input = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var expected = new int[,] { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 } };

            var actual = fractalArt.FlipVertically(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_Flip_Vertically_Even()
        {
            var input = new int[,] { { 1, 2 }, { 3, 4 } };
            var expected = new int[,] { { 3, 4 }, { 1, 2 } };

            var actual = fractalArt.FlipVertically(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_Rotate90_Odd()
        {
            var input = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var expected = new int[,] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };

            var actual = fractalArt.Rotate90(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_Rotate90_Even()
        {
            var input = new int[,] { { 1, 2 }, { 3, 4 } };
            var expected = new int[,] { { 3, 1 }, { 4, 2 } };

            var actual = fractalArt.Rotate90(input);
            Assert.IsTrue(fractalArt.AreEqual(expected, actual));
        }

        [TestMethod]
        public void Test_ApplyMatchingRule_Simple()
        {
            var input = "./Day21/input1.txt";
            var lines = File.ReadAllLines(input);
            var rules = fractalArt.GetRules(lines);

            var pattern = new int[,] { { '#', '#' }, { '.', '.' } };
            var expected = new int[,] { { '#', '.', '.' }, { '#', '#', '#' }, { '#', '.', '.' } };

            var result = fractalArt.ApplyMatchingRule(pattern, rules);
            Assert.IsTrue(fractalArt.AreEqual(expected, result));
        }

        [TestMethod]
        public void Test_ApplyMatchingRule_FlipVertically()
        {
            var input = "./Day21/input1.txt";
            var lines = File.ReadAllLines(input);
            var rules = fractalArt.GetRules(lines);

            var pattern = new int[,] { { '.', '.' }, { '#', '#' } };
            var expected = new int[,] { { '#', '.', '.' }, { '#', '#', '#' }, { '#', '.', '.' } };

            var result = fractalArt.ApplyMatchingRule(pattern, rules);
            Assert.IsTrue(fractalArt.AreEqual(expected, result));
        }

        [TestMethod]
        public void Test_ApplyMatchingRule_Rotate90()
        {
            var input = "./Day21/input1.txt";
            var lines = File.ReadAllLines(input);
            var rules = fractalArt.GetRules(lines);

            var pattern = new int[,] { { '#', '.' }, { '#', '.' } };
            var expected = new int[,] { { '#', '.', '.' }, { '#', '#', '#' }, { '#', '.', '.' } };

            var result = fractalArt.ApplyMatchingRule(pattern, rules);
            Assert.IsTrue(fractalArt.AreEqual(expected, result));
        }

        [TestMethod]
        public void Test_ApplyMatchingRule_FlipHorizontally()
        {
            var input = "./Day21/input1.txt";
            var lines = File.ReadAllLines(input);
            var rules = fractalArt.GetRules(lines);

            var pattern = new int[,] { { '#', '#' }, { '.', '#' } };
            var expected = new int[,] { { '.', '#', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };

            var result = fractalArt.ApplyMatchingRule(pattern, rules);
            Assert.IsTrue(fractalArt.AreEqual(expected, result));
        }

        [TestMethod]
        public void Test_Generate()
        {
            var input = "./Day21/input1.txt";
            var lines = File.ReadAllLines(input);

            var result = fractalArt.Generate(lines);
            Assert.AreEqual(12, result);
        }
    }
}
