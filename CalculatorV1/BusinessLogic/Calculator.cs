using System;
using CalculatorV1.Interfaces;

namespace CalculatorV1.BusinessLogic
{
    public class Calculator : ICalculator
    {
        private readonly int _result;

        public Calculator()
        {
            _result = 0;
        }

        private Calculator(int initValue)
        {
            _result = initValue;
        }

        public ICalculator Add(int value)
        {
            return new Calculator(_result + value);
        }

        public ICalculator Sub(int value)
        {
            return new Calculator(_result - value);
        }

        public ICalculator SignRevert()
        {
            return new Calculator(- _result);
        }

        public int Result => _result;
    }
}
