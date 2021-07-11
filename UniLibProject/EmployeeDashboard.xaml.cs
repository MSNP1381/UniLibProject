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
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void btnbookstab_Click(object sender, RoutedEventArgs e)
        {
            EmployeeBooks eb = new EmployeeBooks();
            eb.Show();
            this.Close();
        }

        private void btnmemberstab_Click(object sender, RoutedEventArgs e)
        {
            EmployeeMembers em = new EmployeeMembers();
            em.Show();
            this.Close();
        }

        private void btnprofile_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAccount ea = new EmployeeAccount();
            ea.Show();
            this.Close();
        }
    }
}
