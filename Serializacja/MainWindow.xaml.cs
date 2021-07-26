using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Serializacja
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Guy Joe;
        Guy Bob;
        Guy Bank;
        public MainWindow()
        {
            InitializeComponent();
            Joe = new Guy(50, "Joe");
            Bob = new Guy(100, "Bob");
            Bank = new Guy(100, "Bank");
            Refresh();
        }

        private void Refresh()
        {
            JoeLabel.Content = Joe.ToString();
            BobLabel.Content = Bob.ToString();
            BankLabel.Content = Bank.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bank.SendMoney(Joe, 10);
            Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bob.SendMoney(Bank, 5);
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Joe.SendMoney(Bob, 10);
            Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Bob.SendMoney(Joe, 5);
            Refresh();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog fd = new SaveFileDialog();
            fd.ShowDialog();
            using (Stream output = File.Create(fd.FileName))
            {
                formatter.Serialize(output, Joe);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            using (Stream input = File.OpenRead(fd.FileName))
            {
                Joe = (Guy)formatter.Deserialize(input);
                Refresh();
            }
        }
    }
}
