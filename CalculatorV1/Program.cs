using System;
using CalculatorV1.BusinessLogic;

namespace CalculatorV1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(58).Sub(100).SignRevert().Result);
        }
    }
}
