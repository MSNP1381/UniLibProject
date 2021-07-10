using System.Windows;

namespace UniLibProject
{
    /// <summary>
    /// Interaction logic for IncreaseBalance.xaml
    /// </summary>
    public partial class IncreaseBalance : Window
    {
        public IncreaseBalance()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal money = decimal.Parse(tbxMoney.Text);
            Payment p = new Payment("admin" , money);
            this.Close();

        }
    }
}
