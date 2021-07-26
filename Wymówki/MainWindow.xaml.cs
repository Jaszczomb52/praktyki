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
        bool changed = false;
        bool isFocused = false;
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
            {
                dir.SaveFile(excuseBox.Text, resultBox.Text, (DateTime)dateBox.SelectedDate);
                ChangeHandler(false);
            }
            else
                System.Windows.MessageBox.Show("Wprowadź poprawne dane i wybierz datę ostatniego użycia wymówki");
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dir.LoadFile();
                if (changed)
                {
                    if (System.Windows.MessageBox.Show("Nie zapisano zmian. Czy chcesz kontynuować?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        excuseBox.Text = dir.Text;
                        resultBox.Text = dir.Result;
                        fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                        dateBox.SelectedDate = dir.LastFileMod;
                        ChangeHandler(false);
                        Main.Title = dir.Name;
                    }
                }
                else 
                {
                    excuseBox.Text = dir.Text;
                    resultBox.Text = dir.Result;
                    fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                    dateBox.SelectedDate = dir.LastFileMod;
                    Main.Title = dir.Name;
                }
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
                dir.LoadRandomFile();
                if (changed)
                {
                    if (System.Windows.MessageBox.Show("Nie zapisano zmian. Czy chcesz kontynuować?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        excuseBox.Text = dir.Text;
                        resultBox.Text = dir.Result;
                        fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                        dateBox.SelectedDate = dir.LastFileMod;
                        ChangeHandler(false);
                        Main.Title = dir.Name;
                    }
                }
                else
                {
                    excuseBox.Text = dir.Text;
                    resultBox.Text = dir.Result;
                    fileDateBox.Text = dir.LastFileCreat.ToLongDateString();
                    dateBox.SelectedDate = dir.LastFileMod;
                    Main.Title = dir.Name;
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Błąd podczas ładowania pliku.");
            }
        }

        private void DataChanged(object sender, TextChangedEventArgs e)
        {
            if(isFocused)
            ChangeHandler(true);
        }

        private void DataChangedDate(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(isFocused)
            ChangeHandler(true);
        }

        private void ChangeHandler(bool status)
        {
            changed = status;
            if (status)
            {
                if (Main.Title.Substring(Main.Title.Length - 2, 2) != " *")
                    Main.Title += " *";
            }
            else
                //if (Main.Title != "MainWindow")
                    Main.Title = Main.Title.Substring(0, Main.Title.Length - 2);
        }

        private void FocusHandler(bool status)
        {
            isFocused = status;
        }

        private void excuseBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(true);
        }

        private void excuseBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(false);
        }

        private void resultBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(true);
        }

        private void resultBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(false);
        }

        private void dateBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(true);
        }

        private void dateBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FocusHandler(false);
        }
    }
}
