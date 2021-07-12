using System.Windows;
using System;
namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for IncreaseBalance.xaml
    /// </summary>
    public partial class IncreaseBalance : Window
    {
        bool hide_them;
        int Amount;
        public bool is_admin { get; set; }
        public IncreaseBalance(int amount)
        {
            hide_them = false;
            Amount = amount;
            InitializeComponent();
        }public IncreaseBalance(bool hideIt,int amount)
        {
            hide_them = hideIt;
            InitializeComponent();
            Amount = amount;
            AddAmount.Visibility = Visibility.Hidden;
            AddBtn.Visibility = Visibility.Hidden;
            
        }
        void set_amount() =>AmontTB.Text=Convert .ToString(Amount);
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
