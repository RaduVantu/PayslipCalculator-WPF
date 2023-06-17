using System.Windows;


namespace Payslip
{    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            //uses the Unit method from the LibraryClass to validate user input
            double hours = LibraryClass.Unit(HoursTBox.Text);
            double overhours = LibraryClass.Unit(OverHoursTBox.Text);
            double sickDays = LibraryClass.Unit(SickDaysTbox.Text);
            double bonus = LibraryClass.Unit(BonusTBox.Text);

            //depending on validation results, alerts the user for no or wrong input, or proceeds with the calculation
            if (hours == -1 || overhours == -1 || sickDays == -1 || bonus == -1)
            {
                MessageBox.Show("All values must be positive numbers!");
            }
            else if (hours == 0 && overhours == 0 && sickDays == 0 && bonus == 0)
            {
                MessageBox.Show("Nothing to calculate :)");
            }
            else
            {
                //variables store the user input
                double hourRate = double.Parse(Properties.Settings.Default.HRate);
                double overRate = double.Parse(Properties.Settings.Default.ORate);
                double sickRate = double.Parse(Properties.Settings.Default.SRate);
                double grossPay, taxablePay, tax, ni, pension, netPay;

                //calculation
                grossPay = hours * hourRate + overhours * overRate + sickDays * sickRate + bonus;

                //taxablePay can be negative if income does not excede personal allowance
                taxablePay = grossPay - (double.Parse(Properties.Settings.Default.PersAllow) / 12);

                tax = taxablePay * 0.2;
                ni = taxablePay * 0.12;
                pension = grossPay * (double.Parse(Properties.Settings.Default.PensProc) / 100);

                //if taxablePay is negative (income bellow personal allowance), tax and ni will be zero 
                if (tax < 0)
                {
                    tax = 0;
                }

                if (ni < 0)
                {
                    ni = 0;
                }

                netPay = grossPay - tax - ni - pension;

                new Results(HoursTBox.Text, OverHoursTBox.Text, SickDaysTbox.Text, BonusTBox.Text, grossPay.ToString(), tax.ToString(), ni.ToString(), pension.ToString(), netPay.ToString()).Show();
            }
        }

        //button that clears user input
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            HoursTBox.Clear();
            OverHoursTBox.Clear();
            SickDaysTbox.Clear();
            BonusTBox.Clear();
        }

        //settings (cog) button opens the SettingsWindow
        private void SetRatesBtn_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
        }
                
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
