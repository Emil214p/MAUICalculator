using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculator
    {
        public static double Calculate(double value1, double value2, string? mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }
    }

    public static class DoubleExtensions
    {
        private const string Value = ",";

        public static string ToTrimmedString(this double target, string decimalFormat)
        {
            string strValue = target.ToString(decimalFormat); //Get the stock string

            //If there is a decimal point present
            if (strValue.Contains(','))
            {
                //Remove all trailing zeros
                strValue = strValue.TrimEnd('0');

                //If all we are left with is a decimal point
                if (strValue.EndsWith(Value)) //then remove it
                    strValue = strValue.TrimEnd(',');
            }

            return strValue;
        }
    }
}
