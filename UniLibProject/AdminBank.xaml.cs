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
    /// Interaction logic for AdminBank.xaml
    /// </summary>
    public partial class AdminBank : Window
    {
        public AdminBank()
        {
            InitializeComponent();
            //namayeshe listi az transaction ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from Bank", con);
            DataTable table = new DataTable("Bank");
            connDA.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
        }

        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            IncreaseBalance ib = new IncreaseBalance("admin");
            ib.Show();
            this.Close();
        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Close();
        }
    }
}
