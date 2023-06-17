using System.Windows;

namespace Payslip
{
    public partial class Results : Window
    {
        //receives values from MainWindow and populates the specific labels with them
        public Results(string hours, string over, string sick, string bonus, string gross, string tax, string ni, string pens, string net)
        {
            InitializeComponent();

            //if no(or 0) user input for hours, sets the 'no' value to the respective label
            //(same for overtime, sick days and bonus)
            //the check can be done using the Length property of strings or the IsNullOrEmpty metho
            if (hours.Length == 0)
            {
                HoursTBlock.Text = "no";
            }
            else
            {
                HoursTBlock.Text = hours;
            }

            if (string.IsNullOrEmpty(over))
            {
                OverTBlock.Text = "no";
            }
            else
            {
                OverTBlock.Text = over;
            }

            if (!string.IsNullOrEmpty(sick))
            {
                SickTBlock.Text = sick;
            }
            else
            {
                SickTBlock.Text = "no";
            }

            if (bonus.Length == 0)
            {
                BonusTBlock.Text = "no";
            }
            else
            {
                BonusTBlock.Text = bonus;
            }

            GrossTBlock.Text = gross;
            TaxTBlock.Text = tax;
            NiTBlock.Text = ni;
            PensTBlock.Text = pens;
            NetTBlock.Text = net;
        }

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
