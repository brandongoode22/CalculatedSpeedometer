using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatedSpeedometer
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Page
    {
        double[] myValues = {0, 0};
        string choice;
        double calculatedValue;
        bool opSelected = false;
        public Calculator()
        {
            InitializeComponent();


        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice("plus");

        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice("minus");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice("multiply");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice("divide");
        }


        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            CalcResult();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Clear();
            myValues[0] = 0;
            myValues[1] = 0;

            myTextBox.Focus();

        }

        private void myTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Add)
            {
                OperatorChoice("plus");
            }

            else if(e.Key == Key.Subtract)
            {
                OperatorChoice("minus");
            }

            else if(e.Key == Key.Multiply)
            {
                OperatorChoice("multiply");
            }

            else if(e.Key == Key.Divide)
            {
                OperatorChoice("divide");
            }

            else if(e.Key == Key.Enter)
            {
                CalcResult();
            }
        }

        private void myTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            foreach (char ch in e.Text)
            {
                if (Char.IsDigit(ch) || ch == '.')
                {
                    e.Handled = false;
                }

                else
                {
                    e.Handled = true;
                }
            }
        }

        // Method that takes a Calculator object and a string representing the operator chosen as parameters.
        // Takes whatever value is in the TextBox currently, converts it
        // to a double, and stores it in the first element of the myValues array. 
        // Sets the value of choice to whatever button was pressed. 
        private void OperatorChoice (string myChoice)
        {
            if (!opSelected)
            {
                string myValueStr = myTextBox.Text;
                try
                {
                    myValues[0] = double.Parse(myValueStr);
                }

                catch (Exception)
                {
                    MessageBox.Show("Invalid Operation");
                    return;
                }
                myTextBox.Clear();
                choice = myChoice;
                myTextBox.Focus();
                opSelected = true;

            }

            else
            {
                opSelected = false;
                CalcResult(); 
            }
        }

        // Method that takes whatever operation was chosen from the previous button press, performs that calculation
        // on the two values, stores the answer in calculatedValue, and then navigates to the Speedometer page.
        private void CalcResult()
        {
            string myValueStr = myTextBox.Text;
            Speedometer speedometer = new Speedometer();
            double max;
            calculatedValue = 0;

            try
            {
                myValues[1] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value first");
                return;
            }


            if (choice == "plus")
            {
                calculatedValue = myValues[0] + myValues[1];

            }

            else if (choice == "minus")
            {
                calculatedValue = myValues[0] - myValues[1];

            }

            else if (choice == "multiply")
            {
                calculatedValue = myValues[0] * myValues[1];
            }

            else if (choice == "divide")
            { 
                if(myValues[1] == 0)
                {
                    NavigationService.Navigate(new ErrorPage(calculatedValue, myValues[1]));
                    return;
                }

                if (myValues[0] / myValues[1] < 0.00001)
                {
                    calculatedValue = 0;
                }

                else
                {
                    calculatedValue = myValues[0] / myValues[1];
                }
            }

            else
            {
                calculatedValue = myValues[1];
            }

            if (calculatedValue != 0)                                     // calculates the max value for the gauge by using the Log10 function on the calculatedValue,
                                                                          // truncating the decimal of the result with the Floor function, adding 1 to the result,
                                                                          // and then raising 10 to the power of the result                                                              
            {
                max = Math.Pow(10, Math.Floor(Math.Log10(calculatedValue) + 1));
            }

            else
            {
                max = 1;
            }

            if (calculatedValue < 0)
            {
                myTextBox.Clear();
                NavigationService.Navigate(new ErrorPage(calculatedValue));
                return;
            }

            else if (calculatedValue >= 10000000)
            {
                myTextBox.Clear();
                NavigationService.Navigate(new ErrorPage(calculatedValue));
                return;
            }

            calculatedValue = Math.Round(calculatedValue, 5);

            speedometer.GaugeCharacteristics.EndValue = max;
            speedometer.GaugeValues.Value = calculatedValue;
            speedometer.DisplayValue.Text = calculatedValue.ToString();
            NavigationService.Navigate(speedometer);
        }
    }
}


