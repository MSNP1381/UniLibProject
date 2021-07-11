
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Data;
using System.Data.SqlClient;

namespace UniLibProject
{

    public partial class RegisterPage : Window
    { 
       UniLibDbEntities2 _db = new UniLibDbEntities2();

    public RegisterPage()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void AddPicBtn_Click(object sender, RoutedEventArgs e)
        {
          
                OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    UserPicImg.Source = new BitmapImage(fileUri);
                
            }
        }

        private void GoPaymaentBtn_Click(object sender, RoutedEventArgs e)
        {
            //check if user already exists

            if (PassTbx.Text != "" && UserNameTbx.Text != "" && EmailTbx.Text != "")
            {
                string name = UserNameTbx.Text;
                string email = EmailTbx.Text;
                decimal Phone = Convert.ToDecimal(PhoneTbx.Text);
                string pass = PassTbx.Text;
                DateTime signupDate = DateTime.Now;
                int remainingDays = 0;
                int balance = 0;

                //regex email & phone

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
                    if (rd[1].ToString() == email)
                    {
                        flag = true;
                        break;
                    }
                }
                con.Close();
                if (flag == true)
                {
                    //Username exists
                    MessageBox.Show(" کاربر تکراری  ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                else
                {
                    //new user
                    //add user to Login table & Member Table
                    con = new SqlConnection();
                    con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into Member (mname, memail, mphone, msignupdate, mrenewaldate, mremainingdays, mbalance, mimage) values ('" + name + "' , '" + email + "' , '" + Phone + "' , '" + signupDate + "' ,   '" + signupDate + "' , '" + "0" + "' , '" + "0" + "' ,'"+ UserPicImg.Source + "'   ) ";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection();
                    con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into Login (username, pass, usertype) values ('" + email + "' , '" + pass + "' , '" + "member" + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    decimal money = 20000;
                    Payment p = new Payment(email, money);
                    p.Show();
                    this.Close();

                    
                }

            }
            else
            {
                MessageBox.Show("جاهای خالی را پر کنید", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }

   
                    
     



        }


    }
}
