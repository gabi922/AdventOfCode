using AdventOfCode2017.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Test.Day4
{
    [TestClass]
    public class PassphraseValidatorTest
    {
        PassphraseValidator passphraseValidator;

        [TestInitialize]
        public void Start()
        {
            passphraseValidator = new PassphraseValidator();
        }

        [TestMethod]
        public void Test1()
        {
            var result = passphraseValidator.IsPassphraseValid("aa bb cc dd ee");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test2()
        {
            var result = passphraseValidator.IsPassphraseValid("aa bb cc dd aa");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test3()
        {
            var result = passphraseValidator.IsPassphraseValid("aa bb cc dd aaa");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test4()
        {
            var inputFile = "./Day4/input1.txt";
            var result = passphraseValidator.GetValidPassphraseCount(Utils.ReadLines(inputFile), passphraseValidator.IsPassphraseValid);
            Assert.AreEqual(455, result);
        }

        [TestMethod]
        public void Test5()
        {
            var result = passphraseValidator.IsPassphraseValid2("abcde fghij");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test6()
        {
            var result = passphraseValidator.IsPassphraseValid2("abcde xyz ecdab");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test7()
        {
            var result = passphraseValidator.IsPassphraseValid2("a ab abc abd abf abj");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test8()
        {
            var result = passphraseValidator.IsPassphraseValid2("iiii oiii ooii oooi oooo");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test9()
        {
            var result = passphraseValidator.IsPassphraseValid2("oiii ioii iioi iiio");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test10()
        {
            var inputFile = "./Day4/input1.txt";
            var result = passphraseValidator.GetValidPassphraseCount(Utils.ReadLines(inputFile), passphraseValidator.IsPassphraseValid2);
            Assert.AreEqual(186, result);
        }
    }
}
