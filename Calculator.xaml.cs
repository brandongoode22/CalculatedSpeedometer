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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Calculator : Page
    {
        double[] myValues = new double[2];
        string choice;
        double calculatedValue;
        public Calculator()
        {
            InitializeComponent();


        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice(this, "plus");

        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice(this, "minus");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice(this, "multiply");
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            OperatorChoice(this, "divide");
        }

        // Method that takes whatever operation was chosen from the previous button press, performs that calculation
        // on the two values, stores the answer in calculatedValue, and then navigates to the Speedometer page.
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            CalcResult(this);
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
                OperatorChoice(this, "plus");
            }

            else if(e.Key == Key.Subtract)
            {
                OperatorChoice(this, "minus");
            }

            else if(e.Key == Key.Multiply)
            {
                OperatorChoice(this, "multiply");
            }

            else if(e.Key == Key.Divide)
            {
                OperatorChoice(this, "divide");
            }

            else if(e.Key == Key.Enter)
            {
                CalcResult(this);
            }

            

        }


        private void myTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            foreach (char ch in e.Text)
            {
                if (!Char.IsDigit(ch))
                {
                    e.Handled = true;
                }
            }
        }


        private static void OperatorChoice (Calculator calculator, string choice)
        {
            string myValueStr = calculator.myTextBox.Text;
            calculator.myValues[0] = double.Parse(myValueStr);
            calculator.myTextBox.Clear();
            calculator.choice = choice;
            calculator.myTextBox.Focus();
        }

        private static void CalcResult(Calculator calculator)
        {
            string myValueStr;
            myValueStr = calculator.myTextBox.Text;
            try
            {
                calculator.myValues[1] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value");
                return;
            }
            Speedometer pg = new Speedometer();
            double max;

            if (calculator.choice == "plus")
            {
                calculator.calculatedValue = calculator.myValues[0] + calculator.myValues[1];

            }

            else if (calculator.choice == "minus")
            {
                calculator.calculatedValue = calculator.myValues[0] - calculator.myValues[1];

            }

            else if (calculator.choice == "multiply")
            {
                calculator.calculatedValue = calculator.myValues[0] * calculator.myValues[1];
            }

            else if (calculator.choice == "divide")
            {
                calculator.calculatedValue = calculator.myValues[0] / calculator.myValues[1];
            }

            if (calculator.calculatedValue != 0)                                     // calculates the max value for the gauge by using the Log10 function on the calculatedValue,
                                                                          // truncating the decimal of the result with the Floor function, adding 1 to the result,
                                                                          // and then raising 10 to the power of the result                                                              
            {
                max = Math.Pow(10, Math.Floor(Math.Log10(calculator.calculatedValue) + 1));
            }

            else
            {
                max = 1;
            }

            if (calculator.calculatedValue < 0)
            {
                calculator.myTextBox.Clear();
                calculator.NavigationService.Navigate(new ErrorPage());
                return;
            }

            pg.GaugeCharacteristics.EndValue = max;
            pg.GaugeValues.Value = calculator.calculatedValue;
            calculator.NavigationService.Navigate(pg);
        }

    }
}


