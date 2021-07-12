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
    /// Interaction logic for EmployeeAccount.xaml
    /// </summary>

    public partial class EmployeeAccount : Window
    {
        UniLibDbEntities2 _db = new UniLibDbEntities2();

        private bool isCreate = false;
        int Eid;
        private Employee _Employee;
        public EmployeeAccount()
        {
            InitializeComponent();
            isCreate = true;
        }
        public EmployeeAccount(int Id)
        {
            Eid = Id;
            InitializeComponent();
            _Employee
              = (from m in _db.Employee where m.Id == Eid select m).Single();
            var username = name1.Text = _Employee.name;
            var pass = Family1.Text = _Employee.pass;
            var phone = phoneTbx.Text = _Employee.phone;

        }

        private void UserIdTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = name1.Text;
            var pass = Family1.Text;
            var phone = phoneTbx.Text;

            if (!(username != "" && pass != "" && phone != "") || !RegexClass.PhoneNumber(phone) || !RegexClass.Username(username))
            {
                MessageBox.Show("تمام موار د پر شود", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (isCreate)
                {
                    var emp = new Employee { name = username, pass = pass, phone = phone };
                    _db.Employee.Add(emp);
                    _db.SaveChanges();
                    var m = new MainWindow();
                    m.Show();
                    Close();
                }
                else
                {
                    var emp = _db.Employee.Find(Eid);
                    if (emp == null)
                    {
                        MessageBox.Show("دوباره تلاش کنید", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);

                        Close();
                    }
                    emp.name = username;
                    emp.pass = pass;
                    emp.phone = phone;
                    _db.SaveChanges();
                    var m = new MainWindow();
                    m.Show();
                    Close();
                }
            }
        }
    }
}