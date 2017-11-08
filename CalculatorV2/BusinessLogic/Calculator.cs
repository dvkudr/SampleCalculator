using System;
using CalculatorV2.Interfaces;

namespace CalculatorV2.BusinessLogic
{
    public class Calculator : ICalculator
    {
        private readonly int _result;
        private readonly IAdder _adder;
        private readonly ISubstractor _substractor;
        private readonly ISignReverter _signReverter;

        public Calculator(IAdder adder, ISubstractor substractor, ISignReverter signReverter)
        {
            _result = 0;
            _adder = adder;
            _substractor = substractor;
            _signReverter = signReverter;
        }

        private Calculator(int initValue, IAdder adder, ISubstractor substractor, ISignReverter signReverter)
        {
            _result = initValue;
            _adder = adder;
            _substractor = substractor;
            _signReverter = signReverter;
        }

        public ICalculator Add(int value)
        {
            return new Calculator(_adder.Add(_result,value), _adder, _substractor, _signReverter);
        }

        public ICalculator Sub(int value)
        {
            return new Calculator(_substractor.Sub(_result, value), _adder, _substractor, _signReverter);
        }

        public ICalculator SignRevert()
        {
            return new Calculator(_signReverter.SignRevert(_result), _adder, _substractor, _signReverter);
        }

        public int Result => _result;
    }
}
