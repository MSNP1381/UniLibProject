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
    /// Interaction logic for MemberAllBooks.xaml
    /// </summary>
    public partial class MemberAllBooks : Window
    {

        UniLibDbEntities2 _db = new UniLibDbEntities2();
        public MemberAllBooks
        (   )
        {
       
            InitializeComponent();
            var bookList =

               (from m in _db.Books
           
                select m).DefaultIfEmpty().ToList();
            LvAddBooks.ItemsSource = bookList;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {


        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
