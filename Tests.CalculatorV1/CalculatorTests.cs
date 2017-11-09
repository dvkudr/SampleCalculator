using System;
using NUnit.Framework;
using CalculatorV1.BusinessLogic;

namespace Tests.CalculatorV1
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ShouldNewResultZero()
        {
            // arrange
            var instance = CreateInstance();

            // act
            var result = instance.Result;

            // assert
            Assert.AreEqual(0, result);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(1000)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void ShouldAddValue(int value)
        {
            // arrange
            var instance = CreateInstance();

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
            var instance = CreateInstance();

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
            var instance = CreateInstance();

            // act
            var result = instance.Add(value).SignRevert().Result;

            // assert
            Assert.AreEqual(-value, result);
        }

        [Test]
        public void ShouldCalculateIndependently()
        {
            // arrange
            var instance1 = CreateInstance();
            var instance2 = instance1.Add(42);

            // act
            var result1 = instance1.Add(100).Result;
            var result2 = instance2.Add(100).Result;

            // assert
            Assert.AreEqual(100, result1);
            Assert.AreEqual(142, result2);
        }

        private Calculator CreateInstance()
        {
            return new Calculator();
        }
    }
}
