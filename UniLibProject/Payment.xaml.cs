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
using UniLibProject.Contents;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        UniLibDbEntities2 _db = new UniLibDbEntities2();
        int Id {
            get;
        }
        private decimal
            money=20000;
        public Payment()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
            bool allCorrect = true;
            var cardNum=(CardNumTbx.Text);
            var Month = (MonthTbx.Text);
            var Year =(YearTbx.Text);
            var Cvv = (CvvTbx.Text);
            RegexClass.CardNumber(cardNum);
            RegexClass.CVV(Cvv);
            RegexClass.Expire(Year, Month);
            if (allCorrect) 
            {
                var TheMember = (from m in _db.Member
                                 where m.Id == Id
                                 select m
                         ).Single();
                TheMember.charge += this.money;
                _db.SaveChanges();
            }
            else
            {
                MessageBox.Show("چنین کارتی وجود ندارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
