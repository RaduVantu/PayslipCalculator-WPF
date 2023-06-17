using System.Windows;


namespace Payslip
{
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            //uses the CheckValue method from the LibraryClass to validate user input
            if (LibraryClass.CheckValue(HourlyRateTBox.Text) &&
                 LibraryClass.CheckValue(OvertimeRateTbox.Text) &&
                 LibraryClass.CheckValue(SickPayRateTbox.Text) &&
                 LibraryClass.CheckValue(PensionPercentTbox.Text) &&
                 LibraryClass.CheckValue(TaxAllowanceTbox.Text))
            {
                //sets the user's rates in application properties, for the next time
                //the application is ran
                Properties.Settings.Default.HRate = HourlyRateTBox.Text;
                Properties.Settings.Default.ORate = OvertimeRateTbox.Text;
                Properties.Settings.Default.SRate = SickPayRateTbox.Text;
                Properties.Settings.Default.PensProc = PensionPercentTbox.Text;
                Properties.Settings.Default.PersAllow = TaxAllowanceTbox.Text;
                
                //saves the new rates as defaults and gives a confirmation to the user
                MessageBox.Show("Values set!");
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                //informs the user of invalid input
                MessageBox.Show("All values must be positive numbers!");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
