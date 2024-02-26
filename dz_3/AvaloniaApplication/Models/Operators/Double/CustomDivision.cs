using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Double
{
    internal class CustomDivision : DoubleMathOperator
    {
        public float? Calculate(float x, float y)
        {
            if (y == 0) return null;
            else return x / y;
        }

        public override string ToString() => " ÷ ";
    }
}
