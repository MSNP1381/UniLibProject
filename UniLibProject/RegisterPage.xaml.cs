
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
            //check in Login table

            

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
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-BAJP60P ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //check existance
                cmd.CommandText = "select * from Login where username = '" + email + "'  and  password = '" + pass + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(" کاربر تکراری  ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //add user to Login table & Member Table
                    cmd.CommandText = "insert into Library (username, password, usertype) values ('" + email + "' , '" + pass + "' , '" + "member" + "') ";
                    cmd.CommandText = "insert into Member (mname, memail, mphone, msignupdate, mrenewaldate, mremainingdays, mbalance) values ('" + name + "' , '" + email + "' , '" + Phone + "' , '" + signupDate + "'  , '" + "0" + "' , '" + "0" + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Payment p = new Payment(name);
                    p.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("جاهای خالی را پر کنید", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }




            // EmailTbx;
            //  PassTbx;
            //  UserNameTbx;
            //  PhoneTbx;
            //Member newMember = new Member()
            //{
            //    name =UserNameTbx.Text,
            //    email =EmailTbx.Text,
            //    charge =0,
            //    Phone =Convert.ToDecimal( PhoneTbx.Text),
            //    pass=PassTbx.Text,
            //    date_added = DateTime.Now
            //};


            //var MemberFinder = (from m in _db.Member
            //                       where m.name == newMember.name || m.Phone == newMember.Phone || m.email == newMember.email
            //                       select m).ToList();
            //if (MemberFinder.Count > 0)
            //{
            //    MessageBox.Show("چنین کاربری وجود دارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);

            //}
            //else
            //{

            //    _db.Member.Add(newMember);
            //    _db.SaveChanges();
            //    var i = _db.Member.ToList();

            //    Payment p = new Payment();
            //    p.Show();
            //    this.Close();
            //}
        }


    }
}
