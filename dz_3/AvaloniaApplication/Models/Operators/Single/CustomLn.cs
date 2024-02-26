using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Single
{
    internal class CustomLn : SingleMathOperator
    {
        public float? Calculate(float x) => (float)Math.Log(x);

        public override string ToString() => " ln";
    }
}
