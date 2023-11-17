
using System.Runtime.CompilerServices;

namespace Calculator
{
    

    public partial class MainPage : ContentPage
    {

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

        static char[] numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
        static char[] operators = ['x', '/', '(', ')', '+', '-', '%'];

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

            if (isOperator && currentEquation.IndexOfAny(numbers) != -1)
            {
                lastEquation = currentEquation +  " " + input + " ";
                currentEquation = string.Empty;

                equation = lastEquation;

                return;
            }

            currentEquation += input;
            equation += input;

        }

        private void OnPercentage(object sender, EventArgs e)
        {
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

                double result = Calculator.Calculate(equation);

                equation = string.Empty;

                lastEquation = (lastEquation + currentEquation);

                currentEquation = result.ToString();
                

            } catch (Exception ex)
            {
                currentEquation = "?";
            }
        }
    }

}
