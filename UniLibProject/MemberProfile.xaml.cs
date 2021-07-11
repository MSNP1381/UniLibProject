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
    /// Interaction logic for MemberProfile.xaml
    /// </summary>
    public partial class MemberProfile : Window
    {
        string user;
        public MemberProfile(string username)
        {
            InitializeComponent();
            user = username;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LibraryDB ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Member where musername = '"+user+"' ";
            SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
            DataSet DS1 = new DataSet();
            DA1.Fill(DS1);
            textBlock2_Copy5.Text = DS1.Tables[0].Rows[0][1].ToString();
            textBlock2_Copy.Text = DS1.Tables[0].Rows[0][2].ToString();
            textBlock2_Copy6.Text = DS1.Tables[0].Rows[0][3].ToString();
            textBlock2_Copy7.Text = DS1.Tables[0].Rows[0][4].ToString();
            textBlock2_Copy8.Text = DS1.Tables[0].Rows[0][5].ToString();
            textBlock2_Copy9.Text = DS1.Tables[0].Rows[0][6].ToString();
            textBlock2_Copy10.Text = DS1.Tables[0].Rows[0][7].ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MembersDashboard md = new MembersDashboard(user);
            md.Show();
            this.Close();
        }
    }
}
