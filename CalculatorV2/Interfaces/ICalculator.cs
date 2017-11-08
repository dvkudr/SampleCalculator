using System;

namespace CalculatorV2.Interfaces
{
    public interface ICalculator
    {
        ICalculator Add(int value);
        ICalculator Sub(int value);
        ICalculator SignRevert();
        int Result { get; }
    }
}
