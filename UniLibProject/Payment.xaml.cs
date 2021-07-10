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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        string username;
        decimal money;
        UniLibDbEntities2 _db = new UniLibDbEntities2();
        int Id {
            get;
        }
        public Payment(string username, decimal money)
        {
            InitializeComponent();
            tblmoney.Text = money.ToString();
            this.money = money;
            this.username = username;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
           
            if (tbxCardNo.Text!="" && tbxMonth.Text!="" && tbxYear.Text!="" ) 
            {
                //regex
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= (LocalDb)\\LocalDBDemo; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con; 
                con.Open();
                cmd.CommandText = "Update Member set mbalance ='"+money+"' and mremainingdays = '"+"30"+"'  whrere username = '"+username +"' ";
                cmd.CommandText = "Update Bank set busername ='" + username + "' and btransaction = '" + money + "'  and btime = '" + DateTime.Now + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("چنین کارتی وجود ندارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
