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
using System.IO;
using System.Windows.Forms;

namespace Wymówki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Files dir;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dir = new Files();
            DialogResult dr = dir.GetDirectory();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                saveButton.IsEnabled = true;
                loadButton.IsEnabled = true;
                randomButton.IsEnabled = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Wybierz poprawną ścieżkę folderu");
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (excuseBox.Text != "" && resultBox.Text != "" && dateBox.SelectedDate != null)
                dir.SaveFile(excuseBox.Text, resultBox.Text, (DateTime)dateBox.SelectedDate);
            else
                System.Windows.MessageBox.Show("Wprowadź poprawne dane i wybierz datę ostatniego użycia wymówki");
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] temp = dir.LoadFile().Split(new string[] { "*;&&;*" }, 2, StringSplitOptions.None);
                excuseBox.Text = temp[0];
                resultBox.Text = temp[1];
                fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                dateBox.SelectedDate = dir.LastFileMod;
            }
            catch(Exception)
            {
                System.Windows.MessageBox.Show("Błąd podczas ładowania pliku.");
            }
        }

        private void randomButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] temp = dir.LoadRandomFile().Split(new string[] { "*;&&;*" }, 2, StringSplitOptions.None);
                excuseBox.Text = temp[0];
                resultBox.Text = temp[1];
                fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                dateBox.SelectedDate = dir.LastFileMod;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Błąd podczas ładowania pliku.");
            }
        }
    }
}
