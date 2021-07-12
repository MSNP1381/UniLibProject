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

            //var mem = new Member();
            //mem.name =;
            //mem.Phone =;
            //mem.pass =;
            //mem.charge =;
            //mem.date_added =;
            //mem.date_charged=;
            //mem.days_left =;
    
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
            //EmployeeBooks eb = new EmployeeBooks();
            //eb.Show();
            //Close();
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
                    var mb = new MebmerBooks(theMember.Id);
                    mb.Show();
                    Close();
                }
                else 
                {
                    var theEmployee = (from m in _db.Employee
                                     where m.name == username && m.pass == pass
                                     select m).DefaultIfEmpty().Single();
                    if (theEmployee != null) 
                    {
                        var em = new EmployeeMembers(theEmployee.Id);
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