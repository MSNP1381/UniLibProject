﻿using System;
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
    /// Interaction logic for AdminBooks.xaml
    /// </summary>
    public partial class AdminBooks : Window
    {
        public AdminBooks()
        {
            InitializeComponent();
            //namayeshe listi az ketab ha 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = (LocalDb)\\LocalDBDemo ; database = master ; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            SqlDataAdapter connDA = new SqlDataAdapter("Select * from Book", con);
            DataTable table = new DataTable("Book");
            connDA.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;

        }

       
        private void Add_bookBtn_Click(object sender, RoutedEventArgs e)
        {
            AddBook ab = new AddBook();
            ab.Show();
            this.Hide();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            adminEmployee ae = new adminEmployee();
            ae.Show();
            this.Hide();
        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
