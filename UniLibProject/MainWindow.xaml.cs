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
            if  (pass== "AdminLib123" &&  username== "admin") {
                adminEmployee ae = new adminEmployee();
                ae.Show();
                this.Close();
            }
            else if (username == "guest" && pass == "guest")
            {
                MembersDashboard md = new MembersDashboard(username);
                md.Show();
                this.Close();
            }
            else if (pass!= "" && username!="")
            {
                //establish connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //check existance
                cmd.CommandText = "select * from Login where username = '" + username + "'  and  password = '" + pass + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string usertype = "member";
                    //check usertype and show relatd form
                    if (usertype == "member")
                    {
                        MembersDashboard md = new MembersDashboard(username);
                        md.Show();
                        this.Close();
                    }
                }
                else 
                {
                   MessageBox.Show("چنین کاربری وجود ندارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
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