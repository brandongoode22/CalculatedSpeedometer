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
        int calculatedValue;
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
            Speedometer pg = new Speedometer();

            if (choice == "plus")
            {
                calculatedValue = myValues[0] + myValues[1];

            }

            else if(choice == "minus")
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

            this.Content = pg;
            pg.GaugeAttributes.Value = calculatedValue;


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
