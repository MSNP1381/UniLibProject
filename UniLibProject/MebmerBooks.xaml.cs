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
    /// Interaction logic for MebmerBooks.xaml
    /// </summary>
    public partial class MebmerBooks : Window
    {
        int Id;
        UniLibDbEntities2 _db = new UniLibDbEntities2();
        public MebmerBooks(int Id)
        {
            this.Id = Id;
            InitializeComponent();
            var bookList =

               (from m in _db.Books
                where m.MemberId == Id
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

        private void MenuBookBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuAllBooksBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFinBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuSubscribBtn_Click(object sender, RoutedEventArgs e)
        {
            var i = new MemberSubscrib(Id);

        }

        private void MenuFinBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
