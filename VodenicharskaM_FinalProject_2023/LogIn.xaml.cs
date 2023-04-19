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

namespace VodenicharskaM_FinalProject_2023
{
    public partial class LogIn : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrJewl logCont = new BrJewl();
            logCont.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignUp signCont = new SignUp();
            signCont.Show();
            this.Close();
        }
    }
}
