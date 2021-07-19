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
        Location currentLocation;

        RoomWithExtDoorAndSpot livingRoom;
        RoomWithHidingSpot diningRoom;
        RoomWithDoor kitchen;
        RoomWithTunelAndSpot garage;

        RoomWithDoor shed;
        RoomWithTunelAndSpot stashRoom;

        OutsideWithDoor westYard;
        OutsideWithTunelAndSpot garden;
        OutsideWithHidingSpot eastYard;
        OutsideWithTwoDoors betweenYard;

        HidingSpot diningSpot;
        HidingSpot eastSpot;
        HidingSpot garageSpot;
        HidingSpot livingSpot;
        HidingSpot gardenSpot;
        HidingSpot stashSpot;

        public MainWindow()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);

            Ellipse[] waypoints = {garageWaypoint, diningWaypoint,kitchenWaypoint,betweenWaypoint,
                shedWaypoint,stashWaypoint,westWaypoint,eastWaypoint,gardenWaypoint, diningSpotWaypoint,
                garageSpotWaypoint,livingSpotWaypoint,stashSpotWaypoint,gardenSpotWaypoint,eastSpotWaypoint};
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i].Visibility = Visibility.Hidden;
            }

        }

        private void CreateObjects()
        {
            diningSpot = new HidingSpot("Szafa", diningSpotWaypoint);
            eastSpot = new HidingSpot("Gęste krzaki", eastSpotWaypoint);
            garageSpot = new HidingSpot("Stół zawalony narzędziami", garageSpotWaypoint);
            livingSpot = new HidingSpot("Szafa na ubrania", livingSpotWaypoint);
            gardenSpot = new HidingSpot("Gęsty zakręcony żywopłot", gardenSpotWaypoint);
            stashSpot = new HidingSpot("Beczka", stashSpotWaypoint);

            livingRoom = new RoomWithExtDoorAndSpot("Salon", "dywan", "dębowe drzwi z mosiężną klamką","dużą szafę",livingRoomWaypoint,livingSpot);
            diningRoom = new RoomWithHidingSpot("Jadalnia", "stół z krzesłami","pustą szafkę na naczynia",diningWaypoint,diningSpot);
            kitchen = new RoomWithDoor("Kuchnia", "sztućce", "rozsuwane drzwi",kitchenWaypoint);
            garage = new RoomWithTunelAndSpot("Garaż", "narzędzia","studzienkę kanalizacyjną","pustą szafkę na narzędzia",garageWaypoint,garageSpot);

            westYard = new OutsideWithDoor("Podworko przed domem", true, "dębowe drzwi z mosiężną klamką",westWaypoint);
            eastYard = new OutsideWithHidingSpot("Podwórko między ogrodem a szopą", true,"duże, gęste krzaki" ,eastWaypoint,eastSpot);
            betweenYard = new OutsideWithTwoDoors("Podwórko za domem", true, new string[]{ "rozsuwane drzwi","duże drewniane drzwi"},betweenWaypoint);
            garden = new OutsideWithTunelAndSpot("Ogród", true, "dziurę w ziemi między krzakami","zakręcony żywopłot",gardenWaypoint,gardenSpot);

            shed = new RoomWithDoor("Szopa", "na podłodze leżą rozrzucone narzędzia", "drewniane drzwi z kłódką",shedWaypoint);
            stashRoom = new RoomWithTunelAndSpot("Składzik", "miotły w rogu", "dziurę wybitą w podłodze","pustą beczkę",stashWaypoint,stashSpot);

            diningSpot.GetOut = diningRoom;
            eastSpot.GetOut = eastYard;
            garageSpot.GetOut = garage;
            livingSpot.GetOut = livingRoom;
            gardenSpot.GetOut = garden;
            stashSpot.GetOut = stashRoom;

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
            betweenYard.DoorLocation = new Location[] { kitchen, shed};

            shed.DoorLocation = betweenYard;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            LoadLocations(newLocation);

            hasExtDoor();
            hasHole();
            hasHidingSpot();
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

        private void LoadLocations(Location newLocation)
        {
            if(newLocation is IHasTwoDoors)
            {
                mapWaypoints(currentLocation, newLocation);
                currentLocation = newLocation;
                description.Text = currentLocation.Description;
                DoorBtn1.Visibility = Visibility.Visible;
                DoorBtn2.Visibility = Visibility.Visible;
            }
            if (!(newLocation is IHidingSpot))
            {
                mapWaypoints(currentLocation, newLocation);
                currentLocation = newLocation;
                exits.Items.Clear();
                for (int i = 0; i < currentLocation.Exits.Length; i++)
                {
                    exits.Items.Add(currentLocation.Exits[i].Name);
                }
                exits.SelectedIndex = 0;

                tunels.Items.Clear();


                description.Text = currentLocation.Description;
            }
            else
            {
                mapWaypoints(currentLocation, newLocation);
                currentLocation = newLocation;
                description.Text = currentLocation.Description;
            }
        }

        private void hasExtDoor()
        {
            if (currentLocation is IHasExteriorDoor)
            {
                goThrough.Visibility = Visibility.Visible;
            }
            else
            {
                goThrough.Visibility = Visibility.Hidden;
            }
        }

        private void hasHole()
        {
            if (currentLocation is IHasHole)
            {
                tunelGoTo.Visibility = Visibility.Visible;
                tunels.Visibility = Visibility.Visible;
                for (int i = 0; i < currentLocation.Tunels.Length; i++)
                {
                    tunels.Items.Add(currentLocation.Tunels[i].Name);
                }
                tunels.SelectedIndex = 0;
            }
            else
            {
                tunels.Visibility = Visibility.Hidden;
                tunelGoTo.Visibility = Visibility.Hidden;
            }
        }

        private void hasHidingSpot()
        {
            if(currentLocation is IHasHidingSpot)
            {
                hide.Visibility = Visibility.Visible;
                unhide.Visibility = Visibility.Hidden;
            }
            else
            {
                hide.Visibility = Visibility.Hidden;
                unhide.Visibility = Visibility.Hidden;
            }
        }

        private void HideClick(object sender, RoutedEventArgs e)
        {

            if (currentLocation is IHasHidingSpot)
            {
                if (currentLocation is RoomWithHidingSpot)
                {
                    RoomWithHidingSpot temp = currentLocation as RoomWithHidingSpot;
                    temp = (RoomWithHidingSpot)currentLocation;
                    MoveToANewLocation(temp.HidingLocation);
                }
                if (currentLocation is OutsideWithHidingSpot)
                {
                    OutsideWithHidingSpot temp = currentLocation as OutsideWithHidingSpot;
                    temp = (OutsideWithHidingSpot)currentLocation;
                    MoveToANewLocation(temp.HidingLocation);
                }
            }
            hide.Visibility = Visibility.Hidden;
            unhide.Visibility = Visibility.Visible;
        }

        private void UnhideClick(object sender, RoutedEventArgs e)
        {
            if(currentLocation is IHidingSpot)
            {
                HidingSpot temp = currentLocation as HidingSpot;
                temp = (HidingSpot)currentLocation;
                MoveToANewLocation(temp.GetOut);
            }
            hide.Visibility = Visibility.Visible;
            unhide.Visibility = Visibility.Hidden;
        }

        private void Door2Click(object sender, RoutedEventArgs e)
        {
            MultiDoorHandler(1);
        }

        private void Door1Click(object sender, RoutedEventArgs e)
        {
            MultiDoorHandler(0);
        }

        private void MultiDoorHandler(int i)
        {
            OutsideWithTwoDoors temp = currentLocation as OutsideWithTwoDoors;
            temp = (OutsideWithTwoDoors)currentLocation;
            MoveToANewLocation(temp.DoorLocation[i]);
            DoorBtn1.Visibility = Visibility.Hidden;
            DoorBtn2.Visibility = Visibility.Hidden;
        }
    }
}
