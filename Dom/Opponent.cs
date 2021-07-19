using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dom
{
    class Opponent
    {
        Random rand { get; }
        public bool hidden { get; private set; }
        public Location Spot { get; private set; }
        Location currentLocation { get; set; }

        public Opponent(Location startLocation)
        {
            currentLocation = startLocation;
            rand = new Random();
        }

        public void Hide()
        {
            SpotCheck();
            if(!(currentLocation is IHidingSpot))
            Move();
        }

        public void Seek()
        {

        }

        public void Move()
        {
            
            if (currentLocation is IHasExteriorDoor)
            {
                if (rand.Next(2) == 1)
                {
                    IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
                    currentLocation = hasDoor.DoorLocation;
                }
                else
                {
                    int temp = rand.Next(currentLocation.Exits.Length);
                    currentLocation = currentLocation.Exits[temp];
                }
            }
            else if (currentLocation is IHasTwoDoors)
            {
                if (rand.Next(4) == 1)
                {
                    IHasTwoDoors door = currentLocation as IHasTwoDoors;
                    currentLocation = door.DoorLocation[0];
                }
                else if (rand.Next(4) == 2)
                {
                    IHasTwoDoors door = currentLocation as IHasTwoDoors;
                    currentLocation = door.DoorLocation[1];
                }
                else
                {
                    int temp = rand.Next(currentLocation.Exits.Length);
                    currentLocation = currentLocation.Exits[temp];
                }
            }
            else
            {
                int temp = rand.Next(currentLocation.Exits.Length);
                currentLocation = currentLocation.Exits[temp];
            }

        }

        private void SpotCheck()
        {
            if (currentLocation is IHasHidingSpot)
            {
                if (rand.Next(2) == 1)
                {
                    IHasHidingSpot spot = currentLocation as IHasHidingSpot;
                    currentLocation = spot.HidingLocation;
                    hidden = true;
                    Spot = currentLocation;
                }
            }
        }
    }
}
