using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-SDEJ6HG; Initial Catalog=Mivoski; Integrated Security=True");
            try
            {
                con.Open();
                string query = "INSERT INTO Customers(name, surname, username, email, password)values('" + this.txtName.Text + "','" + this.txtSurname.Text + "','" + this.txtUser.Text + "','" + this.txtEmail.Text + "','" + this.pass.Password + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your account has been saved!");

            BrJewl signCont = new BrJewl();
            signCont.Show();
            this.Close();
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
    }
}
