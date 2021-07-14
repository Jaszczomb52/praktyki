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
        BDParty BDparty;

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
                bool decorCheck = check2.IsChecked.Value;
                bool healthCheck = check1.IsChecked.Value;
                if (party == null)
                {
                    party = new Party(numberOfPeople, decorCheck, healthCheck);
                }
                else
                {
                    party.Refresh(numberOfPeople, decorCheck, healthCheck);
                }
                Price.Text = party.GetThePrice().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadź liczbę");
            }
        }

        private void BDChanged(object sender, TextChangedEventArgs e)
        {
            BDChanging();
        }

        private void BDChangedCheck(object sender, RoutedEventArgs e)
        {
            BDChanging();
        }

        private void BDCake(object sender, TextChangedEventArgs e)
        {
            TextForCake();
            if ((string)CakeText.Content != "ZBYT DŁUGI")
                BDChanging();
        }

        private void BDChanging()
        {
            try
            {
                int numberOfPeople = int.Parse(NumberOfPersons.Text);
                bool decorCheck = Check3.IsChecked.Value;
                string cakeText = CakeTextBox.Text;
                if(BDparty == null)
                {
                    BDparty = new BDParty(numberOfPeople, decorCheck, cakeText, BDParty.CakeTextCheck(numberOfPeople));
                }
                else
                {
                    BDparty.Refresh(numberOfPeople, decorCheck, cakeText, BDParty.CakeTextCheck(numberOfPeople));
                }
                BDPrice.Text = BDparty.GetThePrice().ToString();
                
            }
            catch(Exception)
            {
                MessageBox.Show("Najpierw wprowadz poprawna ilosc osob");
            }
        }

        private void TextForCake()
        {
            if(BDparty == null)
            {
                MessageBox.Show("Najpierw wpisz liczbe osob");
            }
            else
            {
                try
                {
                TextParse();
                }
                catch(Exception)
                {
                    MessageBox.Show("Błąd podczas zapisywania tekstu");
                }
            }
        }

        private void TextParse()
        {
            if(BDparty.ReturnCakeSize() == 20)
            {
                if(CakeTextBox.Text.Length <= 16)
                {
                    CakeText.Background = Brushes.Transparent;
                    CakeText.Content = CakeTextBox.Text;
                }
                else
                {
                    CakeText.Background = Brushes.Red;
                    CakeText.Content = "ZBYT DŁUGI";
                }
            }
            else
            {
                if(CakeTextBox.Text.Length <= 40)
                {
                    CakeText.Background = Brushes.Transparent;
                    CakeText.Content = CakeTextBox.Text;
                }
                else
                {
                    CakeText.Background = Brushes.Red;
                    CakeText.Content = "ZBYT DŁUGI";
                }
            }
        }

    }
}
