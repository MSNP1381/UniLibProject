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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            //check if user already exists
            //check in Login table

            if ( tbxname.Text != "" && tbxemail.Text != "")
            {
                string name = tbxname.Text;
                string email = tbxemail.Text;
                decimal Phone = Convert.ToDecimal(tbxphone.Text);
                string pass = "pass"; //default password
                int balance = int.Parse(tbxbalance.Text); ;

                //regex email & phone

                //establish connection
                bool flag = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Login";
                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[1].ToString() == email)
                    {
                        flag = true;
                        break;
                    }
                }
                con.Close();
                if (flag == true)
                {
                    //Username exist
                    MessageBox.Show(" کارمند تکراری  ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //    //Username doesn't exist.
                    //    //add user to Login table & Employee Table
                    con = new SqlConnection();
                    con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into Login (username, pass, usertype) values ('" + email + "' , '" + pass + "' , '" + "employee" + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con = new SqlConnection();
                    con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into Employee (ename, eemail, ephone, ebalance) values ('" + name + "' , '" + email + "' , '" + Phone + "' , '" + balance + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                adminEmployee ae = new adminEmployee();
                ae.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("جاهای خالی را پر کنید", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            adminEmployee ae = new adminEmployee();
            ae.Show();
            this.Close();
        }
    }
}
