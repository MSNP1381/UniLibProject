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
    /// Interaction logic for Employee_books.xaml
    /// </summary>
    public partial class EmployeeBooks : Window

    {
        int Eid;
        public UniLibDbEntities2 _db = new UniLibDbEntities2();
        public EmployeeBooks(int Eid)
        {
            this.Eid=Eid;
            InitializeComponent();

            var bookList =

        (from m in _db.Books
         where m.MemberId != null
         select m).DefaultIfEmpty().ToList();
            lvEmployees.ItemsSource = bookList;
        }

        private void MenuEmployeeEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ee = new EmployeeAccount();
            ee.Show();
            Close();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            var i = new EmployeeMembers(Eid);
            i.Show();
            Close();
        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var eb = new EmployeeBooks(Eid);
            eb.Show();
            Close();
        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {
            var i = new IncreaseBalance(true,200000);
            i.ShowDialog();

        }

        private void Add_bookBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void availableBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var bookList =

                (from m in _db.Books
                         where  m.MemberId==null
                          select m).DefaultIfEmpty().ToList();
            lvEmployees.ItemsSource = bookList;
        }

        private void notAvailableBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var bookList =

            (from m in _db.Books
             where m.MemberId != null
             select m).DefaultIfEmpty().ToList();
            lvEmployees.ItemsSource = bookList;
        }

        private void allBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var bookList = _db.Books.ToList();
            lvEmployees.ItemsSource = bookList;
        }
    }
}
