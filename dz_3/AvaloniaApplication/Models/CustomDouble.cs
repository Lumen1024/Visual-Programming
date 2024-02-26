using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Models
{
    public class CustomDouble
    {
        private string predot = "0";
        private string afterdot = "";
        private bool doted = false;
        private bool negative = false;
        public void AddNumber(int number)
        {
            if (!doted)
            {
                if (predot == "0")
                    predot = number.ToString();
                else if (number != 0)
                    predot += number.ToString();
                else if (predot == "" || predot.Length > 0)
                {
                    predot += number.ToString();
                }
            }
            else
            {
                afterdot += number.ToString();
            }
        }

        public void AddDot()
        {
            if (doted)
            {
                afterdot = "";
                return;
            }
            else if (predot == "")
            {
                predot = "0";
            }
            doted = true;
        }

        public void ClearLast()
        {
            if (afterdot != "")
            {
                afterdot = afterdot.Substring(0,afterdot.Length - 1);
            }
            else if (doted == true)
            {
                doted = false;
            }
            else if (predot.Length > 0)
            {
                predot = predot.Substring(0, predot.Length - 1);
            }
            else if (negative)
            {
                negative = false;
            }
        }

        public void Reverse()
        {
            negative = !negative;
        }

        public float Number
        {
            get => float.Parse(ToString());
            set
            {
                string s = value.ToString();
                if (s[0] == '-')
                {
                    negative = true;
                    s = s.Substring(1, s.Length-1);
                }

                var splitted = s.Split(',');
                predot = splitted[0];
                if (splitted.Length > 1)
                {
                    doted = true;
                    afterdot = splitted[1];
                }
                else
                {
                    doted = false;
                    afterdot = "";
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            if (negative) result += "-";
            result += predot;
            if (doted) result += "," + afterdot;
            return result;
        }

    }
}
