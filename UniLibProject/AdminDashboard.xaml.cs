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

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            adminEmployee ae = new adminEmployee();
            ae.Show();
            this.Close();
        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminBooks ab = new AdminBooks();
            ab.Show();
            this.Close();
        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminBank ab = new AdminBank();
            ab.Show();
            this.Close();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
