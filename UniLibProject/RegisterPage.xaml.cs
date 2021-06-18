using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace UniLibProject
{

    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
        }

       

        private void AddPicBtn_Click(object sender, RoutedEventArgs e)
        {
          
                OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    UserPicImg.Source = new BitmapImage(fileUri);
                
            }
        }

        private void GoPaymaentBtn_Click(object sender, RoutedEventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            this.Close();

        }


    }
}
