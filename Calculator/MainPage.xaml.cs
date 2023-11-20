using System.Runtime.CompilerServices;

namespace Calculator
{
    

    public partial class MainPage : ContentPage
    {
        enum CalcState
        {
            Replace, // replace the current number if number is inputed
            Normal,
            InParantheses // essentially don't use lastEquation
        }

        CalcState state = CalcState.Replace;    

        string currentEquation
        {
            get
            {
                return resultText.Text;
            }

            set
            {
                resultText.Text = value;
            }
        }
        string lastEquation
        {
            get
            {
                return CurrentCalculation.Text;
            }
            set
            {
                CurrentCalculation.Text = value;
            }
        }

        string equation = string.Empty;

        static char[] numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', '(', ')']; // . ( ) are numbers, yes
        static char[] operators = ['x', '/', '+', '-', '%', '^'];

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnClear(object sender, EventArgs? e)
        {
            currentEquation = string.Empty;
            equation = string.Empty;

            if (sender.GetType() == typeof(Button) && ((Button)sender).Text == "CE") 
            {
                lastEquation = string.Empty;
            }
            
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Button))
            {
                return;
            }

            string input = ((Button)sender).Text;

            bool isOperator = false;

            if (input.IndexOfAny(numbers) == -1)
            {
                isOperator = true;

                
            }

            if (input.Contains('('))
            {
                state = CalcState.InParantheses;
            }

            if (input.Contains(')'))
            {
                // determin when first ( is escaped

                int a1 = currentEquation.Split(')').Count();
                int a2 = currentEquation.Split('(').Count();

                if (a1 - 1 == a2)
                {
                    state = CalcState.Normal;
                }
            }

            // below code should be cleaned

            if (isOperator && state != CalcState.InParantheses && (currentEquation.IndexOfAny(numbers) != -1 || state == CalcState.Replace) )
            {

                if (state == CalcState.Normal)
                {
                    lastEquation += currentEquation + " " + input + " ";
                    equation += input;
                    currentEquation = string.Empty;

                    return;
                }

                lastEquation = currentEquation + " " + input + " ";
                currentEquation = string.Empty;
                equation = lastEquation;
                state = CalcState.Normal;

                return;
            }

            if (state == CalcState.Replace)
            {
                lastEquation = string.Empty;
                currentEquation = input;
                equation = input;
                state = CalcState.Normal;
                return;
            }

            


            currentEquation += input;
            equation += input;



        }

        private void OnSqrtClick(object sender, EventArgs e)
        {
            state = CalcState.Normal;
            currentEquation = "Sqrt(" + currentEquation + ")";

            equation += currentEquation;
        }

        private void OnPercentage(object sender, EventArgs e)
        {
            if (state == CalcState.Replace)
            {
                currentEquation = string.Empty;
                equation = string.Empty;
                state = CalcState.Normal;
            }
            // calculates it as persentage

            equation = "(" + equation + ")/100";

            double result = Calculator.Calculate(equation);

            currentEquation = result.ToString();
            
        }

        private void OnCalculate(object sender, EventArgs? e)
        {
            try
            {
                if (lastEquation.IndexOfAny(operators) == -1)
                {
                    lastEquation = string.Empty;
                }

                if (string.IsNullOrEmpty(equation))
                {
                    if (string.IsNullOrEmpty(currentEquation))
                    {
                        equation = currentEquation;
                    } else
                    {
                        equation = lastEquation;
                    }
                    
                }

                double result = Calculator.Calculate(equation);

                lastEquation = equation;

                equation = string.Empty;

                currentEquation = result.ToString();

                state = CalcState.Replace;


            } catch (Exception ex)
            {
                currentEquation = "?";
            }
        }
    }

}
