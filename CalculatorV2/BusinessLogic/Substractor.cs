using System;
using CalculatorV2.Interfaces;

namespace CalculatorV2.BusinessLogic
{
    internal class Substractor : ISubstractor
    {
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
