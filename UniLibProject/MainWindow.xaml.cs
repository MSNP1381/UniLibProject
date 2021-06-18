using System;
using System.Windows;
using System.Windows.Controls;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            adminEmployee ae = new adminEmployee();
            ae.Show();
            this.Close();
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