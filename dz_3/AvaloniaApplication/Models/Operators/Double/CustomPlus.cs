using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Double
{
    internal class CustomPlus : DoubleMathOperator
    {
        public float? Calculate(float x, float y)
        {
            return x + y;
        }

        public override string ToString() => " + ";
    }
}
