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

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-SDEJ6HG; Initial Catalog=Mivoski; Integrated Security=True");


            try
            {
                con.Open();
                string query = "SELECT name,surname from Customers where username = '" + txtUser.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", txtUser.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    txtName.Text = reader["name"].ToString();
                    txtSurname.Text = reader["surname"].ToString();
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

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtTime.Text = calendar.SelectedDate.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-SDEJ6HG; Initial Catalog=Mivoski; Integrated Security=True");

            try
            {
                con1.Open();
                string query = "INSERT INTO Appointments(username,name,surname,time,purpose)values ('" + this.txtUser.Text + "','" + this.txtName.Text + "','" + this.txtSurname.Text + "','" + this.txtTime.Text + "','" + this.txtPurp.Text + "') ";
                SqlCommand cmd = new SqlCommand(query, con1);
                cmd.ExecuteNonQuery();

                //data verification
                if (con1.State == ConnectionState.Closed)
                    con1.Open();
                string query1 = "SELECT COUNT(1) FROM Customers Where username=@Username and password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, con1);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUser.Text);
                sqlCmd.Parameters.AddWithValue("@Password", pass.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Your appointment has been successfully saved!");
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
                con1.Close();
            }
        }
    }
}
