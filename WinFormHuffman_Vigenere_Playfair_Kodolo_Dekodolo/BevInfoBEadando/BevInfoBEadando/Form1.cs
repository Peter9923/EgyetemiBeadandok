using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BevInfoBEadando
{
    public partial class Form1 : Form
    {
        class Huffman_Kodtabla_Tipus
        {
            public string betu;
            public string kodja;
        }
        Huffman_Kodtabla_Tipus[] _HuffMANkodTabla = null;


        public Form1()
        {
            InitializeComponent();
        }

        //KodoloGombKattintás   A gomb kattintására meghívjuk ezt a függvényt
        private void Kodolo_Button_Click(object sender, EventArgs e)
        {

           
            //ha üres a kodolando tipus, akkor nincsen semmi sem kiválasztva..
            if (KodoltTipus.Text == "")
            {
                MessageBox.Show("Nem jelöltél ki semmilyen kodolo tipust sem!");
            }

            //Viegnére rejtjelező..
            else if (KodoltTipus.Text == "Vigenère-rejtjelező")
            {
                string VignereFeleKodoltUzenet = Vigenere_Kodolo(eztKodolod.Text, Kulcs_Kodolo.Text);
                eztKodoltad.Text = VignereFeleKodoltUzenet;
            }

            //Playfair
            else if (KodoltTipus.Text == "Playfair")
            {
                //Teszt, hogy az angol ABCnek megfelelő betűket használjuk-e!
                bool bemenetiSzovegMegfelel = Csekkolas(eztKodolod.Text);
                bool bemenetiKodMegfelel = Csekkolas(Kulcs_Kodolo.Text);

                if (bemenetiKodMegfelel == true && bemenetiSzovegMegfelel == true)
                {
                    string kodolt_uzenet = PlayFairKodolo(Kulcs_Kodolo.Text, eztKodolod.Text);
                    eztKodoltad.Text = kodolt_uzenet;
                }
                else
                {
                    MessageBox.Show("Hibás bemeneti karakter a szövegben / kódban. Ékezettel, számmal és speciális karakterrel nem kódolhatsz a választott típusban!");
                }
                
            }

            //Huffman
            else if (KodoltTipus.Text == "Huffman")
            {
                _HuffMANkodTabla = HuffmanKodtablaLEtrehozas(eztKodolod.Text);
                string kodolt = HuffmanKodolo(eztKodolod.Text);
                eztKodoltad.Text = kodolt;
            }




        }



        //De_KodoloGombKattintás  A gomb kattintására meghívjuk ezt a függvényt
        private void Dekodolo_button_Click(object sender, EventArgs e)
        {
            //ha üres a dekodolando tipus, akkor nincsen semmi sem kiválasztva..
            if (DeKodoltTipus.Text == "")
            {
                MessageBox.Show("Nem jelöltél ki semmilyen dekodolo tipust sem!");
            }
            //Viegnére rejtjelező dekodolása
            else if (DeKodoltTipus.Text == "Vigenère-rejtjelező")
            {
                string VignereFeleKodoltUzenet = Vignere__Kodolo_Dekodolo(eztDekodolod.Text, Kulcs_DeKodolo.Text);
                eztDekodoltad.Text = VignereFeleKodoltUzenet;

                //string de_kodolt_uzenet = Vigenere_DeKodolo(eztDekodolod.Text, Kulcs_DeKodolo.Text);
                //eztDekodoltad.Text = de_kodolt_uzenet;
            }
            //Playfair
            else if (DeKodoltTipus.Text == "Playfair")
            {
                //Teszt, hogy az angol ABCnek megfelelő betűket használjuk-e!
                bool bemenetiSzovegMegfelel = Csekkolas(eztDekodolod.Text);
                bool bemenetiKodMegfelel = Csekkolas(Kulcs_DeKodolo.Text);

                if (bemenetiKodMegfelel == true && bemenetiSzovegMegfelel == true)
                {
                    string kodolt_uzenet = PlayFairDeKodolo(Kulcs_DeKodolo.Text, eztDekodolod.Text);
                    eztDekodoltad.Text = kodolt_uzenet;
                }
                else
                {
                    MessageBox.Show("Hibás bemeneti karakter a szövegben / kódban. Ékezettel, számmal és speciális karakterrel nem kódolhatsz a választott típusban!");
                }
            }
            else if (DeKodoltTipus.Text == "Huffman")
            {
                string visszafejt = HuffmanDeKodolo(eztDekodolod.Text, _HuffMANkodTabla);
                eztDekodoltad.Text = visszafejt;

            }

        }




        #region Vigenére-rejtjelező

        static string[] VigenereKodtablaLetrehozasa(string kulcs)
        {
            string _abc = "AÁBCDEÉFGHIÍJKLMNOÓÖŐPQRSTUÚÜŰVWXYZ";
            kulcs = kulcs.ToUpper();


            string[] kodTabla = new string[kulcs.Length + 1];
            kodTabla[0] = _abc;


            int _indexKodtabla = 1;
            for (int i = 0; i < kulcs.Length; i++)
            {
                string _akutalisKevertABC = "";
                int index = 0;


                for (int j = 0; j < _abc.Length; j++)
                {
                    //ha a megadott kulcs i-edik eleme, megegyezik az _abc string j-edik elemével, megkeressük, hogy a kulcs aktuális I-je onnan kezdődik az ABC ben, mivel a következő sornak az lesz az eleje.
                    if (kulcs[i] == _abc[j])
                    {
                        index = j;
                    }
                }


                //Az aktuális kod sort előállítjuk 2db for ciklussal.
                for (int k = index; k < _abc.Length; k++)
                {
                    _akutalisKevertABC += _abc[k];
                }
                for (int k = 0; k < index; k++)
                {
                    _akutalisKevertABC += _abc[k];
                }

                //hottáadjuk a kódtábla tömbhöz a kevert ABC-t
                kodTabla[_indexKodtabla] = _akutalisKevertABC;
                _indexKodtabla++;
            }
            return kodTabla;
        }

        static string Vigenere_Kodolo(string szoveg, string kulcs)
        {
            string _kodoltSzoveg = "";
            string[] kodTabla = VigenereKodtablaLetrehozasa(kulcs);

            //az első kevert abc sora az 1. indexen van, mivel a 0. helyen az eredeti ABC áll.
            int _indexKevertAbc = 1;

            for (int i = 0; i < szoveg.Length; i++)
            {
                bool TartalmaztaAKaraktert = false;


                //keressük az eredeti ABC-ben az adott betüt, hogy megtudjuk az oszlop indexet!
                int j = 0;
                while (TartalmaztaAKaraktert != true && j < kodTabla[0].Length)
                {
                    if (kodTabla[0][j] == szoveg[i])
                    {
                        _kodoltSzoveg += kodTabla[_indexKevertAbc][j];
                        TartalmaztaAKaraktert = true;
                        _indexKevertAbc++;
                    }
                    else if (kodTabla[0][j].ToString().ToLower() == szoveg[i].ToString())
                    {
                        _kodoltSzoveg += kodTabla[_indexKevertAbc][j].ToString().ToLower();
                        TartalmaztaAKaraktert = true;
                        _indexKevertAbc++;
                    }
                    j++;
                }

                if (_indexKevertAbc == kulcs.Length+1)
                {
                    _indexKevertAbc = 1;
                }
                //ha az adott karakter nincs benne, pld szám, vessző stbstb, akkor marad ugyanaz!
                if (TartalmaztaAKaraktert == false)
                {
                    _kodoltSzoveg += szoveg[i];
                }
               

             
            }
            return _kodoltSzoveg;
        }

        static string Vignere__Kodolo_Dekodolo(string szoveg, string kulcs)
        {

            string _kodoltSzoveg = "";
            string[] kodTabla = VigenereKodtablaLetrehozasa(kulcs);

            //az első kevert abc sora az 1. indexen van, mivel a 0. helyen az eredeti ABC áll.
            int _indexKevertAbc = 1;

            for (int i = 0; i < szoveg.Length; i++)
            {
                bool TartalmaztaAKaraktert = false;

                //keressük a kevert ABC -ben az oszlop indexet, ha megvan, akkor az első sor j-edik oszlopa lesz az eredeti karakter érték.
                int j = 0;
                while (TartalmaztaAKaraktert != true && j < kodTabla[_indexKevertAbc].Length)
                {

                    if (kodTabla[_indexKevertAbc][j] == szoveg[i])
                    {
                        _kodoltSzoveg += kodTabla[0][j];
                        TartalmaztaAKaraktert = true;
                        _indexKevertAbc++;
                    }
                    else if (kodTabla[_indexKevertAbc][j].ToString().ToLower() == szoveg[i].ToString())
                    {
                        _kodoltSzoveg += kodTabla[0][j].ToString().ToLower();
                        TartalmaztaAKaraktert = true;
                        _indexKevertAbc++;
                    }
                    j++;
                }
                //ha az adott karakter nincs benne, pld szám, vessző stbstb, akkor marad ugyanaz!
                if (TartalmaztaAKaraktert == false)
                {
                    _kodoltSzoveg += szoveg[i];
                }

                if (_indexKevertAbc == kulcs.Length +1)
                {
                    _indexKevertAbc = 1;
                }
                j = 0;
              
            }
            return _kodoltSzoveg;


        }


        #endregion



        #region PlayFair

        static bool Csekkolas(string szoveg)
        {
            bool eredmeny = true;
            szoveg = szoveg.ToLower();
            string nemMegengedettkarakterek = "öüóőúéáűí1234567890-.?!";
            for (int i = 0; i < szoveg.Length; i++)
            {
                for (int j = 0; j < nemMegengedettkarakterek.Length; j++)
                {
                    if (szoveg[i] == nemMegengedettkarakterek[j])
                    {
                        eredmeny = false;
                    }
                }

            }
            return eredmeny;
        }




        static string[,] PlayFair_KodTabla(string kod)
        {
            //angol ABC j nélkül.. 25 betű 5x5os matrix.
            string[,] matrix = new string[5, 5];
            string _abc = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            string kodtabla_Egy_Sorban_Megfelelo_Sorrendben = "";
            // A kodból beletesszük a betűket figyelük a duplikációra! ennek érdekében egy bool változót létrehozunk, ami nézi, hogy van e már a kódtáblánkban az adott betü..
            for (int i = 0; i < kod.Length; i++)
            {
                bool BenneVan = false;
                for (int j = 0; j < kodtabla_Egy_Sorban_Megfelelo_Sorrendben.Length; j++)
                {
                    if (kodtabla_Egy_Sorban_Megfelelo_Sorrendben[j].ToString() == kod[i].ToString().ToUpper())
                    {
                        BenneVan = true;
                    }
                }
                if (BenneVan == false)
                {
                    kodtabla_Egy_Sorban_Megfelelo_Sorrendben += kod[i].ToString().ToUpper();
                }
            }
            // Az ABC-ből beletesszük a betűket amik még nincsennek benne..
            for (int i = 0; i < _abc.Length; i++)
            {
                bool BenneVan = false;
                for (int j = 0; j < kodtabla_Egy_Sorban_Megfelelo_Sorrendben.Length; j++)
                {
                    if (kodtabla_Egy_Sorban_Megfelelo_Sorrendben[j].ToString() == _abc[i].ToString())
                    {
                        BenneVan = true;
                    }

                }
                if (BenneVan == false)
                {
                    kodtabla_Egy_Sorban_Megfelelo_Sorrendben += _abc[i];
                }
            }

            //KODOLO MáTRIX FELTÖLTÉSE!! a létrehozott 25 hosszúságú stringünk alapján
            int _index = 0;

            string teszt = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = kodtabla_Egy_Sorban_Megfelelo_Sorrendben[_index].ToString();
                    _index++;
                    teszt += matrix[i, j] + "\t";
                }
                teszt += "\n";
            }
            MessageBox.Show(teszt);
            return matrix;
        }

        static string PlayFairKodolo(string kod, string szoveg)
        {
            string _eredmeny = "";
            string[,] kodtabla = PlayFair_KodTabla(kod);

            //1. lépés, összes j betü i-re cserélése!
            szoveg = szoveg.ToUpper();
            szoveg = szoveg.Replace("J", "I");
            //Ha páratlan a szövegünk hossza, akkor egy Q-t mögé kell szúrni, de előtte az  " " üres helyeket elkell távolítani
            szoveg = szoveg.Replace(" ", "");
            if (szoveg.Length %2 != 0)
            {
                szoveg += "X";
            }







            //Kettes párokra kell bontani, hogy utána kódolhassuk, ha két egymás melletti betű ugyanaz, akkor X-re cseréljük a 2-at
            string[] kettesParok = new string[szoveg.Length / 2];
            int q = 0;
            for (int i = 1; i < szoveg.Length; i += 2)
            {
                //aktuális kettes tag
                string _aktualKettes = "";
                if (szoveg[i-1] == szoveg[i])
                {
                    _aktualKettes = szoveg[i - 1] + "X";
                    kettesParok[q] = _aktualKettes;
                    q++;
                }
                else
                {
                    _aktualKettes = szoveg[i - 1].ToString() + szoveg[i];
                    kettesParok[q] = _aktualKettes;
                    q++;
                }
            }

            for (int y = 0; y < kettesParok.Length; y++)
            {
                //megkell találni mindkét betü sor és oszlop indexét!
                int _elsoTagSor = 0;
                int _elsoTagOszlop = 0;
                int _masodikTagSor = 0;
                int _masodikTagOszlop = 0;


                //ELSŐ KARAKTEr MEGKERESÉSE
                for (int j = 0; j < kodtabla.GetLength(0); j++)
                {
                    for (int k = 0; k < kodtabla.GetLength(1); k++)
                    {
                        //ha az első karakter egyezik
                        if (kettesParok[y][0].ToString() == kodtabla[j, k])
                        {
                            _elsoTagSor = j;
                            _elsoTagOszlop = k;
                        }
                    }
                }

                //Második karakter megkeresése
                for (int j = 0; j < kodtabla.GetLength(0); j++)
                {
                    for (int k = 0; k < kodtabla.GetLength(1); k++)
                    {
                        //ha a második karakter egyezik
                        if (kettesParok[y][1].ToString() == kodtabla[j, k])
                        {
                            _masodikTagSor = j;
                            _masodikTagOszlop = k;
                        }
                    }
                }

                //miután megvan mindkettőnek a helye, ezek alapján a feltételekkel könnyen tujuk kódolni!

                #region Egyezik A Sor
                //Ha egy sorban van a két elem!
                if (_elsoTagSor == _masodikTagSor)
                {
                    if (_elsoTagOszlop + 1 <= kodtabla.GetLength(0) - 1)
                    {
                        _eredmeny += kodtabla[_elsoTagSor, _elsoTagOszlop + 1];
                    }
                    else
                    {
                        _eredmeny += kodtabla[_elsoTagSor, 0];
                    }


                    if (_masodikTagOszlop + 1 <= kodtabla.GetLength(0) - 1)
                    {
                        _eredmeny += kodtabla[_masodikTagSor, _masodikTagOszlop + 1];
                    }
                    else
                    {
                        _eredmeny += kodtabla[_masodikTagSor, 0];
                    }

                }
                #endregion
                #region EGYEZIK AZ OSZLOP
                //HA egy oszlopban vannak!
                else if (_elsoTagOszlop == _masodikTagOszlop)
                {
                    if (_elsoTagSor + 1 <= kodtabla.GetLength(1) - 1)
                    {
                        _eredmeny += kodtabla[_elsoTagSor + 1, _elsoTagOszlop];
                    }
                    else
                    {
                        _eredmeny += kodtabla[0, _elsoTagOszlop];
                    }


                    if (_masodikTagSor + 1 <= kodtabla.GetLength(1) - 1)
                    {
                        _eredmeny += kodtabla[_masodikTagSor + 1, _masodikTagOszlop];
                    }
                    else
                    {
                        _eredmeny += kodtabla[0, _masodikTagOszlop];
                    }
                }
                #endregion
                //Ellenkező esetben, nincs egy sorban egy oszlopban, akkor egy külön kis téglalapot alkotnak és a két másik sarkában levő karaktereket vesszük!
                else
                {
                    //a sor nem változik a négyzetben csak az oszlop! Mégpedig a másik tag oszlopának az indexét kapja meg!
                    _eredmeny += kodtabla[_elsoTagSor, _masodikTagOszlop];
                    _eredmeny += kodtabla[_masodikTagSor, _elsoTagOszlop];

                }
            }
            return _eredmeny;
        }

        static string PlayFairDeKodolo(string kod, string szoveg)
        {
            string[,] kodtabla = PlayFair_KodTabla(kod);
            string eredmeny = "";

            string[] kettesParok = new string[szoveg.Length / 2];
            int q = 0;
            for (int i = 1; i < szoveg.Length; i++)
            {
                string _aktualKettesPar = szoveg[i - 1].ToString() + szoveg[i];
                kettesParok[q] = _aktualKettesPar;
                q++;
                i++;
            }


            for (int y = 0; y < kettesParok.Length; y++)
            {
                int _elsoTagSor = 0;
                int _elsoTagOszlop = 0;
                int _masodikTagSor = 0;
                int _masodikTagOszlop = 0;


                //első betű sor és oszlop indexe.
                for (int j = 0; j < kodtabla.GetLength(0); j++)
                {
                    //Külön ciklusba kell venni, hogy mindenképp az első karaktert találja meg először!
                    for (int k = 0; k < kodtabla.GetLength(1); k++)
                    {
                        //ha az első karakter egyezik
                        if (kettesParok[y][0].ToString() == kodtabla[j, k])
                        {

                            _elsoTagSor = j;
                            _elsoTagOszlop = k;
                        }
                    }
                }

                //második betü sor és oszlop indexe.
                for (int j = 0; j < kodtabla.GetLength(0); j++)
                {
                    for (int k = 0; k < kodtabla.GetLength(1); k++)
                    {
                        //ha a második karakter egyezik
                        if (kettesParok[y][1].ToString() == kodtabla[j, k])
                        {
                            _masodikTagSor = j;
                            _masodikTagOszlop = k;
                        }
                    }
                }

                #region Egyezik A Sor
                //Ha egy sorban van a két elem!
                if (_elsoTagSor == _masodikTagSor)
                {
                    if (_elsoTagOszlop == 0)
                    {
                        eredmeny += kodtabla[_elsoTagSor, kodtabla.GetLength(1) - 1];
                    }
                    else
                    {
                        eredmeny += kodtabla[_elsoTagSor, _elsoTagOszlop - 1];
                    }


                    if (_masodikTagOszlop == 0)
                    {
                        eredmeny += kodtabla[_masodikTagSor, kodtabla.GetLength(1) - 1];
                    }
                    else
                    {
                        eredmeny += kodtabla[_masodikTagSor, _masodikTagOszlop - 1];
                    }

                }
                #endregion

                #region EGYEZIK AZ OSZLOP
                //HA egy oszlopban vannak!
                else if (_elsoTagOszlop == _masodikTagOszlop)
                {
                    if (_elsoTagSor == 0)
                    {
                        eredmeny += kodtabla[kodtabla.GetLength(0) - 1, _elsoTagOszlop];
                    }
                    else
                    {
                        eredmeny += kodtabla[_elsoTagSor - 1, _elsoTagOszlop];
                    }


                    if (_masodikTagSor == 0)
                    {
                        eredmeny += kodtabla[kodtabla.GetLength(0) - 1, _masodikTagOszlop];
                    }
                    else
                    {
                        eredmeny += kodtabla[_masodikTagSor - 1, _masodikTagOszlop];
                    }


                }
                #endregion

                //Ellenkező esetben, nincs egy sorban egy oszlopban, akkor egy külön kis négyzetet alkotnak és a két másik sarkában levő karaktereket vesszük!
                else
                {
                    //a sor nem változik a négyzetben csak az oszlop! Mégpedig a másik tag oszlopának az indexét kapja meg!
                    eredmeny += kodtabla[_elsoTagSor, _masodikTagOszlop];
                    eredmeny += kodtabla[_masodikTagSor, _elsoTagOszlop];
                }
            }

            string _ezMegyVissza = "";
            for (int i = 1; i < eredmeny.Length ; i += 2)
            {
                string _aktual = eredmeny[i - 1].ToString() + eredmeny[i];
                if (i == eredmeny.Length-1)
                {
                    if (_aktual.Contains("X"))
                    {
                        _aktual = eredmeny[i - 1].ToString();
                    }
                }
                if (_aktual.Contains("X"))
                {
                    _aktual = eredmeny[i - 1].ToString() + eredmeny[i - 1];
                }
                _ezMegyVissza += _aktual;
            }

            return _ezMegyVissza;
        }



        #endregion

        

        #region HUffman


        static Huffman_Kodtabla_Tipus[] HuffmanKodtablaLEtrehozas(string bemenet)
        {
            bemenet = bemenet.ToUpper();



            //karakterekre bontás és azok megszámolsa..
            List<string> osszesBetu = new List<string>();
            List<int> osszesBetuDarabja = new List<int>();
            for (int i = 0; i < bemenet.Length; i++)
            {
                if (osszesBetu.Contains(bemenet[i].ToString()) == false)
                {
                    osszesBetu.Add(bemenet[i].ToString());
                }
            }
            for (int i = 0; i < osszesBetu.Count; i++)
            {
                int db = 0;
                for (int j = 0; j < bemenet.Length; j++)
                {
                    if (bemenet[j].ToString() == osszesBetu[i])
                    {
                        db++;
                    }
                }
                osszesBetuDarabja.Add(db);
            }





            //ezt adjuk vissza.. a betuket a megfelelő kód párjukkal. ebből annyi van ahány különböző betű
            Huffman_Kodtabla_Tipus[] __kodTabla = new Huffman_Kodtabla_Tipus[osszesBetu.Count];

            //REndezés
            Rendezed(ref osszesBetu, ref osszesBetuDarabja);


            //Kodtabla létrehozása
            for (int i = 0; i < osszesBetu.Count; i++)
            {

                //karakterekre bontás és azok megszámolsa..
                List<string> _betuk = new List<string>();
                List<int> _darabSzamok = new List<int>();
                for (int j = 0; j < bemenet.Length; j++)
                {
                    if (_betuk.Contains(bemenet[j].ToString()) == false)
                    {
                        _betuk.Add(bemenet[j].ToString());
                    }
                }
                for (int j = 0; j < _betuk.Count; j++)
                {
                    
                    int db = 0;
                    for (int y = 0; y < bemenet.Length; y++)
                    {
                        
                        if (bemenet[y].ToString() == _betuk[j])
                        {
                            db++;
                        }
                    }
                    _darabSzamok.Add(db);
                }
             
                //REndezés
                Rendezed(ref _betuk, ref _darabSzamok);

                string _aktualBetu = osszesBetu[i];
                string _kod = "";
               
                //Végig megy mindig a kódfaLebontáson és ha előső vagy második az adott betü, akkor a megfelelő 0-at vagy 1-et hozzárendeli!
                do
                {

                    // Ha az adott betü vagy betü állomány az 1. azaz a 0. indexen van, ahol az aktuális betünk is van, akkor 0 kerül a kódjához
                    if (_aktualBetu == _betuk[0])
                    {
                        _aktualBetu = _betuk[0] + _betuk[1];
                        int kozosElofordulas = _darabSzamok[0] + _darabSzamok[1];


                        //kiveszük az összeolvasztott elemeket!
                        _darabSzamok.RemoveAt(0);
                        _darabSzamok.RemoveAt(0);
                        _betuk.RemoveAt(0);
                        _betuk.RemoveAt(0);
                          
                         






                        //hozzáadjuk az új összeolvasztott elemet és rendezzük!
                        _betuk.Insert(0, _aktualBetu);
                        _darabSzamok.Insert(0, kozosElofordulas);
                        Rendezed(ref _betuk, ref _darabSzamok);

                        //kódhoz nulla kerül
                        _kod += "0";
                    }
                    //ha az adott betü vagy állomány a 2. azaz az 1. indexen van..
                    else if (_aktualBetu == _betuk[1])
                    {
                        _aktualBetu = _betuk[0] + _betuk[1];
                        int kozosElofordulas = _darabSzamok[0] + _darabSzamok[1];

                        //kivesszük az összeolvasztott állományt
                        _darabSzamok.RemoveAt(0);
                        _darabSzamok.RemoveAt(0);
                        _betuk.RemoveAt(0);
                        _betuk.RemoveAt(0);

                        //hozzáadjuk és rendezzük
                        _betuk.Insert(0, _aktualBetu);
                        _darabSzamok.Insert(0, kozosElofordulas);
                        Rendezed(ref _betuk, ref _darabSzamok);

                        //kódhoz egyes kerül
                        _kod += "1";
                    }
                    //ha se a 0. se az 1. indexen nincs, akkor is megcsinálom a folyamatot, hogy eljussunk a kódfa végéig!
                    else
                    {
                        string haEgyikSem = _betuk[0] + _betuk[1];
                        int kozosElofordulas = _darabSzamok[0] + _darabSzamok[1];

                        _darabSzamok.RemoveAt(0);
                        _darabSzamok.RemoveAt(0);
                        _betuk.RemoveAt(0);
                        _betuk.RemoveAt(0);


                        _betuk.Insert(0, haEgyikSem);
                        _darabSzamok.Insert(0, kozosElofordulas);
                        Rendezed(ref _betuk, ref _darabSzamok);
                    }



                } while (_betuk.Count != 1);


                Huffman_Kodtabla_Tipus aktual = new Huffman_Kodtabla_Tipus();
                aktual.betu = osszesBetu[i];
                aktual.kodja = Megcserelt(_kod);

                __kodTabla[i] = aktual;

            }
            return __kodTabla;
        }



        static string HuffmanKodolo(string szoveg)
        {
            szoveg = szoveg.ToUpper();
            string eredmeny = "";
            Huffman_Kodtabla_Tipus[] kodTabla = HuffmanKodtablaLEtrehozas(szoveg);

            for (int i = 0; i < szoveg.Length; i++)
            {

                for (int j = 0; j < kodTabla.Length; j++)
                {

                    if (szoveg[i].ToString() == kodTabla[j].betu)
                    {
                        eredmeny += kodTabla[j].kodja + " ";
                    }
                }
            }
            return eredmeny;
        }

        static string HuffmanDeKodolo(string szoveg, Huffman_Kodtabla_Tipus[] kodTabla)
        {
            string eredmeny = "";
            string[] daraboltSZoveg = szoveg.Split(' ');

            for (int i = 0; i < daraboltSZoveg.Length; i++)
            {
                for (int j = 0; j < kodTabla.Length; j++)
                {

                    if (daraboltSZoveg[i] == kodTabla[j].kodja)
                    {
                        eredmeny += kodTabla[j].betu;
                    }

                }
            }

            return eredmeny;
        }



        static void Rendezed(ref List<string> Megszamolas, ref List<int> DarabSzamok)
        {
            for (int i = Megszamolas.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (DarabSzamok[j] > DarabSzamok[j + 1])
                    {
                        string ideiglenes = Megszamolas[j];
                        int _ideiglenes = DarabSzamok[j];

                        Megszamolas[j] = Megszamolas[j + 1];
                        DarabSzamok[j] = DarabSzamok[j + 1];

                        Megszamolas[j + 1] = ideiglenes;
                        DarabSzamok[j + 1] = _ideiglenes;
                    }
                }

            }
        }


        static string Megcserelt(string kod)
        {
            string csereltKod = "";
            for (int i = kod.Length - 1; i > -1; i--)
            {
                csereltKod += kod[i];
            }
            return csereltKod;

        }





        #endregion

    }
}
