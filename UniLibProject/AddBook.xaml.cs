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
                con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                
                //gashtan donbale ketab ba in moshakhasat tooye liste ketaba
                cmd.CommandText = "select * from Book where bname = '" + bName + "'  and  bauthor = '" + bAuthor + "'   and  bgenre = '" + bGenre+ "'   and   bcode = '" + bPubNo + "' ";
                //age ketab jadid bud
                cmd.CommandText = "insert into Book (bname, bauthor, bgenre, bcode, bcount) values ('" + bName + "' , '" + bAuthor + "' , '" + bGenre + "' , '" + bPubNo + "'  , '"+ bQuantity + "') ";
                //insert
                cmd.ExecuteNonQuery();
                //close
                con.Close();

                //make sure it's stored
                MessageBox.Show("Data saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                BookNameTbx.Clear();
                AuthotNameTbx.Clear();
                GenereTbx.Clear();
                PubNoTbx.Clear();

                // quantity change
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

