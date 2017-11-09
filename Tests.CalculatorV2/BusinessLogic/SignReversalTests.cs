using System;
using CalculatorV2.BusinessLogic;
using NUnit.Framework;

namespace Test.CalculatorV2.BusinessLogic
{
    [TestFixture]
    public class SignReversalTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(-2, ExpectedResult = 2)]
        [TestCase(Int32.MaxValue, ExpectedResult = Int32.MinValue + 1)]
        public int ShouldSubValues(int x)
        {
            // arrange
            var instance = CreateInstance();

            // act
            var result = instance.SignRevert(x);

            // assert
            return result;
        }

        [TestCase(Int32.MinValue)]
        public void ShouldThrowOverFlow(int x)
        {
            // arrange
            var instance = CreateInstance();

            // act
            TestDelegate action = () => instance.SignRevert(x);

            // assert
            Assert.Throws<OverflowException>(action);
        }

        private SignReverter CreateInstance()
        {
            return new SignReverter();
        }
    }
}