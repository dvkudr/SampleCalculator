using System;
using NUnit.Framework;
using CalculatorV2.BusinessLogic;

namespace Test.CalculatorV2
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void ShouldAddValue(int value)
        {
            // arrange
            var instance = CrerateInstance();

            // act
            var result = instance.Add(value).Result;

            // assert
            Assert.AreEqual(value, result);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void ShouldSubValue(int value)
        {
            // arrange
            var instance = CrerateInstance();

            // act
            var result = instance.Sub(value).Result;

            // assert
            Assert.AreEqual(-value, result);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void ShouldSignRevertValue(int value)
        {
            // arrange
            var instance = CrerateInstance();

            // act
            var result = instance.Add(value).SignRevert().Result;

            // assert
            Assert.AreEqual(-value, result);
        }

        [Test]
        public void Should_CalculateIndependently()
        {
            // arrange
            var instance1 = CrerateInstance();
            var instance2 = instance1.Add(42);

            // act
            var result1 = instance1.Add(100).Result;
            var result2 = instance2.Add(100).Result;

            // assert
            Assert.AreEqual(100, result1);
            Assert.AreEqual(142, result2);
        }

        private Calculator CrerateInstance()
        {
            return new Calculator(new Adder(), new Substractor(), new SignReverter());
        }
    }
}
