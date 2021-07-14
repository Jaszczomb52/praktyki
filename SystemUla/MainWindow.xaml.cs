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

namespace SystemUla
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queen queen;
        public MainWindow()
        {
            InitializeComponent();
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" });
            workers[1] = new Worker(new string[] { "Pielęgnacja jaj", "Nauczanie pszczółek" });
            workers[2] = new Worker(new string[] { "Utrzymywanie ula", "Patrol" });
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", 
                "Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymywanie ula", "Patrol" });
            queen = new Queen(workers);
        }
        
        private void NexShiftButton(object sender, RoutedEventArgs e)
        {
            queen.WorkTheNextShift(int.Parse(Shift.Text));
        }

        private void AssignJobClick(object sender, RoutedEventArgs e)
        {
            if (queen.AssignWork(Combo.SelectedItem.ToString(), int.Parse(Shift.Text)) == false)
            {
                MessageBox.Show("Brak robotnic mogacych wykonac zadanie");
            }
            else
            {
                MessageBox.Show("Zadanie zlecone");
            }
        }
    }
}
