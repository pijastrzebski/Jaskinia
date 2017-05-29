using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Jaskinia
{
    static class GameManager
    {
        
        public static void ShowTitleScreen()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Intro.mp3";
            wplayer.controls.play();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextUtils.WordWrap("/// Witaj w grze Jaskinia! /// Copyright © 2016 Piotr Jastrzebski. All rights reserved. \n\n\nBudzisz sie w nieznanym Ci miejscu. Nic nie pamietasz. Nie mozesz przypomniec sobie nawet wlasnego imienia! Czujesz jak rosnie w Tobie niepokoj... Otwierasz i przecierasz oczy. Widzisz dziwny, nienaturalny i kamienny twor. Wygladem przypomina...jaskinie. Przygladasz sie dalej. Dostrzegasz wejscie, a obok niego plonaca pochodnie. Zdajesz sobie sprawe, ze ktos juz tu przed Toba byl, a moze jest nadal w srodku. Nie zastanawiajac sie dluzej, wstajesz i podazasz w strone jaskini.." , Console.WindowWidth));
            Console.WriteLine(TextUtils.WordWrap("INSTRUKCJA: Twoim zadaniem jest przede wszystkim... przezycie! Poruszaj sie, zwiedzaj pomieszczenia, zdobywaj cenne przedmioty i pokonuj wszelkie przeciwienstwa losu. W celu uzyskania dodatkowych informacji, wpisz 'pomoc'.", Console.WindowWidth));
            Console.WriteLine("\nWcisnij dowolny klawisz, by rozpoczac rozgrywke!");

            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();

            wplayer.controls.stop();
        }

        public static void StartGame()
        {
            //Console.Clear();
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }

        public static void EndGame(string endingText)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Smierc.mp3";
            wplayer.controls.play();

            Program.quit = true;

            Console.Clear();

            Console.WriteLine(TextUtils.WordWrap(endingText, Console.WindowWidth));
            Console.WriteLine("\nKONIEC GRY\n\n\nMozesz teraz zamknac okno.");
            Console.CursorVisible = false;

            while (true)
                Console.ReadKey(true);
        }

        public static void Przegrana(string tekstPrzegrana)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Porazka2.mp3";
            wplayer.controls.play();

            Player.PunktyPsychiki--;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            Player.PosX = rnd.Next(0, 4);
            Player.PosY = rnd.Next(0, 5);
            //Console.WriteLine("Budzisz sie w nieznanym miejsciu...");

            Player.GetCurrentRoom().Describe();

            //Console.ReadKey();
            //Console.Clear();
        }

        private static int Losuj()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            return rnd.Next(1, 6);
        }
        public static void GeneratorMobow()
        {
            Player.Akcja++;
            int losoweZdarzenie = Losuj();
            switch (losoweZdarzenie)
            {
                case 1:
                    Moby.Zjawa();
                    break;
                case 2:
                    Moby.Szkieletor();
                    break;
                case 3:
                    Moby.ZombieBobr();
                    break;
                case 4:
                    Moby.RekinWenecji();
                    break;
                case 5:
                    Moby.Goblin();
                    break;
                default:
                    Console.Write("Generator mobow nie zadzialal.");
                    break;
            }
        }

        public static void ApplyRules()
        {

            // Happy End
            if (Player.PunktySwiatla>=100)
            {
                  EndGame("\n\n\nGratulacje! Udalo Ci sie zdobyc 100 Punktow Swiatla!\nBudzisz sie. To byl tylko koszmar. ");
            }
            // if ( odgadniesz haslo w Kamienne Drzwi )
            // {
            //    EndGame("\n\n\nGratulacje! Budzisz sie. To byl tylko koszmar. Wygrales!!");
            // }

            // Ukryte przejscie
            if (Player.GetInventoryItem("Pochodnia") != null)
            {
                
                Level.Rooms[1, 0].AddExit(Direction.South);
                Level.Rooms[1, 0].Description = "Udalo Ci sie odkryc ukryte przejscie! Mozesz przemiescic sie teraz w prawo!";
            }

            // korytarz
            if ((Player.PosX == 2) && (Player.PosY == 0) && (Player.Akcja == 0))
            {

                //ZDARZENIE
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie\nNacisnij dowolny klawisz");
                Console.WriteLine(TextUtils.WordWrap("\n\nINSTRUKCJA: Aby stoczyc walke z napotkanym przeciwnikiem - rzuc koscia. Jesli wyrzucisz wiecej oczek niz moc przeciwnika - wygrywasz. W przeciwnym razie zostajesz pokonany, tracisz Punkt Psychiki i przenosisz sie w losowe miejsce Jaskini.", Console.WindowWidth));
                GeneratorMobow();

            }

            // krysztalowe przejscie
            if ((Player.PosX == 3) && (Player.PosY == 0) && (Player.Akcja == 0))
            {

                //ZDARZENIE
                Player.Akcja++;
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie.\nNacisnij dowolny klawisz");
                Console.ReadKey();
                int wynik = CommandProcessor.RzutKostka();
                switch (wynik)
                {
                    case 1:
                    case 2:
                        Console.WriteLine(TextUtils.WordWrap("Spadl na Ciebie ostry kawalek krysztalu, wbijajac sie gleboko w cialo. Tracisz 1 Punkt Psychiki.", Console.WindowWidth));
                        Player.PunktyPsychiki--;
                        break;
                    case 3:
                    case 4:
                        Console.WriteLine("Przebywanie w tym miejscu oswieca Twoj umysl. Zyskujesz 1 Punkt Swiatla.");
                        Player.PunktySwiatla++;
                        break;
                    default:
                        Console.WriteLine("/nNic sie nie dzieje.");
                        break;

                }
                Console.WriteLine("Nacisnij dowolny klawisz.");
                Console.ReadKey();
                Console.Clear();


            }

            // sciana placzu
            if ((Player.PosX == 4) && (Player.PosY == 0) && (Player.Akcja == 0))
            {

                //ZDARZENIE
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie.\nNacisnij dowolny klawisz");
                Console.ReadKey();
                int wynik = CommandProcessor.RzutKostka();
                switch (wynik)
                {
                    case 1:
                    case 2:
                        Console.WriteLine(TextUtils.WordWrap("Nastroj tego miejsca jest przerazliwy...niemozliwy do opisania. Czujesz sie coraz gorzej. Zaczynasz tracic nadzieje, ze uda ci sie calo opuscic to miejsce. Tracisz 1 Punkt Psychiki.", Console.WindowWidth));
                        Player.PunktyPsychiki--;
                        break;
                    case 3:
                    case 4:
                        Console.WriteLine("Cisze przerywa odglos zza plecow. Ktos lub cos sie zbliza...");
                        Moby.Upior();

                        break;
                    default:
                        Console.WriteLine("/nNic sie nie dzieje.");
                        break;

                }
                Console.WriteLine("Nacisnij dowolny klawisz.");
                Console.ReadKey();
                Console.Clear();


            }
            //      kuznia   -- po naprawie zniszcz stary sztylet z ekwipunku!
            if ((Player.PosX == 0) && (Player.PosY == 1) && (Player.GetInventoryItem("Mlot") != null) && (Player.GetInventoryItem("Sztylet") != null) && (Player.GetInventoryItem("Sztylet Zabojcy") == null) && (Player.Akcja == 0))
            { 
                Item item;
                item = new Item();
                item.Title = "Sztylet Zabojcy";
                item.PickupText = "Udalo Ci sie naprawic sztylet. Teraz to swietna bron. Dodaje Ci +1 Punktu Mocy.";
                item.Weight = 1;
                item.Moc = 1;

                Level.Rooms[0, 1].Items.Add(item);

                Console.Clear();
                Player.GetCurrentRoom().Describe();
                Player.GetCurrentRoom().ShowTitle();

               // Player.DropItem("Sztylet");
               // Level.Rooms[0, 1].Items.Remove("Sztylet");
                Console.WriteLine("Brawo! Udalo Ci sie naprawic sztylet!");
            }
                // ukryte przejscie

                if ((Player.PosX == 1) && (Player.PosY == 1) && (Player.GetInventoryItem("Czaszka") != null)&& (Player.Akcja == 0))
                {
                    Player.Akcja++;
                    Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie\nNacisnij dowolny klawisz");
                    Console.WriteLine(TextUtils.WordWrap("\n\nZabierajac czaszke, nie pomyslales, ze moze byc jeszcze komus potrzebna...", Console.WindowWidth));

                    Console.ReadKey();
                    int wynik = CommandProcessor.RzutKostka();
                    Console.Write(wynik + "\n");
                    int mocPotwora = 5;
                    Console.WriteLine("Zaatakowal Cie: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Szkieletor bez glowy (Moc 5)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Rzuc koscia, by zobaczyc, co sie stanie. Nacisnij dowolny klawisz");
                    Console.ReadKey();
                    wynik = CommandProcessor.RzutKostka();
                    Console.Write(wynik + "\n");
                if (wynik + Player.PunktyMocy > mocPotwora)
                {
                    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Wygrana1.mp3";
                    wplayer.controls.play();

                    Console.WriteLine("Brawo! Udalo Ci sie pokonac wroga. Zdobywasz 1 Punkt Psychiki.");
                    Player.PunktyPsychiki++;

                }

                else if (wynik + Player.PunktyMocy == mocPotwora)
                {
                    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    wplayer.URL = @"C:\Users\Piotr\Documents\visual studio 2015\Projects\Jaskinia\Jaskinia\bin\Wygrana.mp3";
                    wplayer.controls.play();

                    Console.WriteLine("Remis! Nie tracisz Punktu Psychiki.");
                }

                else if (wynik + Player.PunktyMocy < mocPotwora)
                {
                    Console.WriteLine("Zostales pokonany przez wroga. Tracisz 1 Punkt Psychiki.");
                    Console.ReadKey();
                    GameManager.Przegrana("");

                }

                    Console.WriteLine("Nacisnij dowolny klawisz.");
                    Console.ReadKey();
                    Console.Clear();
                    
                
            }

            // zloty cielec
            if ((Player.PosX == 2) && (Player.PosY == 1) && (Player.Akcja == 0))
            {

                //ZDARZENIE
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie.\nNacisnij dowolny klawisz");
                Console.ReadKey();
                int wynik = CommandProcessor.RzutKostka();
                switch (wynik)
                {
                    case 1:
                    case 2:
                        Console.WriteLine(TextUtils.WordWrap("Wpatrujesz sie w posag zlotego cielca, przy okazji tracac wszelkie zmysly... Tracisz 1 Punkt Psychiki.", Console.WindowWidth));
                        Player.PunktyPsychiki--;
                        break;
                    case 3:
                    case 4:
                        Console.WriteLine("Zloty cielec zadaje Ci zagadke: \nJak nazywa się piękna kobieta w Niemczech?\n Twoja odpowiedz: ");
                        string odp1 = Console.ReadLine();
                        if ((odp1=="turystka")|| (odp1 == "Turystka"))
                        {
                            Console.WriteLine("Dobra odpowiedz! Zdobywasz 1 Punkt Swiatla.");
                            Player.PunktySwiatla++;
                        }
                        else
                        {
                            Console.WriteLine("Zla odpowiedz. Zloty cielec nie jest zadowolony.\nTracisz 1 Punkt Psychiki.");
                            Player.PunktyPsychiki--;
                        }
                        
                        break;
                    default:
                        Console.WriteLine("/nNic sie nie dzieje.");
                        break;

                }
                Console.WriteLine("Nacisnij dowolny klawisz.");
                Console.ReadKey();
                Console.Clear();
                Player.GetCurrentRoom().Describe();
                Player.GetCurrentRoom().ShowTitle();


            }

            // korytarz
            if ((Player.PosX == 3) && (Player.PosY == 1) && (Player.Akcja ==0))
            {
                //ZDARZENIE
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie\nNacisnij dowolny klawisz");
                CommandProcessor.RzutKostka();
                GeneratorMobow();
                
            }
            
            

            // komnata oczyszczenia
            if ((Player.PosX == 4) && (Player.PosY == 1) && (Player.Akcja ==0))
            {
                //ZDARZENIE
                
                Console.WriteLine("ZDARZENIE!\n\nRzuc koscia, by zobaczyc, co sie stanie.\nNacisnij dowolny klawisz");
                Console.ReadKey();
                int wynik = CommandProcessor.RzutKostka();
                switch (wynik)
                {
                    case 1:
                    case 2:
                        Console.WriteLine("Czujesz sie oczyszczony. Twoja liczba Punktow Psychiki przyjmuje poczatkowa wartosc.");
                        Player.PunktyPsychiki = 3;
                        break;
                    case 3:
                        Console.WriteLine("Czujesz sie oczyszczony. Zdobywasz 1 Punkt Psychiki.");
                        Player.PunktyPsychiki++;
                        break;
                    default:
                        Console.WriteLine("/nNic sie nie dzieje.");
                        //Console.WriteLine("Nacisnij dowolny klawisz.");
                        break;

                }
                Console.WriteLine("Nacisnij dowolny klawisz.");
                Console.ReadKey();
                Console.Clear();
            
        }

            // GAME OVER
            if (Player.Moves > 69)
                {
                    EndGame("Tak dlugo bladziles po jaskini, az wyczul i wytropil Cie \npodly, nikczemny troll. Jest tak potezny, (a przy okazji zielony i brzydki), ze powala Cie jednym ciosem. TTRRaah \nTwoj los jest beznadziejny, nie ma dla Ciebie ratunku. Umierasz.. ");
                }
            if (Player.PunktyPsychiki<=0)
            {
                EndGame("Straciles wszystkie Punkty Psychiki. Oszalales...\nDo konca swych dni bedziesz blakal sie po jaskini!");
            }
        }
    }
}
