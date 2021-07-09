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
     
            //list<employee2> items = new list<employee2>();
            //items.add(new employee2() { name = "اصغر", id=0 });
            //items.add(new employee2() { name = "شفتالی",id=1});
            //items.add(new employee2() { name = "هعیم", id = 2 });
            //lvemployees.itemssource = items;
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

        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {
           
            AddBook ab = new AddBook();
            ab.Show();
            this.Hide(); //?????
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

        }

        private void btnShowBooks_Click(object sender, RoutedEventArgs e)
        {
            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-BAJP60P ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from Book", con);
            DataTable table = new DataTable("Book");
            connDA.Fill(table);
            dataGrid1.ItemsSource = table.DefaultView;

            MessageBox.Show("", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
    class Employee2
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
