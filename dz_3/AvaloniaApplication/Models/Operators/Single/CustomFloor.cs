using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Single
{
    internal class CustomFloor : SingleMathOperator
    {
        public float? Calculate(float x) => (float)Math.Floor(x);

        public override string ToString() => " floor ";
    }
}
