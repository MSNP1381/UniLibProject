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
    /// Interaction logic for admin_employee.xaml
    /// </summary>
    public partial class adminEmployee : Window
    {
        UniLibDbEntities2 _db = new UniLibDbEntities2();
        public adminEmployee()
        {
            InitializeComponent();
            var items = _db.Employee.ToList();
       
            lvEmployees.ItemsSource = items;
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {
            var e1 = new IncreaseBalance(2000000);
            e1.ShowDialog();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var ea = new EmployeeAccount();
            ea.ShowDialog();
            
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var i = lvEmployees.ItemTemplateSelector;
            
        }
    }
   
}
