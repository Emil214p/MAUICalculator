using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace Calculator
{
    public static class Calculator
    {
        public static double Calculate(string opperation)
        {
            Expression e = new Expression(opperation);

            object result = e.Evaluate();

            if (result.GetType() == typeof(int))
            {
                return (double)(int)result;
            }
            return (double)result;
        }
    }
}
