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
        public adminEmployee()
        {
            InitializeComponent();
     
            List<Employee2> items = new List<Employee2>();
            items.Add(new Employee2() { Name = "اصغر", Id=0 });
            items.Add(new Employee2() { Name = "شفتالی",Id=1});
            items.Add(new Employee2() { Name = "هعیم", Id = 2 });
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

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    class Employee2
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
