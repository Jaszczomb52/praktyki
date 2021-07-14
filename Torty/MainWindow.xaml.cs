using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Torty
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Party party;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Changed(object sender, TextChangedEventArgs e)
        {
            Changing();
        }

        private void ChangedCheck(object sender, RoutedEventArgs e)
        {
            Changing();
        }

        private void Changing()
        {
            try
            {
                int numberOfPeople = int.Parse(Text.Text);
                bool DecorCheck = check2.IsChecked.Value;
                bool HealthCheck = check1.IsChecked.Value;
                if (party == null)
                {
                    party = new Party(numberOfPeople, DecorCheck, HealthCheck);
                }
                else
                {
                    party.Refresh(numberOfPeople, DecorCheck, HealthCheck);
                }
                Price.Text = party.GetThePrice().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadź liczbę");
            }
        }
    }
}
