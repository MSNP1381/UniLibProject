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
    /// Interaction logic for EmployeeMembers.xaml
    /// </summary>
    public partial class EmployeeMembers : Window
    {
        UniLibDbEntities2 _db = new UniLibDbEntities2();
      int EId;
        DateTime expireDate = new DateTime();
        public EmployeeMembers(int Id)
        {
            EId = Id;
    
            InitializeComponent();
            LateBackBtn_Click(null, null);
        }

        private void MenuEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var eb = new EmployeeBooks(EId);
            eb.Show();
            Close();

        }

        private void MenuFinBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuEmployeeEditBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void allMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            var items = (


                              from x in _db.Member

                              select x
                              ).ToList();
            lvEmployees.ItemsSource = items;
        }

        private void LateBackBtn_Click(object sender, RoutedEventArgs e)
        {
            expireDate = DateTime.Now.AddDays(-14);
    var items =(        
                        from m in _db.Books 
  
                        from x in _db.Member 

                        where x.Id==m.MemberId
                        &&
                        m.BorrowDate<expireDate
                        select x
                        ).ToList();
            lvEmployees.ItemsSource = items;

        }

        private void LateFinBtn_Click(object sender, RoutedEventArgs e)
        {
            expireDate = DateTime.Now.AddDays(-30);
            var items = (
                           

                                from x in _db.Member

                             where x.date_charged <= expireDate
                                select x
                                ).ToList();
            lvEmployees.ItemsSource = items;
        }
    }
}
