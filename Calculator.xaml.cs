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
            string myValueStr;
            myValueStr = myTextBox.Text;
            try
            {
                myValues[0] = double.Parse(myValueStr);
            }

            catch(Exception)
            {
                MessageBox.Show("Must enter a numeric value");
            }
            myTextBox.Clear();
            choice = "plus";
            myTextBox.Focus();


        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            try
            {
                myValues[0] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value");
            }
            myTextBox.Clear();
            choice = "minus";
            myTextBox.Focus();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            try
            {
                myValues[0] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value");
            }
            myTextBox.Clear();
            choice = "multiply";
            myTextBox.Focus();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            try
            {
                myValues[0] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value");
            }
            myTextBox.Clear();
            choice = "divide";
            myTextBox.Focus();
        }

        // Method that takes whatever operation was chosen from the previous button press, performs that calculation
        // on the two values, stores the answer in calculatedValue, and then navigates to the Speedometer page.
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            try
            {
                myValues[1] = double.Parse(myValueStr);
            }

            catch (Exception)
            {
                MessageBox.Show("Must enter a numeric value");
                return;
            }
            Speedometer pg = new Speedometer();
            double max;

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
                calculatedValue = myValues[0] / myValues[1];
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
                NavigationService.Navigate(new ErrorPage());
                return;
            }

            pg.GaugeCharacteristics.EndValue = max;
            pg.GaugeValues.Value = calculatedValue;
            NavigationService.Navigate(pg);


        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Clear();
            myValues[0] = 0;
            myValues[1] = 0;

            myTextBox.Focus();

        }

    }
}

