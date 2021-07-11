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
    /// Interaction logic for admin_employee.xaml
    /// </summary>
    public partial class adminEmployee : Window
    {
        public adminEmployee()
        {
            InitializeComponent();
            //namayeshe listi az employee ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from employee", con);
            DataTable table = new DataTable("employee");
            connDA.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            //add employees
            //if (PassTbx.Text != "" && UserNameTbx.Text != "" && EmailTbx.Text != "")
            //{ 
            //    //establish connection
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = "data source = DESKTOP-BAJP60P ; database = master ; integrated security = True";
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = con;
            //    con.Open();

            //    //gashtan donbale ketab ba in moshakhasat tooye liste ketaba
            //    cmd.CommandText = "select * from Employee where bname = '" + bName + "'  and  bauthor = '" + bAuthor + "'   and  bgenre = '" + bGenre + "'   and   bcode = '" + bPubNo + "' ";
            //    //age ketab jadid bud
            //    cmd.CommandText = "insert into Book (bname, bauthor, bgenre, bcode, bcount) values ('" + bName + "' , '" + bAuthor + "' , '" + bGenre + "' , '" + bPubNo + "'  , '" + "10" + "') ";
            //    //insert
            //    cmd.ExecuteNonQuery();
            //    //close
            //    con.Close();

            //    //make sure it's stored
            //    MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            //    BookNameTbx.Clear();
            //    AuthotNameTbx.Clear();
            //    GenereTbx.Clear();
            //    PubNoTbx.Clear();
            //}
        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminBooks ab = new AdminBooks();
            ab.Show();
            this.Hide(); 
        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee ae = new AddEmployee();
            ae.Show();
            this.Close();
        }

        private void btnShowBooks_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Close();
        }
    }
    class Employee2
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
