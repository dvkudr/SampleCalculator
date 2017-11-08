using System;
using CalculatorV2.Interfaces;

namespace CalculatorV2.BusinessLogic
{
    internal class SignReverter : ISignReverter
    {
        public int SignRevert(int x)
        {
            return -x;
        }
    }
}
