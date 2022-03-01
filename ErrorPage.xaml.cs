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
    /// Interaction logic for ErrorPage.xaml
    /// </summary>
    public partial class ErrorPage : Page
    {
        public ErrorPage(double calculatedValue, double divideByZero=1)
        {
            InitializeComponent();
            if(calculatedValue >= 10000000)
            {
                errorText.Text = "Can't display values greater than 9,999,999";
            }

            else if(divideByZero == 0)
            {
                errorText.Text = "Can't divide by zero";
            }
        }

        private void returnToCalculator_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Calculator());
        }
    }
}
