using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Single
{
    internal class CustomSin : SingleMathOperator
    {
        public float? Calculate(float x) => (float)Math.Sin(x);

        public override string ToString() => " sin";
    }
}
