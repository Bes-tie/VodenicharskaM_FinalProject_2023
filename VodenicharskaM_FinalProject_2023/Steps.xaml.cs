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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Steps : Window
    {
        public Steps()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BrJewl win1 = new BrJewl();
            win1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BrO win1 = new BrO();
            win1.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Calendar win1 = new Calendar();
            win1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Order win1 = new Order();
            win1.Show();
            this.Close();
        }
    }
}
