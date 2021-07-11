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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            //make sure all fields are filled
            if (BookNameTbx.Text != "" && AuthotNameTbx.Text != "" && GenereTbx.Text != "" && PubNoTbx.Text != "")
            {
                string bName = BookNameTbx.Text;
                string bAuthor = AuthotNameTbx.Text;
                string bGenre = GenereTbx.Text;
                int bPubNo = int.Parse(PubNoTbx.Text);
                int bQuantity = int.Parse(tbxQuantity.Text);

                //establish connection
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //check existance
                cmd.CommandText = "select * from Book";
                SqlDataReader rd = cmd.ExecuteReader();
                bool flag = false;
                //case sensetive
                while (rd.Read())
                {
                    if ((rd[1].ToString() == bName) && (rd[2].ToString() == bAuthor) && (rd[3].ToString() == bGenre) && (int.Parse(rd[4].ToString()) == bPubNo))
                    {
                        flag = true;
                        break;
                    }
                }
                con.Close();
                if (flag == true)
                {
                    //book exists
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    SqlCommand cmdd = new SqlCommand();
                    cmdd.Connection = conn;
                    conn.Open();
                    cmdd.CommandText = "select * from Book where bname LIKE '" + bName + "' "; //check others too

                    SqlDataAdapter DA1 = new SqlDataAdapter(cmdd);
                    DataSet DS1 = new DataSet();
                    DA1.Fill(DS1);  

                    bQuantity += int.Parse(DS1.Tables[0].Rows[0][5].ToString());
                    int id = int.Parse(DS1.Tables[0].Rows[0][0].ToString());
                    cmdd.CommandText = "insert into Book (bname, bauthor, bgenre, bcode, bcount) values ('" + bName + "' , '" + bAuthor + "' , '" + bGenre + "' , '" + bPubNo + "'  , '" + bQuantity + "') ";
                    cmdd.ExecuteNonQuery();
                    conn.Close();

                    //delete older record
                    conn = new SqlConnection();
                    conn.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
                    cmdd = new SqlCommand();
                    cmdd.Connection = conn;
                    conn.Open();
                    cmdd.CommandText = "delete from Book where bid = '"+id+"' ";
                    cmdd.ExecuteNonQuery();
                    conn.Close();


                    MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    BookNameTbx.Clear();
                    AuthotNameTbx.Clear();
                    GenereTbx.Clear();
                    PubNoTbx.Clear();


                }

            }
            else
            {
                MessageBox.Show("Empty field not allowed", "warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            adminEmployee ae = new adminEmployee();
            ae.Show();
            this.Close();

        }

        private void btnShowBooks_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

