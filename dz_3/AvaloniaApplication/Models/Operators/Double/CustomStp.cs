using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Double
{
    internal class CustomStp : DoubleMathOperator
    {
        public float? Calculate(float x, float y) => (float)Math.Pow(x, y);

        public override string ToString() => "^";
    }
}
