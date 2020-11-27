using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Monopoly
{
    class JatekMenet
    {
        private Mezo[] _mezo { get; set; }
        private Players[] _players { get; set; }

        public void Play()
        {
            ReadTxt();
            int _minimalMoney = MinimalMoney();

            int index = 0;
            int kiesett = 0;

            do
            {
                if (index == 4)
                {
                    index = 0;
                }
                Show.Draw(_mezo, _players);

                if (_players[index].PenzOsszeg > 0)
                {
                    int dobottErtek = Show.Dobas(index, _players);
                    //megvan a dobott érték, az alábbi dolgokat kell megnézni, van-e rajta szálloda? Ha nincs akkor van e pénz hogy építs rá? Ha van, akkor mennyit fizess és kinek? vagy áthaladtál-e?
                    _players[index].Pozicio += dobottErtek;
                    if (_players[index].Pozicio > _mezo.Length - 1)
                    {
                        _players[index].Pozicio = _players[index].Pozicio - _mezo.Length;
                        //áthaladtál, szóval kell kapnod valamilyen pénzösszeget.
                        _players[index].PenzOsszeg += _minimalMoney;
                    }

                    //ha van az adott pozición szálloda
                    if (VanRajtaSzalloda(index))
                    {
                        //van rajta szálloda, de vajon kié az a szálloda???  
                        EzenMarVanSzallodaSzovalFizess(index);
                    }
                    else
                    {
                        //van e elég pénze, ami nem a nullás START mező..
                        if (_mezo[_players[index].Pozicio].RajtaVan == -10)
                        {
                        }
                        else
                        {
                            VanElegePenz(index);
                        }
                    }
                    Console.WriteLine($"új pozició: {_players[index].Pozicio} új összeg: {_players[index].PenzOsszeg}");
                    //csekk, hogy a playernek a pénze nem e ment le 0 alá
                    if (_players[index].PenzOsszeg < 0)
                    {
                        kiesett++;
                        //aki kiesett annak a mezői legyenek újra üresek!
                        Kiesett(index);
                    }
                }
                index++;

                Console.WriteLine("Nyomj valami a kövi körhöz...");
                Console.ReadKey();

            } while (kiesett != 2); //akkor van vége, ha 2 játékos maradt!

            //ha ideértünk, akkor vége a játéknak, ideje megnézni az eredményt.
            Show.Draw(_mezo, _players);
            WHoWin();
        }


        private void ReadTxt()
        {
            StreamReader sr = new StreamReader("monopoly1.txt");
            int startMoney = int.Parse(sr.ReadLine());
            int allStep = int.Parse(sr.ReadLine());

            _mezo = new Mezo[allStep + 1];

            _players = new Players[4];
            for (int i = 0; i < _players.Length; i++)
            {
                Console.Write($"Add meg az {i + 1}. játékos nevét: ");
                string name = Console.ReadLine();
                Players player = new Players(name, startMoney, 0);
                _players[i] = player;
            }

            for (int i = 0; i < _mezo.Length; i++)
            {
                if (i != 0)
                {
                    int _money = int.Parse(sr.ReadLine());
                    Mezo mezo_ = new Mezo(-1, _money);
                    _mezo[i] = mezo_;
                }
                else
                {
                    Mezo mezo_ = new Mezo(-10, 0);
                    _mezo[i] = mezo_;

                }
            }

            sr.Close();

        }
        private int MinimalMoney()
        {
            int min = int.MaxValue;
            for (int i = 1; i < _mezo.Length; i++)
            {
                if (_mezo[i].Erteke < min)
                {
                    min = _mezo[i].Erteke;
                }

            }
            return min;
        }
        private void VanElegePenz(int index)
        {

            //a 0. poziciót nem lehet megvenni, aminek a rajtaVAn értéke -10
            if (_players[index].PenzOsszeg >= _mezo[_players[index].Pozicio].Erteke && _mezo[_players[index].Pozicio].RajtaVan != -10)
            {
                _mezo[_players[index].Pozicio].RajtaVan = index;
                _players[index].PenzOsszeg -= _mezo[_players[index].Pozicio].Erteke;
                Show.MezotVasarolt(index, _players);
            }
        }
        private bool VanRajtaSzalloda(int index)
        {
            bool vanRajta = false;
            if (_mezo[_players[index].Pozicio].RajtaVan == -10)
            {
                //semmi sincs...
            }
            else
            {
                if (_mezo[_players[index].Pozicio].RajtaVan != -1)
                {
                    //van rajta szálloda, megkell nézni, hogy a sajátja, vagy másé, ha másé, akkor összegcsere kell,..
                    vanRajta = true;
                }


            }
            return vanRajta;




        }
        private void EzenMarVanSzallodaSzovalFizess(int index)
        {
            //ha nem a sajátod
            if (_mezo[_players[index].Pozicio].RajtaVan != index)
            {
                _players[index].PenzOsszeg -= _mezo[_players[index].Pozicio].Erteke;
                _players[_mezo[_players[index].Pozicio].RajtaVan].PenzOsszeg += _mezo[_players[index].Pozicio].Erteke;
                Show.MeglevoMezoreLeptel(index, _players, _mezo);

            }


        }
        private void Kiesett(int index)
        {

            for (int i = 0; i < _mezo.Length; i++)
            {
                if (_mezo[i].RajtaVan == index)
                {
                    _mezo[i].RajtaVan = -1;
                }
            }
            Show.Kiesett(index, _players);
        }
        private void WHoWin()
        {
            Players[] _newArray = new Players[2];
            int counter = 0;
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i].PenzOsszeg > 0)
                {
                    Players winners = new Players(_players[i].Nev, _players[i].PenzOsszeg, _players[i].Pozicio);
                    _newArray[counter] = winners;
                    counter++;
                }
            }
            if (_newArray[0].PenzOsszeg > _newArray[1].PenzOsszeg)
            {
                Console.WriteLine($"1.helyezet: {_newArray[0].Nev}, Összege: {_newArray[0].PenzOsszeg}");
                Console.WriteLine();
                Console.WriteLine($"1.helyezet: {_newArray[1].Nev}, Összege: {_newArray[1].PenzOsszeg}");
            }
            else if (_newArray[1].PenzOsszeg > _newArray[0].PenzOsszeg)
            {
                Console.WriteLine($"1.helyezet: {_newArray[1].Nev}, Összege: {_newArray[1].PenzOsszeg}");
                Console.WriteLine();
                Console.WriteLine($"2.helyezet: {_newArray[0].Nev}, Összege: {_newArray[1].PenzOsszeg}");
            }
            else
            {
                Console.WriteLine($"DÖNTETLEN {_newArray[0].Nev} és {_newArray[1].Nev} is {_newArray[0].PenzOsszeg} összeget gyűjtött össze..");
            }
        }
    }
}
