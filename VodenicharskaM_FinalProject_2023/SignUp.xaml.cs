﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VodenicharskaM_FinalProject_2023
{
    /// <summary>
    /// Interaction logic for SignYp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrJewl signCont = new BrJewl();
            signCont.Show();
            this.Close();
        }
    }
}
