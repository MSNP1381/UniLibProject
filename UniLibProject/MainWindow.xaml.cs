using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UniLibProject.Data;
using System.Data;
using System.Data.SqlClient;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



 public partial class MainWindow : Window
    {

        UniLibDbEntities2 _db = new UniLibDbEntities2();

        public MainWindow()
        {
           
            InitializeComponent();
   
        }
   

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage r = new RegisterPage();
            r.Show();
            this.Close();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            var pass = PasswordTbx.Password; var username = UserNameTbx.Text;
            if (pass == "AdminLib123" && username == "admin")
            {
                AdminDashboard ad = new AdminDashboard();
                ad.Show();
                this.Close();
            }
            else if (pass != "" && username != "")
            {
                //establish connection
                bool flag = false;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Login";
                con.Open();

                //check existance
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[1].ToString() == username)
                    {
                        flag = true;
                        break;
                    }
                }
                con.Close();
                if (flag == true)
                {
                    //Username exists
                    con = new SqlConnection();
                    con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "select * from Login where username LIKE '" + username + "' ";

                    SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                    DataSet DS1 = new DataSet();
                    DA1.Fill(DS1);

                    string type = DS1.Tables[0].Rows[0][3].ToString(); 

                    if (type == "member")
                    {
                        MembersDashboard md = new MembersDashboard(username);
                        md.Show();
                        this.Close();

                    }
                    else
                    {
                        EmployeeDashboard ed = new EmployeeDashboard();
                        ed.Show();
                        this.Close();
                    }

                    cmd.ExecuteNonQuery();
                    con.Close();

                    //send to dashboard

                }
                else
                {

                    //    //Username doesn't exist.
                    MessageBox.Show(" کاربر یافت نشد  ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                    //clear textboxes   
                }

            }
            else
            {
                MessageBox.Show("جاهای خالی را پر کنید", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void UserNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
            var box = sender as PasswordBox;
            if (box.Password == "") { 
                passwordtb.Visibility = Visibility.Visible;
            }
            else{
                passwordtb.Visibility = Visibility.Hidden;
            }
        }
    }
}