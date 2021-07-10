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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : Window
    {
        string username;
        string search;
        public BorrowBook(string username)
        {
            InitializeComponent();
            this.username = username;

            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from Book", con);
            DataTable table = new DataTable("Book");
            connDA.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
            con.Close();
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            //check if it's ok 2 borrow

        }

        private void tbxsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxsearch.Text == "")
            {
                //show all books
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                SqlDataAdapter connDA = new SqlDataAdapter("Select * from Book", con);
                DataTable table = new DataTable("Book");
                connDA.Fill(table);
                dataGrid.ItemsSource = table.DefaultView;
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                SqlDataAdapter connDA;
                if (search == "bookname")
                    connDA = new SqlDataAdapter("Select * from Book where bname LIKE '" + tbxsearch.Text + "%' ", con);
                else if (search == "bookauthor")
                    connDA = new SqlDataAdapter("Select * from Book where bauthor LIKE '" + tbxsearch.Text + "%' ", con);
                else if (search == "bookgenre")
                    connDA = new SqlDataAdapter("Select * from Book where bgenre LIKE '" + tbxsearch.Text + "%' ", con);
                else
                    connDA = new SqlDataAdapter("Select * from Book", con);

                DataTable table = new DataTable("Book");
                connDA.Fill(table);
                dataGrid.ItemsSource = table.DefaultView;
                con.Close();

            }
        }

        private void rbtnbname_Checked(object sender, RoutedEventArgs e)
        {
            search = "bookname";
        }

        private void rbtnbauthor_Checked(object sender, RoutedEventArgs e)
        {
            search = "bookauthor";
        }

        private void rbtnbgenre_Checked(object sender, RoutedEventArgs e)
        {
            search = "bookgenre";
        }

        private void dataGrid_CellClick(object sender, SelectionChangedEventArgs e)
        {
            //select book to borrow

            if (dataGrid.SelectedItems.Count > 0)
            {
                //int rowid = int.Parse(dataGrid.SelectedItems.[0].[1].Value.ToString());
            }
               // int rowid = int.Parse(dataGrid.Rows[e.Row])
        }
    }
}
