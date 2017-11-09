using System;
using CalculatorV2.BusinessLogic;
using CalculatorV2.Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.CalculatorV2.BusinessLogic
{
    [TestFixture]
    public class CalculatorTests
    {
        private Mock<IAdder> _adder;
        private Mock<ISubstractor> _substractor;
        private Mock<ISignReverter> _signReverter;

        [SetUp]
        public void SetUp()
        {
            _adder = new Mock<IAdder>(MockBehavior.Strict);
            _substractor = new Mock<ISubstractor>(MockBehavior.Strict);
            _signReverter = new Mock<ISignReverter>(MockBehavior.Strict);
        }

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

        [Test]
        public void ShouldAddValue()
        {
            // arrange
            const int expectedResult = 42;
            const int value = 142;

            _adder.Setup(x => x.Add(It.IsIn(0), It.IsIn(value))).Returns(expectedResult);
            var instance = CreateInstance();

            // act
            var result = instance.Add(value).Result;

            // assert
            Assert.AreEqual(expectedResult, result);
            _adder.Verify(x => x.Add(It.IsIn(0), It.IsIn(value)), Times.Once);
        }

        [Test]
        public void ShouldSubValue()
        {
            // arrange
            const int expectedResult = 42;
            const int value = 142;

            _substractor.Setup(x => x.Sub(It.IsIn(0), It.IsIn(value))).Returns(expectedResult);
            var instance = CreateInstance();

            // act
            var result = instance.Sub(value).Result;

            // assert
            Assert.AreEqual(expectedResult, result);
            _substractor.Verify(x => x.Sub(It.IsIn(0), It.IsIn(value)), Times.Once);
        }

        [Test]
        public void ShouldSignRevertValue()
        {
            // arrange
            const int expectedResult = 42;

            _signReverter.Setup(x => x.SignRevert(It.IsIn(0))).Returns(expectedResult);
            var instance = CreateInstance();

            // act
            var result = instance.SignRevert().Result;

            // assert
            Assert.AreEqual(expectedResult, result);
            _signReverter.Verify(x => x.SignRevert(It.IsIn(0)), Times.Once);
        }

        [Test]
        public void ShouldCalculateIndependently()
        {
            // arrange
            const int expectedResult1 = 142;
            const int expectedResult2 = 242;
            const int expectedResult3 = 342;
            const int value1 = 1;
            const int value2 = 2;
            const int value3 = 3;

            _adder.Setup(x => x.Add(It.IsIn(0), It.IsIn(value1))).Returns(expectedResult1);
            _adder.Setup(x => x.Add(It.IsIn(0), It.IsIn(value2))).Returns(expectedResult2);
            _adder.Setup(x => x.Add(It.IsIn(expectedResult1), It.IsIn(value3))).Returns(expectedResult3);

            var instance = CreateInstance();

            // act
            var instance2 = instance.Add(value1);
            var result1 = instance.Add(value2).Result;
            var result2 = instance2.Add(value3).Result;

            // assert
            Assert.AreEqual(expectedResult2, result1);
            Assert.AreEqual(expectedResult3, result2);

            _adder.Verify(x => x.Add(It.IsIn(0), It.IsIn(value1)), Times.Once);
            _adder.Verify(x => x.Add(It.IsIn(0), It.IsIn(value2)), Times.Once);
            _adder.Verify(x => x.Add(It.IsIn(expectedResult1), It.IsIn(value3)), Times.Once);
        }

        [Test]
        public void ShouldAddTrowException()
        {
            // arrange
            const int value = 142;
            var exception = new Exception();

            _adder.Setup(x => x.Add(It.IsIn(0), It.IsIn(value))).Throws(exception);
            var instance = CreateInstance();

            // act
            TestDelegate action = () => instance.Add(value);

            // assert
            var actualException = Assert.Throws<Exception>(action);
            Assert.AreSame(exception, actualException);
            _adder.Verify(x => x.Add(It.IsIn(0), It.IsIn(value)), Times.Once);
        }

        [Test]
        public void ShouldSubTrowException()
        {
            // arrange
            const int value = 142;
            var exception = new Exception();

            _substractor.Setup(x => x.Sub(It.IsIn(0), It.IsIn(value))).Throws(exception);
            var instance = CreateInstance();

            // act
            TestDelegate action = () => instance.Sub(value);

            // assert
            var actualException = Assert.Throws<Exception>(action);
            Assert.AreSame(exception, actualException);
            _substractor.Verify(x => x.Sub(It.IsIn(0), It.IsIn(value)), Times.Once);
        }

        [Test]
        public void ShouldSignRevertTrowException()
        {
            // arrange
            var exception = new Exception();

            _signReverter.Setup(x => x.SignRevert(It.IsIn(0))).Throws(exception);
            var instance = CreateInstance();

            // act
            TestDelegate action = () => instance.SignRevert();

            // assert
            var actualException = Assert.Throws<Exception>(action);
            Assert.AreSame(exception, actualException);
            _signReverter.Verify(x => x.SignRevert(It.IsIn(0)), Times.Once);
        }

        private Calculator CreateInstance()
        {
            return new Calculator(_adder.Object, _substractor.Object, _signReverter.Object);
        }
    }
}
