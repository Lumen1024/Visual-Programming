using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Single
{
    internal class CustomCeil : SingleMathOperator
    {
        public float? Calculate(float x) => (float) Math.Ceiling(x);

        public override string ToString() => " ceil ";
    }
}
