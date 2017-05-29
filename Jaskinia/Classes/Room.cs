using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    class Room
    {

        private string title;
        private string description;
        private bool isThisWorld = false;

        private List<string> exits;
        private List<Item> items;
        private List<Mob> mobs;

        #region propertiesHUD

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsThisWorld
        {
            get { return isThisWorld; }
            set { isThisWorld = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public List<Mob> Mobs
        {
            get { return mobs; }
            set { mobs = value; }
        }

        #endregion

        public Room()
        {
            exits = new List<string>();
            items = new List<Item>();
            mobs = new List<Mob>();
        }

        // Public Methods

        public void Describe()
        {
            // HUD !!
            Console.Clear();
            //TextBuffer.Add("-----------------------------------------------------------------------------");
            TextBuffer.Add("| " + "[X,Y] = " + this.GetCoordinates() + " | " + "Waga ekwipunku: " + Player.InventoryWeight + "/" + Player.WeightCapacity + " | " + "Przedmioty = " + Player.IloscPrzedmiotow+ " | " + "PP " + Player.PunktyPsychiki + " | " + "PM " + Player.PunktyMocy + " | \n"+ "| " + "PS " + Player.PunktySwiatla + " | ");
            //TextBuffer.Add("-----------------------------------------------------------------------------\n");
            TextBuffer.Add(this.title + "\n");
            TextBuffer.Add("Opis miejsca: " + this.description);
            TextBuffer.Add(this.GetItemList());
            TextBuffer.Add(GetExitList());
            //TextBuffer.Add(Zdarzenie());
        }

        public void ShowTitle()
        {
            TextBuffer.Add(this.title);
        }

        public Item GetItem(string itemName)
        {
            foreach (Item item in this.items)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            return null;
        }

        public void AddExit(string direction)
        {
            if (this.exits.IndexOf(direction) == -1)
                this.exits.Add(direction);
        }

        public void RemoveExit(string direction)
        {
            if (this.exits.IndexOf(direction) != -1)
                this.exits.Remove(direction);
        }

        public bool CanExit(string direction)
        {
            foreach (string validExit in this.exits)
            {
                if (direction == validExit)
                    return true;
            }
            return false;
        }



        #region private methods

        private string GetItemList()
        {
            string itemString = "";
            string message = "Rzeczy w pomieszczeniu:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.items.Count > 0)
            {
                foreach (Item item in this.items)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
            {
                itemString = "\n<brak>";
            }

            return "\n" + message + "\n" + underline + itemString;
        }

        private string GetExitList()
        {
            string exitString = "";
            string message = "Mozliwe kierunki:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection + "]";
                }
            }
            else
            {
                exitString = "\n<brak>";
            }

            return "\n" + message + "\n" + underline + exitString;

        }

        private string Zdarzenie()
        {
            string exitString = "";
            string message = "Zdarzenie:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            return "\n" + message + "\n" + underline + exitString;
        }

        // WsPOLRZEDNE

        private string GetCoordinates()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                        return "[" + x.ToString() + "," + y.ToString() + "]";
                }

            }
            return "Nie ma takiego pomieszczenia !";
        }
        #endregion
    }


}