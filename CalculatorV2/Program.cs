using System;
using CalculatorV2.BusinessLogic;

namespace CalculatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new Adder(), new Substractor(), new SignReverter());
            Console.WriteLine(calculator.Add(42).Sub(100).SignRevert().Result);
        }
    }
}
