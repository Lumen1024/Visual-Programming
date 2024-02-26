using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models.Operators.Single
{
    internal class CustomFactorial : SingleMathOperator
    {
        public float? Calculate(float x)
        {
            if (x % 1 != 0) return null;
            if (x == 0) return 0;

            float result = 1;
            for (int i = 2; i <= x; i++)
                result *= i;
            return result;
        }

        public override string ToString() => " fact ";
    }
}
