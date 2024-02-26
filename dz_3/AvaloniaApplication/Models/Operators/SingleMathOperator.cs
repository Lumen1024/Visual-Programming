using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators
{
    internal interface SingleMathOperator : MathOperator
    {
        public float? Calculate(float x);
    }
}
