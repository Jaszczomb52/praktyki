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

namespace Dom
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;

        public MainWindow()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Salon", "dywan", "dębowe drzwi z mosiężną klamką");
            diningRoom = new Room("Jadalnia", "stół z krzesłami");
            kitchen = new RoomWithDoor("Kuchnia", "sztućce", "rozsuwane drzwi");

            frontYard = new OutsideWithDoor("Podwórko przed domem", true, "dębowe drzwi z mosiężną klamką");
            backYard = new OutsideWithDoor("Podwórko za domem", true, "rozsuwane drzwi");
            garden = new Outside("Ogród", true);

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exits.Items.Clear();
            for( int i = 0; i<currentLocation.Exits.Length;i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;

            if(currentLocation is IHasExteriorDoor)
            {
                goThrough.Visibility = Visibility.Visible;
            }
            else
            {
                goThrough.Visibility = Visibility.Hidden;
            }
        }

        private void goHereClick(object sender, RoutedEventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughClick(object sender, RoutedEventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

    }
}
