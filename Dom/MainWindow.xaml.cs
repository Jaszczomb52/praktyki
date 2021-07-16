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
using System.Threading;

namespace Dom
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Map map = new Map();

        Location currentLocation;

        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;
        RoomWithTunel garage;

        RoomWithDoor shed;
        RoomWithTunel stashRoom;

        OutsideWithDoor westYard;
        OutsideWithTunel garden;
        Outside eastYard;
        OutsideWithDoor betweenYard;


        public MainWindow()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Salon", "dywan", "dębowe drzwi z mosiężną klamką",map.livingRoomWaypoint);
            diningRoom = new Room("Jadalnia", "stół z krzesłami",map.diningWaypoint);
            kitchen = new RoomWithDoor("Kuchnia", "sztućce", "rozsuwane drzwi",map.kitchenWaypoint);
            garage = new RoomWithTunel("Garaż", "narzędzia","studzienka kanalizacyjna",map.garageWaypoint);

            westYard = new OutsideWithDoor("Podworko przed domem", true, "dębowe drzwi z mosiężną klamką",map.westWaypoint);
            eastYard = new Outside("Podwórko między ogrodem a szopą", true,map.eastWaypoint);
            betweenYard = new OutsideWithDoor("Podwórko za domem", true, "rozsuwane drzwi",map.betweenWaypoint);
            garden = new OutsideWithTunel("Ogród", true, "Między krzakami żywopłotu widać dziurę",map.gardenWaypoint);

            shed = new RoomWithDoor("Szopa", "na podłodze leżą rozrzucone narzędzia", "drewniane drzwi z kłódką",map.shedWaypoint);
            stashRoom = new RoomWithTunel("Składzik", "miotły w rogu", "W podłodze wybita jest dziura",map.stashWaypoint);

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom, garage };
            kitchen.Exits = new Location[] { diningRoom };
            garage.Exits = new Location[] { livingRoom };
            garage.Tunels = new Location[] { garden, stashRoom};

            eastYard.Exits = new Location[] { garden, betweenYard };
            westYard.Exits = new Location[] { garden };
            betweenYard.Exits = new Location[] { garden, eastYard };
            garden.Exits = new Location[] { westYard, eastYard, betweenYard };
            garden.Tunels = new Location[] { garage, stashRoom };

            shed.Exits = new Location[] { stashRoom };
            stashRoom.Exits = new Location[] { shed };
            stashRoom.Tunels = new Location[] { garden, garage };

            livingRoom.DoorLocation = westYard;
            westYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = betweenYard;
            betweenYard.DoorLocation = kitchen;

            shed.DoorLocation = betweenYard;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            mapWaypoints(currentLocation, newLocation);
            currentLocation = newLocation;
            exits.Items.Clear();
            for( int i = 0; i<currentLocation.Exits.Length;i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;

            tunels.Items.Clear();
            

            description.Text = currentLocation.Description;

            if(currentLocation is IHasExteriorDoor)
            {
                goThrough.Visibility = Visibility.Visible;
            }
            else
            {
                goThrough.Visibility = Visibility.Hidden;
            }

            if (currentLocation is IHasHole)
            {
                tunelGoTo.Visibility = Visibility.Visible;
                for (int i = 0; i < currentLocation.Tunels.Length; i++)
                {
                    tunels.Items.Add(currentLocation.Tunels[i].Name);
                }
                tunels.SelectedIndex = 0;
            }
            else
            {
                tunelGoTo.Visibility = Visibility.Hidden;
            }
        }

        private void goHereClick(object sender, RoutedEventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
            Thread.Sleep(500);
        }

        private void goThroughClick(object sender, RoutedEventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void showMapClick(object sender, RoutedEventArgs e)
        {
            map.Visibility = Visibility.Visible;
        }

        private void goHereTunelClick(object sender, RoutedEventArgs e)
        {
            MoveToANewLocation(currentLocation.Tunels[tunels.SelectedIndex]);
        }

        private void mapWaypoints(Location currentLocation, Location newLocation)
        {
            if (currentLocation != null)
                currentLocation.waypoint.Visibility = Visibility.Hidden;
            currentLocation = newLocation;
            currentLocation.waypoint.Visibility = Visibility.Visible;
        }
    }
}
