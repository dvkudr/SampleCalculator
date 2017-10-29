using System;

namespace CalculatorV1.Interfaces
{
    public interface ICalculator
    {
        ICalculator Add(int value);
        ICalculator Sub(int value);
        ICalculator SignRevert();
        ICalculator Set(int value);
        ICalculator Reset();
        int Result { get; }
    }
}
