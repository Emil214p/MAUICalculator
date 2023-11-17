
using System.Runtime.CompilerServices;

namespace Calculator
{
    

    public partial class MainPage : ContentPage
    {

        string currentEquation = string.Empty;
        string lastEquation = string.Empty;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnClear(object sender, EventArgs? e)
        {
            currentEquation = string.Empty;
            lastEquation = string.Empty;
            resultText.Text = string.Empty;
            
            if (sender.GetType() == typeof(Button) && ((Button)sender).Text == "CE") 
            {
                CurrentCalculation.Text = string.Empty;
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
            switch(input)
            {
                case "/": // division sign
                    isOperator = true;
                    break;
                case "*":
                    isOperator = true;
                    break;
                case "+":
                    isOperator = true;
                    break;
                case "-":
                    isOperator = true;
                    break;
                case "(":
                    isOperator = true;
                    break;
                case ")":
                    isOperator = true;
                    break;
                case "^":
                    isOperator = true;
                    break;
                case "sqrt": // sqrt sign
                    isOperator = true;
                    break;
            }

            if (isOperator)
            {
                currentEquation +=  " " + input + " ";

                CurrentCalculation.Text = currentEquation;
                resultText.Text = string.Empty;
                return;
            }

            currentEquation += input;

            resultText.Text = currentEquation;

        }

        private void OnPercentage(object sender, EventArgs e)
        {
            // calculates it as persentage

            currentEquation = "(" + currentEquation + ")/100";

            OnCalculate(sender, e);

            // append % to the end
            resultText.Text = currentEquation + "%";
            
        }

        private void OnCalculate(object sender, EventArgs? e)
        {
            try
            {
                double result = Calculator.Calculate(currentEquation);

                resultText.Text = result.ToString();

            } catch (Exception ex)
            {
                
            }
        }
    }

}
