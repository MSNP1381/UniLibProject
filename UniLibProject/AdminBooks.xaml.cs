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
    /// Interaction logic for AdminBooks.xaml
    /// </summary>
    public partial class AdminBooks : Window
    {
        UniLibDbEntities2 _db = new UniLibDbEntities2();

        public AdminBooks()
        {
        InitializeComponent();
            var books=_db.Books.ToList();
            LvAddBooks.ItemsSource = books;
        }

       
        private void Add_bookBtn_Click(object sender, RoutedEventArgs e)
        {
            var ab = new AddBook();
            ab.ShowDialog();
            
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
    }
}
