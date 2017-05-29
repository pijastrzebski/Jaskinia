using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;




namespace Jaskinia
{
    static class CommandProcessor
    {
        public static void ProcessCommand(string line)
        {

            string command = TextUtils.ExtractCommand(line.Trim().Trim().ToLower());
            string arguments = TextUtils.ExtractArguments(line.Trim().Trim().ToLower());

           
            if (Direction.IsValidDirection(command))
            {

                Player.Move(command);
                Player.Akcja = 0;
            }
            else
            {
                switch (command)
                {
                    case "wyjscie":
                        Program.quit = true;
                        return;
                    case "pomoc":
                        ShowHelp();
                        break;
                    case "ruch":
                        Player.Move(arguments);
                        break;
                   case "akcja":
                        Player.Akcja=0;
                        break;
                    case "wez":
                        Player.PickupItem(arguments);
                        break;
                    case "wyrzuc":
                        Player.DropItem(arguments);
                        break;
                    case "ekwipunek":
                        Player.DisplayInventory();
                        break;
                    case "lokalizacja":
                        Player.GetCurrentRoom().ShowTitle();
                        break;
                    default:
                        TextBuffer.Add("Nie ma takiej komendy..");
                        break;

                }
               

            }
            GameManager.ApplyRules();
            TextBuffer.Display();

            
        }


        public static void ShowHelp()
        {
                       
            TextBuffer.Add("Lista komend + opis: ");
            TextBuffer.Add("============= ");
            TextBuffer.Add("'pomoc' - wyswietla pomoc");
            TextBuffer.Add("'wyjscie' - wyjscie z gry");
            TextBuffer.Add("'gora' 'dol' 'prawo' 'lewo' - mozliwe kierunki poruszania sie po jaskini");
            TextBuffer.Add("'akcja' - akcja w terenie");
            TextBuffer.Add("'wez' + nazwa przedmiotu");
            TextBuffer.Add("'wyrzuc' + nazwa przedmiotu");
            TextBuffer.Add("'ekwipunek' - wyswietla zawartosc Twego ekwipunku");
            //TextBuffer.Add("'lokalizacja' - wyswietla Twoja lokalizacje");

            
        }

        public static int RzutKostka()
        {
            Player.Moves++;
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Dice2.mp3";
            wplayer.controls.play();

            Console.Write("Rzut koscia");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("...");
                Thread.Sleep(500);
            }
               
            Random rnd = new Random((int)DateTime.Now.Ticks);
            return rnd.Next(1, 6);
            

        }
    }
}
