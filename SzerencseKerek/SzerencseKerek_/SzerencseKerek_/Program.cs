using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SzerencseKerek_
{
    class Jatek
    {
        private static Random rnd;

        private int forduloSzama;
        private int[] jatekosok;
        private string Kozmondas_;
        private string RejtettKozmondas_;

        public void JatekMenet()
        {
            Console.Clear();
            ConsoleParancsok.AlapInfok();


            string tippelhetoek = "QWRTZPSDFGHJKLYXCVBNM";
            string ezekvoltakMar = "";
            forduloSzama = 0;
            jatekosok = new int[3];
            jatekosok[0] = 0;
            jatekosok[1] = 0;
            jatekosok[2] = 0;
            Kozmondas_ = SzovegesFajtKezel.VeletlenKozmondastAd();
            Kozmondas_ = Kozmondas_.ToUpper();
            Rejtett(ref RejtettKozmondas_);
            ConsoleParancsok.AlapAllasKiir(jatekosok, RejtettKozmondas_);

            bool nyertel = false;
            int gyoztesIndex = 0;
            do
            {
                string tippeltBetu = "";
                int index = 0;


                if (nyertel == false && index == 0)
                {
                    bool ertekEgy = false;
                    bool ertekKetto = true;
                    
                    Console.SetCursorPosition(13, 0);
                    string tippKetto = Console.ReadKey().KeyChar.ToString();
                    if (tippKetto == "0")
                    {
                        bool tutiTuppreHajt = Osszehasonlit(index);
                        if (tutiTuppreHajt == true)
                        {
                            nyertel = true;
                            gyoztesIndex = index;

                        }
                       
                    }
                    else
                    {
                        while (ertekEgy != true || ertekKetto != false)
                        {
                            tippeltBetu = ConsoleParancsok.AktualJatekosonAsor(index, RejtettKozmondas_);
                            ertekEgy = CsekkHogyAzokKozottVanEAmikTippelhetoek(tippeltBetu, tippelhetoek);
                            ertekKetto = CsekkHogyTippeltekeMarEztEzelott(tippeltBetu, ezekvoltakMar);
                        }
                        bool eredmeny = SzerepelEAkozmondasban(tippeltBetu, ref RejtettKozmondas_);
                        if (eredmeny == true)
                        {
                            int talalatok = TalatatokSzama(tippeltBetu);
                            KiporgetettErtek(index, ref jatekosok, talalatok);

                        }
                        ezekvoltakMar += tippeltBetu;
                    }



                    ConsoleParancsok.Korvege(index, RejtettKozmondas_);
                    index++;
                }
                if (nyertel == false && index == 1)
                {

                    bool ertekEgy = false;
                    bool ertekKetto = true;

                    Console.SetCursorPosition(13, 5);
                    string tippKetto = Console.ReadKey().KeyChar.ToString();
                    if (tippKetto == "0")
                    {
                        bool tutiTuppreHajt = Osszehasonlit(index);
                        if (tutiTuppreHajt == true)
                        {
                            nyertel = true;
                            gyoztesIndex = index;

                        }

                    }
                    else
                    {
                        while (ertekEgy != true || ertekKetto != false)
                        {
                            tippeltBetu = ConsoleParancsok.AktualJatekosonAsor(index, RejtettKozmondas_);
                            ertekEgy = CsekkHogyAzokKozottVanEAmikTippelhetoek(tippeltBetu, tippelhetoek);
                            ertekKetto = CsekkHogyTippeltekeMarEztEzelott(tippeltBetu, ezekvoltakMar);
                        }
                        bool eredmeny = SzerepelEAkozmondasban(tippeltBetu, ref RejtettKozmondas_);
                        if (eredmeny == true)
                        {
                            int talalatok = TalatatokSzama(tippeltBetu);
                            KiporgetettErtek(index, ref jatekosok, talalatok);

                        }
                        ezekvoltakMar += tippeltBetu;
                    }



                    ConsoleParancsok.Korvege(index, RejtettKozmondas_);
                    index++;

                }
                if (nyertel == false && index == 2)
                {
                    bool ertekEgy = false;
                    bool ertekKetto = true;

                    Console.SetCursorPosition(13, 10);
                    string tippKetto = Console.ReadKey().KeyChar.ToString();
                    if (tippKetto == "0")
                    {
                        bool tutiTuppreHajt = Osszehasonlit(index);
                        if (tutiTuppreHajt == true)
                        {
                            nyertel = true;
                            gyoztesIndex = index;

                        }

                    }
                    else
                    {
                        while (ertekEgy != true || ertekKetto != false)
                        {
                            tippeltBetu = ConsoleParancsok.AktualJatekosonAsor(index, RejtettKozmondas_);
                            ertekEgy = CsekkHogyAzokKozottVanEAmikTippelhetoek(tippeltBetu, tippelhetoek);
                            ertekKetto = CsekkHogyTippeltekeMarEztEzelott(tippeltBetu, ezekvoltakMar);
                        }
                        bool eredmeny = SzerepelEAkozmondasban(tippeltBetu, ref RejtettKozmondas_);
                        if (eredmeny == true)
                        {
                            int talalatok = TalatatokSzama(tippeltBetu);
                            KiporgetettErtek(index, ref jatekosok, talalatok);

                        }
                        ezekvoltakMar += tippeltBetu;
                    }



                    ConsoleParancsok.Korvege(index, RejtettKozmondas_);
                    index++;
                }

                forduloSzama++;
            } while (forduloSzama != 3);



            
            if (nyertel == true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                Console.WriteLine($"{gyoztesIndex+1}. Játékos megnyerte a meccset egy tuti Tippel!");
                Console.WriteLine("A Tuti tipp pedig: " + Kozmondas_);
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                ConsoleParancsok.EredmenyHirdetes(jatekosok);
            }


            Console.WriteLine("Szeretnél-e még játszani? (i/n)");
            string kerdes = Console.ReadKey().KeyChar.ToString();
            kerdes = kerdes.ToUpper();
            if (kerdes == "I")
            {
                Console.Clear();
                Jatek j = new Jatek();
                j.JatekMenet();
            }
            else
            {
                Console.WriteLine("Köszi a játékot, enterrel kiléphetsz.");
                Console.ReadLine();
            }



        }


     


        private void Rejtett(ref string rejtettkozmondas)
        {
            string uj = "";
            for (int i = 0; i < Kozmondas_.Length; i++)
            {
                if (Kozmondas_[i].ToString() == " ")
                {
                    uj += " ";
                }
                else
                {
                    uj += "_";
                }
            }
            rejtettkozmondas = uj;
        }

        private bool CsekkHogyAzokKozottVanEAmikTippelhetoek(string betu, string tippelhetoek)
        {
            if (tippelhetoek.Contains(betu))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CsekkHogyTippeltekeMarEztEzelott(string betu,string eddigiTippek)
        {
            bool vissza = false;
            for (int i = 0; i < eddigiTippek.Length; i++)
            {
                if (betu == eddigiTippek[i].ToString())
                {
                    vissza = true;
                }
            }
            return vissza;
        }
        private bool SzerepelEAkozmondasban(string tipp, ref string RejtettKozmondas_)
        {
            bool vissza = false;
            if (Kozmondas_.Contains(tipp))
            {
                string uj_retjtett = "";
                for (int i = 0; i < Kozmondas_.Length; i++)
                {
                    if (tipp == Kozmondas_[i].ToString())
                    {
                        uj_retjtett += tipp;
                    }
                    else
                    {
                        uj_retjtett += RejtettKozmondas_[i];
                    }
                }
                RejtettKozmondas_ = uj_retjtett;
                vissza = true;
            }


            return vissza;
        }
        private void KiporgetettErtek(int index, ref int[] tomb, int talalatokSzama)
        {
            int[] penz = new int[] {5, 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 2000 };
            rnd = new Random();
            int ertek = penz[rnd.Next(0, penz.Length)];
            
            tomb[index] += (ertek*talalatokSzama);
            ConsoleParancsok.KiporgetettertekKiir(talalatokSzama, ertek, index, tomb);

        }
        private int TalatatokSzama(string betu)
        {
            int db = 0;
            for (int i = 0; i < Kozmondas_.Length; i++)
            {
                if (betu == Kozmondas_[i].ToString())
                {
                    db++;
                }
            }
            return db;
        }


        private bool Osszehasonlit(int index)
        {
            if (index == 0)
            {
                Console.SetCursorPosition(0,2);
                string tutiTipp = Console.ReadLine();
                if (tutiTipp == Kozmondas_)
                {
                    return true;
                }
            }
            else if (index == 1)
            {
                Console.SetCursorPosition(0, 7);
                string tutiTipp = Console.ReadLine();
                if (tutiTipp == Kozmondas_)
                {
                    return true;
                }
            }
            else
            {
                Console.SetCursorPosition(0, 12);
                string tutiTipp = Console.ReadLine();
                if (tutiTipp == Kozmondas_)
                {
                    return true;
                }
            }




            return false;
        }


    }

    static class SzovegesFajtKezel
    {
        private static Random r;

        private static int FajlHossza()
        {
            StreamReader sr = new StreamReader("kozmondasok.txt");
            int j = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                j++;
            }
            sr.Close();
            return j;
        }
        public static string VeletlenKozmondastAd()
        {
            r = new Random();
            int maxHossz = FajlHossza();
            int random = r.Next(1,maxHossz+1);
            StreamReader sr = new StreamReader("kozmondasok.txt");
            int j = 0;
            string kozmondas = "";
            while (j != random)
            {
                string sor = sr.ReadLine();
                kozmondas = sor;
                j++;
            }
            string mondatVegiIrasJel = ",.-?!";
            for (int i = 0; i < mondatVegiIrasJel.Length; i++)
            {
                kozmondas.Replace(mondatVegiIrasJel[0].ToString(), string.Empty);
            }
            return kozmondas;

        }



    }
    static class ConsoleParancsok
    {
        public static void AlapInfok()
        {
            Console.WriteLine("Szia!");
            Console.WriteLine("Üdvözöllek a játékban titeket... \nLejjebb találtok pár hasznos infót, ami megkönnyítheti a dolgotokat a játékmenet megértésében!");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("A játé 3 fordulóból áll.");
            Console.WriteLine("A játékban csak a még korábban nem tippelt mássalhangzókat tippelhetitek meg.");
            Console.WriteLine("Ha a tipp sikeres, akkor a magyar pénzérmék és bankjegyek által random kapott pénzértéket kapod meg, amit beszorzunk az eltalált betüid számával.");
            Console.WriteLine("Egy körben 2-szer kell nyomnod valamit!! Elöször 0/bármi mást kell nyomnod\n" +
                "0 esetén lehetőséged van kitalálni a megoldást!\n" +
                "Egyéb esetén tippelhetsz egy betüt!");
            Console.WriteLine("Sok sikert a játékhoz, remélem élvezhető..");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

        }


        public static void AlapAllasKiir(int[] jatekosok, string ures)
        {
            for (int i = 0; i < jatekosok.Length; i++)
            {
                Console.WriteLine($"{i + 1}. Jétékos? \n");
                Console.WriteLine(ures + "\n \n");
            }


        }
        public static string AktualJatekosonAsor(int index_, string ures)
        {
            char betu;
            //0-4; 5-9; 10-14
            if (index_ == 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{index_ + 1}. Játékos? \n");
                Console.ResetColor();
                Console.WriteLine(ures + "\n \n");
                Console.SetCursorPosition(13, 0);
                betu = Console.ReadKey().KeyChar;
            }
            else if (index_ == 1)
            {
                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{index_ + 1}. Játékos? \n");
                Console.ResetColor();
                Console.WriteLine(ures + "\n \n");
                Console.SetCursorPosition(13, 5);
                betu = Console.ReadKey().KeyChar;
            }
            else
            {
                Console.SetCursorPosition(0, 10);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{index_ + 1}. Játékos? \n");
                Console.ResetColor();
                Console.WriteLine(ures + "\n \n");
                Console.SetCursorPosition(13, 10);
                betu = Console.ReadKey().KeyChar;
            }
            return betu.ToString().ToUpper();
        }
        public static void Korvege(int index_, string ures)
        {
            //0-4; 5-9; 10-14
            if (index_ == 0)
            {
                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"{index_ + 1}. Játékos? \n");

                Console.WriteLine(ures + "\n \n");
            }
            else if (index_ == 1)
            {
                Console.SetCursorPosition(0, 5);

                Console.WriteLine($"{index_ + 1}. Játékos? \n");

                Console.WriteLine(ures + "\n \n");
            }
            else
            {
                Console.SetCursorPosition(0, 10);

                Console.WriteLine($"{index_ + 1}. Játékos? \n");

                Console.WriteLine(ures + "\n \n");
            }
        }

        public static void KiporgetettertekKiir(int talakatok, int ertek, int index, int[] tomb)
        {
            if (index == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"A kipörgetett értéked: {ertek} Ft * {talakatok}       A jelenlegi összértéked: {tomb[index]}");
                Console.ResetColor();
            }
            else if (index == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 8);
                Console.WriteLine($"A kipörgetett értéked: {ertek} Ft * {talakatok}       A jelenlegi összértéked: {tomb[index]}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(0, 13);
                Console.WriteLine($"A kipörgetett értéked: {ertek} Ft * {talakatok}       A jelenlegi összértéked: {tomb[index]}");
                Console.ResetColor();

            }


        }


        public static void EredmenyHirdetes(int[] jatekosok)
        {
            if (jatekosok[0] > jatekosok[1] && jatekosok[0] > jatekosok[2])
            {
                Console.WriteLine($"1. Helyen az Első játékos végzett, {jatekosok[0]} ponttal..");
                if (jatekosok[1] > jatekosok[2])
                {
                    Console.WriteLine($"2. Helyen a Második játékos, {jatekosok[1]} ponttal");
                    Console.WriteLine($"3. Helyen a Harmadik játékos, {jatekosok[2]} ponttal");
                }
                else
                {
                    Console.WriteLine($"2. Helyen a Harmadik játékos, {jatekosok[1]} ponttal");
                    Console.WriteLine($"3. Helyen a Második játékos, {jatekosok[2]} ponttal");
                }
            }
            if (jatekosok[1] > jatekosok[0] && jatekosok[1] > jatekosok[2])
            {
                Console.WriteLine($"1. Helyen az Második játékos végzett, {jatekosok[1]} ponttal..");
                if (jatekosok[0] > jatekosok[2])
                {
                    Console.WriteLine($"2. Helyen a Első játékos, {jatekosok[0]} ponttal");
                    Console.WriteLine($"3. Helyen a Harmadik játékos, {jatekosok[2]} ponttal");
                }
                else
                {
                    Console.WriteLine($"2. Helyen a Harmadik játékos, {jatekosok[2]} ponttal");
                    Console.WriteLine($"3. Helyen a Első játékos, {jatekosok[0]} ponttal");
                }
            }

            if (jatekosok[2] > jatekosok[0] && jatekosok[2] > jatekosok[1])
            {
                Console.WriteLine($"1. Helyen az Harmadik játékos végzett, {jatekosok[2]} ponttal..");
                if (jatekosok[0] > jatekosok[1])
                {
                    Console.WriteLine($"2. Helyen a Első játékos, {jatekosok[0]} ponttal");
                    Console.WriteLine($"3. Helyen a Második játékos, {jatekosok[1]} ponttal");
                }
                else
                {
                    Console.WriteLine($"2. Helyen a Második játékos, {jatekosok[1]} ponttal");
                    Console.WriteLine($"3. Helyen a Első játékos, {jatekosok[0]} ponttal");
                }
            }

        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Jatek j = new Jatek();
            j.JatekMenet();
        }
    }
  }