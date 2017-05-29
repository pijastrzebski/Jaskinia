using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    class Mob       // poki co, nie dziala
    {
       
        private string title;
        private string pickupText;
        private int weight = 1;
        private int moc = 1;

        #region properties

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string PickupText
        {
            get { return pickupText; }
            set { pickupText = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int Moc
        {
            get { return moc; }
            set { moc = value; }
        }

        #endregion
    }
}
