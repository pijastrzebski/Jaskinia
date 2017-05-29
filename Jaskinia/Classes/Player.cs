using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    static class Player
    {
        private static int posX;
        private static int posY;

        private static List<Item> inventoryItems;
        private static int moves = 0;
        private static int akcja = 0;
        private static int iloscPrzedmiotow = 0;
        private static int weightCapacity = 8;
        private static int punktyPsychiki = 3;
        private static int punktyMocy = 0;
        private static int punktySwiatla = 0;

        #region properties



        public static int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public static int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public static int Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public static int Akcja
        {
            get { return akcja; }
            set { akcja = value; }
        }

        public static int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }
        }

        public static int IloscPrzedmiotow
        {
            get { return iloscPrzedmiotow; }
            set { iloscPrzedmiotow = value; }
        }

        public static int PunktyPsychiki
        {
            get { return punktyPsychiki; }
            set { punktyPsychiki = value; }
        }

        public static int PunktySwiatla
        {
            get { return punktySwiatla; }
            set { punktySwiatla = value; }
        }

        public static int PunktyMocy
        {
            get
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Moc;
                }

                return result;
            }
        }

        public static int InventoryWeight
        {
            get
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }

                return result;
            }
        }



        #endregion

        static Player()
        {
            inventoryItems = new List<Item>();
            
        }

        #region public methods
        public static void Move(string direction)
        {
            
            Room room = Player.GetCurrentRoom();

            if (!room.CanExit (direction))
            {
                TextBuffer.Add("Nie mozna tedy przejsc.");
                return;
            }
            
            Player.moves++;

            switch (direction)
            {
                case Direction.North: // przed siebie
                    posY--;
                    break;
                case Direction.South: // cofnij
                    posY++;
                    break;
                case Direction.East: // dol
                    posX++;
                    break;
                case Direction.West: // gora
                    posX--;
                    break;
            }

            Player.GetCurrentRoom().Describe();

        }


        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);
            

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.weightCapacity)
                {
                    TextBuffer.Add("Twoj ekwipunek jest pelen!\nWyrzuc cos, by wziac kolejny przedmiot.");

                    return;
                }

                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Pickup.mp3";
                wplayer.controls.play();

                room.Items.Remove(item);
                Player.inventoryItems.Add(item);
                Player.punktyMocy += item.Moc;
                TextBuffer.Add(item.PickupText);
                Player.iloscPrzedmiotow++;
                

            }
            else
                TextBuffer.Add("Nie ma " + itemName + " w tym pomieszczeniu");

            Console.Clear();
            Player.GetCurrentRoom().Describe();
            Player.GetCurrentRoom().ShowTitle();
        }

        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item != null)
            {
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Emptying.mp3";
                wplayer.controls.play();

                Player.inventoryItems.Remove(item);
                room.Items.Add(item);
                TextBuffer.Add("Przedmiot " + itemName + " zostal usuniety z twego ekwipunku.");
                Player.iloscPrzedmiotow--;
            }
            else
                TextBuffer.Add("Nie ma " + itemName + " w twoim ekwipunku.");
            Console.Clear();
            Player.GetCurrentRoom().Describe();
            Player.GetCurrentRoom().ShowTitle();
        }

        public static void DisplayInventory()
        {
            string message = "Zawartosc Twego ekwipunku: ";
            string items = "";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "] Waga: " + item.Weight.ToString();
                }
            }
            else
                items = "\n<brak przedmiotow";

            items += "\n\nWaga calkowita: " + Player.InventoryWeight + " / " + Player.WeightCapacity;

            TextBuffer.Add(message + "\n" + underline + items);
        }

        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }

        public static Item GetInventoryItem(string itemName)
        {
            foreach (Item item in inventoryItems)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }

            return null;
        }
        #endregion
    }
}
