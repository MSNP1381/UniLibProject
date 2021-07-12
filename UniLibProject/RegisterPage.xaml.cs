using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using UniLibProject.Contents;

namespace UniLibProject
{
    public partial class RegisterPage : Window
    {
        private UniLibDbEntities2 _db = new UniLibDbEntities2();

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
            // EmailTbx; PassTbx; UserNameTbx; PhoneTbx;
            if (!(RegexClass.Email(EmailTbx.Text) && RegexClass.PhoneNumber(PhoneTbx.Text) && RegexClass.Username(UserNameTbx.Text)))
            {
                MessageBox.Show("بازبینی در اطلاعات", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Member newMember = new Member()
                {
                    name = UserNameTbx.Text,
                    email = EmailTbx.Text,
                    charge = 0,
                    Phone = Convert.ToDecimal(PhoneTbx.Text),
                    pass = PassTbx.Text,
                    date_added = DateTime.Now
                };

                var MemberFinder = (from m in _db.Member
                                    where m.name == newMember.name || m.Phone == newMember.Phone || m.email == newMember.email
                                    select m).DefaultIfEmpty().ToList();
                if (MemberFinder.Count > 0)
                {
                    MessageBox.Show("چنین کاربری وجود دارد", "اخطار", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    _db.Member.Add(newMember);
                    _db.SaveChanges();
                    var i = _db.Member.ToList();

                    Payment p = new Payment();
                    p.Show();
                    this.Close();
                }
            }
        }
    }
}