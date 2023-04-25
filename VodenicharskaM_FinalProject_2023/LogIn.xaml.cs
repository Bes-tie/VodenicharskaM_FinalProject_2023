using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VodenicharskaM_FinalProject_2023
{
    public partial class LogIn : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignUp signCont = new SignUp();
            signCont.Show();
            this.Close();
        }
    }
}
