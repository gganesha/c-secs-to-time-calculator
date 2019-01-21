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

namespace Week4Group1_TimeCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// Time Calculator
    /// User enters a number of seconds and works as follows:
    /// 60 seconds in a minute --> seconds greater than 60, program should diplay number of minutes in that many seconds
    /// 3600 seconds in an hour --> seconds greater than 3600, program should display number of hours in that many seconds
    /// 86,400 seconds in a day --> seconds greater than 86,400, program should display number of days in that many seconds
    public partial class MainWindow : Window
    {
        VM2 vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new VM2();
            DataContext = vm;
        }
    }
}
