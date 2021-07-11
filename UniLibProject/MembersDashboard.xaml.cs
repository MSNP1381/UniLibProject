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
    /// Interaction logic for MembersDashboard.xaml
    /// </summary>
    public partial class MembersDashboard : Window
    {
        string user;
        public MembersDashboard(string username)
        {
            InitializeComponent();
            textBlock.Text = username;
            user = username;
            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from Book", con);
            DataTable table = new DataTable("Book");
            connDA.Fill(table);
            dataGrid.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = table.DefaultView;
            con.Close();
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // amanat gereftane ketab
            BorrowBook bb = new BorrowBook(user);
            bb.Show();
            this.Close();
            

        }
    }
}
