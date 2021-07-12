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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            var b = new Books();
            b.author =AuthotNameTbx.Text;
            b.code =Convert.ToDecimal( PubNoTbx.Text);
            b.Genere =GenereTbx.Text;
            b.name =BookNameTbx.Text;
            UniLibDbEntities2 Db = new UniLibDbEntities2();
            Db.Books.Add(b);
            Db.SaveChanges();
        }
    }
}
