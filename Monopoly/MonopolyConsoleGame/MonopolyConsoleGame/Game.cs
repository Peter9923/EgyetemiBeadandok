using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MonopolyConsoleGame
{
    class Game
    {
        private Map[] _map { get; set; }
        private Players[] _players { get; set; }

        public void PlayTheGame()
        {
            ReadFilesAndCreateMap();
            int _minimalMoney = MinimalMoney();

            int indexOfPlayers = 0;
            int countLosers = 0;


            Show.DrawMap(_map, _players);

            do
            {
                indexOfPlayers = IndexChechk(indexOfPlayers);
               
                if (_players[indexOfPlayers].Money > 0)
                {
                    int thrownValue = Show.Throwing(indexOfPlayers, _players);
                    _players[indexOfPlayers].Position += thrownValue;

                    PassedTheStartField(indexOfPlayers, _minimalMoney);

                    if (ChechkBuiltOnThis(indexOfPlayers))
                    {
                        YouNeedPayAnotherPlayer(indexOfPlayers);
                        System.Threading.Thread.Sleep(1500);
                        Show.DrawMap(_map, _players);
                    }
                    else
                    {
                        if (_map[_players[indexOfPlayers].Position].Owner == -10)
                        {
                            //start field..
                        }
                        else
                        {
                            YouCanBuyThisBuild(indexOfPlayers);
                            System.Threading.Thread.Sleep(1500);
                            Show.DrawMap(_map, _players);
                        }
                    }
                   
                    Console.WriteLine($"New position: {_players[indexOfPlayers].Position}; new money: {_players[indexOfPlayers].Money}");
                    if (_players[indexOfPlayers].Money < 0)
                    {
                        countLosers++;
                        HeSheLost(indexOfPlayers);
                        System.Threading.Thread.Sleep(1500);
                        Show.DrawMap(_map, _players);
                    }
                }
                indexOfPlayers++;

              

            } while (countLosers != 2);

            WhoWin();
        }


        private void ReadFilesAndCreateMap()
        {
            StreamReader sr = new StreamReader("monopoly.txt");
            int startMoney = int.Parse(sr.ReadLine());
            int allField = int.Parse(sr.ReadLine());

            _map = new Map[allField + 1];
            _players = new Players[4];

            //create players.
            for (int i = 0; i < _players.Length; i++)
            {
                Console.Write($"Please write {i+1}. player name: ");
                string _nameConsole = Console.ReadLine();
                //name, money, position
                Players _onePlayer = new Players(_nameConsole, startMoney, 0);
                _players[i] = _onePlayer;
            }
            //create map.
            for (int i = 1; i < _map.Length; i++)
            {
                int _moneyOnThisField = int.Parse(sr.ReadLine());
               
                //owner, value
                Map field_ = new Map(-1, _moneyOnThisField);
                _map[i] = field_;
            }
            //first field is the start field;
            Map firstField = new Map(-10, 0);
            _map[0] = firstField;
            Console.WriteLine();
            sr.Close();
        }
        private int MinimalMoney()
        {
            int min = int.MaxValue;
            for (int i = 1; i < _map.Length; i++)
            {
                if (_map[i].Price < min)
                {
                    min = _map[i].Price;
                }
            }
            return min;
        }
        private int IndexChechk(int index)
        {
            if (index == 4)
            {
                index = 0;
            }
            return index;
        }
        private void PassedTheStartField(int index, int minimalMoney)
        {
            if (_players[index].Position > (_map.Length-1) )
            {
                _players[index].Position = _players[index].Position - _map.Length;
                _players[index].Money += minimalMoney;
                Console.WriteLine("You get "+ minimalMoney + ". :D..");
                System.Threading.Thread.Sleep(1500);
                Show.DrawMap(_map, _players);
            }
        }
        private bool ChechkBuiltOnThis(int index)
        {
            bool _builtOnThis = false;
            if (_map[_players[index].Position].Owner == -10)
            {
                //nothing, start field..
            }
            else
            {
                if (_map[_players[index].Position].Owner != -1)
                {
                    _builtOnThis = true;
                }
            }
            return _builtOnThis;
        }
        private void YouNeedPayAnotherPlayer(int index)
        {
            if (_map[_players[index].Position].Owner != index)
            {
                _players[index].Money -= _map[_players[index].Position].Price;
                _players[_map[_players[index].Position].Owner].Money += _map[_players[index].Position].Price;
                Show.YouPayAnotherPlayer(index, _players, _map);


            }
        }
        private void YouCanBuyThisBuild(int index)
        {
            if (_players[index].Money >= _map[_players[index].Position].Price && _map[_players[index].Position].Owner != -10)
            {
                _map[_players[index].Position].Owner = index;
                _players[index].Money -= _map[_players[index].Position].Price;
                Show.YouBoughtOneBuild(index, _players);
            }
        }
        private void HeSheLost(int index)
        {
            for (int i = 0; i < _map.Length; i++)
            {
                if (_map[i].Owner == index)
                {
                    _map[i].Owner = -1;
                }
            }
            Show.HeSheLost(index, _players);
        }
        private void WhoWin()
        {
            Players[] _theWinners = new Players[2];
            int counter = 0;
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i].Money >0)
                {
                    Players winner = new Players(_players[i].Name, _players[i].Money, _players[i].Position);
                    _theWinners[counter] = winner;
                    counter++;
                }
            }

            if (_theWinners[0].Money > _theWinners[1].Money)
            {
                Console.WriteLine($"The first is: {_theWinners[0].Name}, Last Money: {_theWinners[0].Money}");
                Console.WriteLine();
                Console.WriteLine($"The second is: {_theWinners[1].Name}, Last Money: {_theWinners[1].Money}");
            }
            else if (_theWinners[1].Money > _theWinners[0].Money)
            {
                Console.WriteLine($"This first is: {_theWinners[1].Name}, Last Money: {_theWinners[1].Money}");
                Console.WriteLine();
                Console.WriteLine($"The second is: {_theWinners[0].Name}, Last Money: {_theWinners[1].Money}");
            }
            else
            {
                Console.WriteLine($"{_theWinners[0].Name} and {_theWinners[1].Name} is EQUAL, last moneys are: {_theWinners[0].Money}.");
            }


        }


    }
}
