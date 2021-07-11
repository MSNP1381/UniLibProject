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
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Window
    {
        string username;
        string search;
        DateTime now = DateTime.Now;
        public ReturnBook(string username)
        {
            InitializeComponent();
            this.username = username;

            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from BRbook where brusername = '" + username + "' and brdatereturned = '" + null + "' ";
            SqlDataAdapter connDA = new SqlDataAdapter("Select * from BRbook where brusername = '" + username + "' and brdatereturned = '" + null + "' ", con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DataTable table = new DataTable("BRBook");
            connDA.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;

            int count = DS.Tables[0].Rows.Count;
            if (count != 0)
            {
                int[] brbids = new int[count];
                for (int i = 0; i < count; i++)
                {
                    brbids[i] = int.Parse(DS.Tables[0].Rows[0][2].ToString());
                }
                con.Close();
                con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                cmd = new SqlCommand();
                cmd.Connection = con;
                DA = new SqlDataAdapter(cmd);
                DS = new DataSet();
                for (int i = 0; i < count; i++)
                {
                    connDA = new SqlDataAdapter("Select * from Book where bid = '" + brbids[i] + "'  ", con);
                    cmd.CommandText = "Select * from Book where bid = '" + brbids[i] + "'  ";
                    DA.Fill(DS);
                }

                table = new DataTable("Book");
                connDA.Fill(table);
                dataGrid1.ItemsSource = table.DefaultView;
                con.Close();
            }
            else
            {
                MessageBox.Show("کاربر کتابی امانت نگرفته! ", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
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

                cmd.CommandText = "select * from BRbook where brbid = '" + bid + "' ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                count++;
                cmd.CommandText = "UPDATE book SET bcount = '" + count + "' where bid = '" + bid + "'   ";
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "delete from BRBook where brbid = '"+bid+"'  ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
