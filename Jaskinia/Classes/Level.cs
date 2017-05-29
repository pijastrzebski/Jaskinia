using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaskinia
{
    static class Level
    {
        private static Room[,] rooms;

        #region properties

        public static Room[,] Rooms
        {
            get { return rooms; }
        }

        #endregion

        public static void Initialise()
        {
            BuildLevel();
        }

        public static void BuildLevel()  //tu definiuj level + rozmiar
        {
            rooms = new Room[5,6];

            Room room;
            Item item;
            //Mob mob;
           
            
            /////////////////////////////////////////////////////////////////
            // stworz WEJSCIE DO JASKINI 
            room = new Room();

            // przypisz to pomieszczenie do lokacji 0, 0
            rooms[0, 0] = room;
           

            // ustawienia pomieszczen
            room.Title = "WEJSCIE DO JASKINI";
            room.Description = "Stoisz przed wejsciem do jaskini. Dostrzegasz plonaca pochodnie.";
            room.AddExit(Direction.East);

            // stworz nowy przedmiot
            item = new Item();

            //wlasciwosci przedmiotu
            item.Title = "Pochodnia";
            item.PickupText = "Zabrales pochodnie. Pochodnia dodaje Ci +1 do Punktów Mocy.\n ";
            item.Weight = 1;
            item.Moc = 1;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz KOMNATA MROKU
            room = new Room();

            // przypisz to pomieszczenie do lokacji 0,1
            rooms[1,0] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA MROKU";

            room.Description = TextUtils.WordWrap("Wlasnie wszedles do komnaty mroku. Stawiasz ostroznie krok, po czym nastepny gdy nagle...slyszysz osuwajace sie glazy. Cale pomieszczenie sie trzesie. Ledwo mozesz zlapac oddech. O nie! To wejscie do jaskini! Ono...zostalo zasypane. Mogles wcale tu nie wchodzic! Co Ci przyszlo do glowy, by tu sie znalezc?! Teraz to juz niewazne. Gdy jedne drzwi sie zamykaja, inne pozostaja otwarte - myslisz sobie, poki co, jeszcze pelen nadziei. Teraz rozpoczynasz swa nowa wedrowke, wedrowke by przezyc i znalezc wyjscie. ", Console.WindowWidth);
            //room.AddExit(Direction.West);                 // wejscie do jaskini zasypane
            room.AddExit(Direction.East);

            // stworz nowy przedmiot
            item = new Item();

            //wlasciwosci przedmiotu
            item.Title = "Kamien";
            item.PickupText = "Podniosles kamien.";
            item.Weight = 2;
            item.Moc = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz nowe pomieszczenie
            room = new Room();
            
            rooms[2, 0] = room;

            // ustawienia pomieszczen
            room.Title = "CIEMNY KORYTARZ";
            room.Description = "Znalazles sie w korytarzu. Czujesz sie zaniepokojony.";
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);
                       

            // stworz KRYSZTAŁOWE PRZEJSCIE 
            room = new Room();

            // przypisz to pomieszczenie do lokacji 0, 0
            rooms[3,0] = room;

            // ustawienia pomieszczen
            room.Title = "KRYSZTAŁOWE PRZEJSCIE";
            room.Description = "Znalazles sie w krysztalowym przejsciu. Follow the white rabbit Neo...";
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);

            // stworz nowy przedmiot
            item = new Item();
            

            //wlasciwosci przedmiotu
            item.Title = "Krysztal gorski";
            item.PickupText = "Zabrales krysztal do kieszeni. Masz przeczucie, ze nie jest to zwykly kawalek kwarcu. ";
            item.Weight = 0;

            room.Items.Add(item);

            item = new Item();

            item.Title = "Ametyst";
            item.PickupText = "Zabrales ametyst do kieszeni. ";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz nowe pomieszczenie
            room = new Room();

            // przypisz to pomieszczenie do lokacji 0, 0
            rooms[4, 0] = room;

            // ustawienia pomieszczen
            room.Title = "SCIANA PLACZU";
            room.Description = "Stanales i przez chwile sie rozgladasz. Nie ma tu przejscia. Zawroc.";
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();

            //wlasciwosci przedmiotu
            item.Title = "Butelka";
            item.PickupText = "Podniosles butelke.";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            item = new Item();

            //wlasciwosci przedmiotu
            item.Title = "Sztylet";
            item.PickupText = "Podniosles zniszczony sztylet. Musisz go naprawic.";
            item.Weight = 1;
            item.Moc = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz nowe pomieszczenie
            room = new Room();

            // przypisz to pomieszczenie do lokacji 0, 0
            rooms[0,1] = room;

            // ustawienia pomieszczen
            room.Title = "PRADAWNA KUŹNIA";
            room.Description = TextUtils.WordWrap("Znalazles sie w pradawnej kuzni. Czuc tu jeszcze zapach nie raz przelanego potu i starego dziada. Po srodku znajduje sie wygasle palenisko, a obok zapomniane kowadlo." , Console.WindowWidth);
            room.AddExit(Direction.East);
            room.AddExit(Direction.South);


            // stworz nowy przedmiot
            item = new Item();

            //wlasciwosci przedmiotu
            item.Title = "Kowadlo";         //      uzyj do naprawy przedmiotu
            item.PickupText = "Udalo Ci sie podniesc ciezkie, pradawne kowadlo. Coz za pozytek z kowadla w plecaku?\nLepiej je odloz nim zrobisz sobie krzywde!";
            item.Weight = 6;
            item.Moc = -3;
            room.Items.Add(item);

            item = new Item();
          

            //wlasciwosci przedmiotu
            item.Title = "Mlot";         //      uzyj do naprawy przedmiotu
            item.PickupText = "Udalo Ci sie podniesc ciezki mlot kowala. Mozesz za jego pomoca naprawic zdobyta bron.";
            item.Weight = 2;
            item.Moc = 0;
            room.Items.Add(item);

            
            

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[1, 1] = room;

            // ustawienia pomieszczen
            room.Title = "UKRYTE PRZEJSCIE";
            room.Description = TextUtils.WordWrap("Swiatlo pochodni pozwolilo Ci dostrzec ukryte przejscie. Widzisz czaszke, lezaca obok sterty bialych jak kreda kosci.", Console.WindowWidth); 
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);
            room.AddExit(Direction.South);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "Czaszka";         //atakuje cie szkieletor
            item.PickupText = "Zabrales czaszke do swego ekwipunku. W koncu masz z kim pogadac! ";
            item.Weight = 1;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);


            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[2,1] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA ZLOTEGO CIELCA";
            room.Description = TextUtils.WordWrap("Wchodzisz do majestatycznego pomieszczenia. Ongis ludzie czcili to miejsce. Czuc w nim wielka energie.", Console.WindowWidth);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);
            room.AddExit(Direction.North);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "Zloty Cielec";
            item.PickupText = "Jak dales rades uniesc ta rzecz?";
            item.Weight = 100;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[3,1] = room;

            // ustawienia pomieszczen
            room.Title = "ZGNILY KORYTARZ";
            room.Description = TextUtils.WordWrap("Nie powinienes sie tu znalezc...", Console.WindowWidth);

            room.AddExit(Direction.East);
            room.AddExit(Direction.West);
            room.AddExit(Direction.North);


            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[4,1] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA OCZYSZCZENIA";
            room.Description = "Wchodzisz do Komnaty Oczyszczenia. ";
            room.AddExit(Direction.South);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[0, 2] = room;

            // ustawienia pomieszczen
            room.Title = "KOLO FORTUNY";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[1, 2] = room;

            // ustawienia pomieszczen
            room.Title = "OLTARZ CEREMONIALNY";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[2, 2] = room;

            // ustawienia pomieszczen
            room.Title = "ZWEZENIE KORYTARZA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[3, 2] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA SFINKSA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[4, 2] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA NICOSCI";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[0, 3] = room;

            // ustawienia pomieszczen
            room.Title = "STARA UBOJNIA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[1, 3] = room;

            // ustawienia pomieszczen
            room.Title = "CUDOWNE ZRODLO";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[2, 3] = room;

            // ustawienia pomieszczen
            room.Title = "SIEDLISKO NIETOPERZY";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[3, 3] = room;

            // ustawienia pomieszczen
            room.Title = "RUCHOMA KOMNATA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[4, 3] = room;

            // ustawienia pomieszczen
            room.Title = "POBAZGRANA SCIANA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[0, 4] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA SWIATLA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[1, 4] = room;

            // ustawienia pomieszczen
            room.Title = "NIEBIANSKI KORYTARZ";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[2, 4] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA WODY";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[3, 4] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA BOLU";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[4, 4] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA ZNAKOW";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.South);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[0, 5] = room;

            // ustawienia pomieszczen
            room.Title = "STARA SILOWNIA";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[1, 5] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA NADZIEI";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[2, 5] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA LOSU";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[3, 5] = room;

            // ustawienia pomieszczen
            room.Title = "NEFRYTOWY KORYTARZ";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);
            room.AddExit(Direction.West);

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);

            /////////////////////////////////////////////////////////////////
            // stworz POMIESZCZENIE 
            room = new Room();


            rooms[4, 5] = room;

            // ustawienia pomieszczen
            room.Title = "KOMNATA PRAWDY";
            room.Description = "";
            room.AddExit(Direction.North);
            room.AddExit(Direction.East);
           

            // stworz nowy przedmiot
            item = new Item();
            item.Title = "";
            item.PickupText = "";
            item.Weight = 0;

            //dodaj przedmiot do tego pomieszczenia
            room.Items.Add(item);


            // miejsce, gdzie gracz zaczyna rozgrywke
            Player.PosX = 0;
            Player.PosY = 0;
        }
    }
}
