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
    public partial class MainWindow : Window
    {
        int[] myValues = new int[2];
        string choice;
        int calculatedSum;
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            myValues[0] = int.Parse(myValueStr);
            myTextBox.Clear();
            choice = "plus";
            myTextBox.Focus();

            
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            myValues[0] = int.Parse(myValueStr);
            myTextBox.Clear();
            choice = "minus";
            myTextBox.Focus();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            myValues[0] = int.Parse(myValueStr);
            myTextBox.Clear();
            choice = "multiply";
            myTextBox.Focus();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            myValues[0] = int.Parse(myValueStr);
            myTextBox.Clear();
            choice = "divide";
            myTextBox.Focus();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            string myValueStr;
            myValueStr = myTextBox.Text;
            myValues[1] = int.Parse(myValueStr);

            if(choice == "plus")
            {
                myTextBox.Clear();
                calculatedSum = myValues[0] + myValues[1];
                myTextBox.Text = calculatedSum.ToString();

            }

            else if(choice == "minus")
            {
                myTextBox.Clear();
                myTextBox.Text = (myValues[0] - myValues[1]).ToString();

            }

            else if (choice == "multiply")
            {
                myTextBox.Clear();
                myTextBox.Text = (myValues[0] * myValues[1]).ToString();

            }

            else if (choice == "divide")
            {
                myTextBox.Clear();
                myTextBox.Text = (myValues[0] / myValues[1]).ToString();

            }


        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Clear();
            myValues[0] = 0;
            myValues[1] = 0;

            myTextBox.Focus();

        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Speedometer pg = new Speedometer();
            this.Content = pg;
            pg.GaugeAttributes.Value = calculatedSum;
        }
    }
}
