using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{                                                       
    class Moby
    {
        //      ELEMENTY WALKI

        
            static void WygranaWalka()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Wygrana1.mp3";
            wplayer.controls.play();

            Console.WriteLine("Brawo! Udalo Ci sie pokonac wroga. Zdobywasz 1 Punkt Psychiki.");
            Player.PunktyPsychiki++;

            Console.ReadKey();
            Console.Clear();
        }

        static void Remis()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Wygrana.mp3";
            wplayer.controls.play();

            Console.WriteLine("Remis! Nie tracisz Punktu Psychiki.");

            Console.ReadKey();
            Console.Clear();
        }
            static void PrzegranaWalka()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Porazka.mp3";
            wplayer.controls.play();

            Console.WriteLine("Zostales pokonany przez wroga. Tracisz 1 Punkt Psychiki.");
            Console.ReadKey();
            GameManager.Przegrana("");

            Console.WriteLine("Budzisz sie w nieznanym miejsciu...\n\n");
            Console.WriteLine("Nacisnij dowolny klawisz.");
            Console.ReadKey();
            Console.Clear();
        }

        //      MOBY

        public static void Zjawa()
        {
            Console.ReadKey();
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            switch (wynik)          // losuje czy napotka zjawe
            {
                case 1:
                case 2:
                case 3:
                    int mocPotwora = 3;
                    //Console.WriteLine("\nINSTRUKCJA: Przed Toba Twoja pierwsza walka\nO wyniku zadecyduje rzut koscia.\nJezeli wynik bedzie wiekszy od mocy przeciwnika, wygrywasz.\n W przeciwnym razie tracisz Punkt Psychiki i zostajesz przeniesiony w losowe miejsce.");
                    Console.WriteLine("Zaatakowala Cie: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zjawa (Moc 3)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
                    Console.ReadKey();
                    wynik = CommandProcessor.RzutKostka();
                    Console.Write(wynik + "\n");

                    if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();
                    else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
                    else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();
                    
                    break;
                default:
                    Console.WriteLine("Nic sie nie dzieje\n\n");
                    Console.WriteLine("Nacisnij dowolny klawisz.");
                    break;
                    
            }

         
        }

        public static void ZombieBobr()
        {
            int mocPotwora = 4;     //      atrybuty moba
            Console.ReadKey();      //      ryzyko, ze mob zaatakuje
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            Console.WriteLine("Zaatakowal Cie: ");      //      walka
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ZombieBobr (Moc " + mocPotwora + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
            Console.ReadKey();
            wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");

            if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();     //      rezultat walki
            else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
            else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();
            
        }


        public static void Goblin()
        {

            int mocPotwora = 3;     //      atrybuty moba
            Console.ReadKey();      //      ryzyko, ze mob zaatakuje
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            Console.WriteLine("Zaatakowal Cie: ");      //      walka
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Goblin (Moc " + mocPotwora + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
            Console.ReadKey();
            wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");

            if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();     //      rezultat walki
            else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
            else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();

        }


        public static void Szkieletor()
        {

            int mocPotwora = 2;     //      atrybuty moba
            Console.ReadKey();      //      ryzyko, ze mob zaatakuje
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            Console.WriteLine("Zaatakowal Cie: ");      //      walka
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Szkieletor (Moc " + mocPotwora + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
            Console.ReadKey();
            wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");

            if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();     //      rezultat walki
            else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
            else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();
        }

        public static void RekinWenecji()
        {

            int mocPotwora = 5;     //      atrybuty moba
            Console.ReadKey();      //      ryzyko, ze mob zaatakuje
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            Console.WriteLine("Zaatakowal Cie: ");      //      walka
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rekin Wenecji (Moc " + mocPotwora + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
            Console.ReadKey();
            wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");

            if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();     //      rezultat walki
            else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
            else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();
        }

        public static void Upior()
        {

            int mocPotwora = 6;     //      atrybuty moba
            Console.ReadKey();      //      ryzyko, ze mob zaatakuje
            int wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");
            Console.WriteLine("Zaatakowal Cie: ");      //      walka
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Upior (Moc " + mocPotwora + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
            Console.ReadKey();
            wynik = CommandProcessor.RzutKostka();
            Console.Write(wynik + "\n");

            if (wynik + Player.PunktyMocy > mocPotwora) WygranaWalka();     //      rezultat walki
            else if (wynik + Player.PunktyMocy == mocPotwora) Remis();
            else if (wynik + Player.PunktyMocy < mocPotwora) PrzegranaWalka();
        }
        }
}


