using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jaskinia
{
    class Program
    {
        public static bool quit = false;
        static void Main(string[] args)
        {
            GameManager.ShowTitleScreen();
            Level.Initialise();
            GameManager.StartGame();

            while (!quit)
            {
                CommandProcessor.ProcessCommand(Console.ReadLine());
            }





        }
    }
}
