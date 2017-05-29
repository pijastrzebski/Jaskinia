using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    public struct Direction
    {
        public const string North = "gora";
        public const string South = "dol";
        public const string East  = "prawo";
        public const string West  = "lewo";

        public static bool IsValidDirection(string direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return true;
                case Direction.South:
                    return true;
                case Direction.East:
                    return true;
                case Direction.West:
                    return true;

            }
            return false;
        }
    }
}
