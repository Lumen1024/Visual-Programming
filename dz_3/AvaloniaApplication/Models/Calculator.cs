using AvaloniaApplication.Models.Operators;
using AvaloniaApplication.Models.Operators.Double;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvaloniaApplication.Models
{
    internal class Calculator
    {
        public delegate void ResultPublish(string dispayString);
        public event ResultPublish? OnResultPublish;

        public delegate void ErrorOccured();
        public event ErrorOccured? OnErrorOccured;

        private CustomDouble first = new();
        private CustomDouble? second = null;
        private MathOperator? oper = null;

        private bool firstFocus = true;


        public void AddNumber(int number)
        {
            if (firstFocus)
            {
                first.AddNumber(number);
            }
            else
            {
                second?.AddNumber(number);
            }
            CreateOutput();
        }

        public void AddDot()
        {
            if (firstFocus)
            {
                first.AddDot();
            }
            else
            {
                second?.AddDot();
            }
            CreateOutput();
        }

        public void ReverseNumber()
        {
            if (firstFocus)
            {
                first.Reverse();
            }
            else
            {
                second?.Reverse();
            }
            CreateOutput();
        }

        public void AddOperator(MathOperator newOper)
        {
            if (oper is SingleMathOperator || oper is DoubleMathOperator && second != null)
                Calculate();
            oper = newOper;
            firstFocus = true;

            if (oper is DoubleMathOperator)
            {
                second = new();
                firstFocus = false;
            }
            CreateOutput();
        }

        public void Calculate()
        {
            if (oper == null) return;

            float? result = null;
            if (oper is SingleMathOperator)
            {
                result = (oper as SingleMathOperator)!.Calculate(first.Number);
            }
            else
            {
                if (second == null)
                    result = (oper as DoubleMathOperator)!.Calculate(first.Number, first.Number);
                else
                    result = (oper as DoubleMathOperator)!.Calculate(first.Number, second.Number);
            }
            if (result != null)
                first.Number = result.Value;
            else
            {
                OnErrorOccured?.Invoke();
                return;
            }
            oper = null;
            second = null;
            firstFocus = true;
            CreateOutput();
        }

        public void Clear()
        {
            first = new();
            second = null;
            oper = null;
            CreateOutput();
        }

        public void Undo()
        {
            if (firstFocus)
            {
                if (oper != null)
                    oper = null;
                else
                    first.ClearLast();
            }
            else
            {
                if (second == null)
                    oper = null;
                else
                    second?.ClearLast();
            }
            CreateOutput();
        }
        private void CreateOutput()
        {
            string output = first.ToString() + ((oper != null) ? oper.ToString() : "") + ((second != null) ? second.ToString() : "");
            OnResultPublish?.Invoke(output);
        }

    }
}
