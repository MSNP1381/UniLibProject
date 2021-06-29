using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UniLibProject.Data;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



 public partial class MainWindow : Window
    {

        UniLibDbEntities2 _db = new UniLibDbEntities2();

        public MainWindow()
        {
            InitializeComponent();
     
            /*

                Member newMember = new Member()
                {
                    name = "dsa",
                    email = "dsfs",
                    balance = 3213213213,
                    date_added = DateTime.Now

                };
                Member newMember2 = new Member()
                {
                    name = "dsa2",
                    email = "dsfs2",
                    balance = 32132132123,
                    date_added = DateTime.Now                };

                _db.Members.Add(newMember);
            _db.SaveChanges();*/

            }
   

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage r = new RegisterPage();
            r.Show();
            this.Close();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            var pass = PasswordTbx.Password; var username = UserNameTbx.Text;
            if  (pass== "AdminLib123" &&  username== "admin") {
                adminEmployee ae = new adminEmployee();
                ae.Show();
                this.Close();
            }
            else
            {

                var theMember = (from m in _db.Member
                          where m.name == username && m.pass == pass
                          select m).DefaultIfEmpty().Single();
                if (theMember != null) 
                {

                }
                else 
                {
                    var theEmployee = (from m in _db.Employee
                                     where m.name == username && m.pass == pass
                                     select m).DefaultIfEmpty().Single();
                    if (theEmployee != null) 
                    {
                        var em = new EmployeeMembers();
                        em.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("چنین کاربری وجود ندارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
          
        }

        private void UserNameTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
            var box = sender as PasswordBox;
            if (box.Password == "") { 
                passwordtb.Visibility = Visibility.Visible;
            }
            else{
                passwordtb.Visibility = Visibility.Hidden;
            }
        }
    }
}