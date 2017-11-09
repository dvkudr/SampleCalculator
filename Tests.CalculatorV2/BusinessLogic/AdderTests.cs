using System;
using CalculatorV2.BusinessLogic;
using NUnit.Framework;

namespace Test.CalculatorV2.BusinessLogic
{
    [TestFixture]
    public class AdderTests
    {
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 0, ExpectedResult = 1)]
        [TestCase(2, -1, ExpectedResult = 1)]
        [TestCase(Int32.MaxValue, Int32.MinValue, ExpectedResult = -1)]
        public int ShouldAddValues(int x, int y)
        {
            // arrange
            var instance = CreateInstance();

            // act
            var result = instance.Add(x, y);

            // assert
            return result;
        }

        [TestCase(Int32.MaxValue, 1)]
        [TestCase(Int32.MaxValue, Int32.MaxValue)]
        [TestCase(Int32.MinValue, -1)]
        [TestCase(Int32.MinValue, Int32.MinValue)]
        public void ShouldThrowOverFlow(int x, int y)
        {
            // arrange
            var instance = CreateInstance();

            // act
            TestDelegate action = () => instance.Add(x, y);

            // assert
            Assert.Throws<OverflowException>(action);
        }

        private Adder CreateInstance()
        {
            return new Adder();
        }
    }
}