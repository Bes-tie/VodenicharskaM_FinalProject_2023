using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace VodenicharskaM_FinalProject_2023
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-SDEJ6HG; Initial Catalog=Mivoski; Integrated Security=True");

            try
            {
                con.Open();
                string query = "SELECT * FROM Customers Where Username=@Username and Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUser.Text);
                sqlCmd.Parameters.AddWithValue("@Password", pass.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    MessageBox.Show("Welcome, {0}!", txtUser.Text);
                    BrJewl logCont = new BrJewl();
                    logCont.Show();
                    this.Close();
                }

                string query2 = "INSERT * INTO Appointments(username,password,time)vaues'" + this.txtUser.Text + "','" + this.pass.Password + "','" + this.txtTime.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your appointment has been saved!");

                else
                {
                    MessageBox.Show("Username or password are not correct!");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
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
            Steps win1 = new Steps();
            win1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Order win1 = new Order();
            win1.Show();
            this.Close();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
