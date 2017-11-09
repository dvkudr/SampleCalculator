using System;
using CalculatorV2.Interfaces;

namespace CalculatorV2.BusinessLogic
{
    internal class Adder : IAdder
    {
        public int Add(int x, int y)
        {
            return checked (x + y);
        }
    }
}
