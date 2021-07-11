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
        DateTime now = DateTime.Now;
        public BorrowBook(string username)
        {
            InitializeComponent();
            this.username = username;

            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
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
            string text = tbxBidNo.Text;
            int bid;
            bool result = Int32.TryParse(text, out bid);
            if (result == false)
            {
                //error message box
                MessageBox.Show(" bid باید عدد باشد ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //bedast avordan teedad e ketabaye mojod too ketabkhune
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from Book where bid = '" + bid + "' "; 
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);
                int count = int.Parse(DS1.Tables[0].Rows[0][5].ToString());
                if (count >= 1)
                {
                    //marhale baadi
                    //chan ta ketab dare alan?
                    cmd.CommandText = "select * from BRbook where brusername = '" + username + "' and brdatereturned = '"+ null +"' ";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    int count2 = DS.Tables[0].Rows.Count;
                    if (count2 < 6)
                    {
                        //change book
                        count--;
                        cmd.CommandText = "UPDATE book SET bcount = '" + count + "' where bid = '" + bid + "'   ";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //change BRBook
                        con = new SqlConnection();
                        con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        con.Open();
                        DateTime now = DateTime.Now;
                        cmd.CommandText = "insert into BRbook (brusername, brbid, brdateborrowed, brdatereturned) values ('"+ username +"' , '"+ bid +"' , '"+ now +"' , '"+ null +"') ";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(" کتابای قرض گرفته بیشتر از 5 تاست! ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show(" کتاب موجود نیست! ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void tbxsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxsearch.Text == "")
            {
                //show all books
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
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
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MembersDashboard mb = new MembersDashboard(username);
            mb.Show();
            this.Close();
        }
    }
}
