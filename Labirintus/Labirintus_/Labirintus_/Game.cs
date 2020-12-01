using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Labirintus_
{
    class Game
    {
        private string[,] _map;
        private int _leftPosition;
        private int _topPosition;

        private int _sor;
        private int _oszlop;

        private int _endTop;
        private int _endLeft;

        public void PlayTheGame(string _whichMap, string[,] _topList)
        {
            Start();
            //ide rakj egy visszaszámlálást..


            ReadMap(_whichMap);
            Show.DrawMap(_map);

            //kezdő pontok kikeresése, végpontok kikeresése..
            StartAndEndIndex();
            Show.EndIndexColor(_endLeft, _endTop);
            Show.PlayerStatus(_leftPosition, _topPosition);

            _sor = _topPosition;
            _oszlop = _leftPosition;

            bool win = false;
            ConsoleKey key;
            Stopwatch _stopWatch = new Stopwatch();
            _stopWatch.Start();
            do
            {
                int _actualSor = _sor;
                int _actualOszlop = _oszlop;

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.RightArrow)
                {
                    _actualOszlop++;
                    if (_map[_actualSor, _actualOszlop] != "|" && _map[_actualSor, _actualOszlop] != "+" && _map[_actualSor, _actualOszlop] != "-")
                    {
                        Show.PlayerBeforeStatus(_leftPosition, _topPosition);
                        _leftPosition++;
                        _oszlop++;
                        Show.PlayerStatus(_leftPosition, _topPosition);
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    _actualOszlop--;
                    if (_map[_actualSor, _actualOszlop] != "|" && _map[_actualSor, _actualOszlop] != "+" && _map[_actualSor, _actualOszlop] != "-")
                    {
                        Show.PlayerBeforeStatus(_leftPosition, _topPosition);
                        _leftPosition--;
                        _oszlop--;
                        Show.PlayerStatus(_leftPosition, _topPosition);
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _actualSor++;
                    if (_map[_actualSor, _actualOszlop] != "|" && _map[_actualSor, _actualOszlop] != "+" && _map[_actualSor, _actualOszlop] != "-")
                    {
                        Show.PlayerBeforeStatus(_leftPosition, _topPosition);
                        _topPosition++;
                        _sor++;
                        Show.PlayerStatus(_leftPosition, _topPosition);
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    _actualSor--;
                    if (_map[_actualSor, _actualOszlop] != "|" && _map[_actualSor, _actualOszlop] != "+" && _map[_actualSor, _actualOszlop] != "-")
                    {
                        Show.PlayerBeforeStatus(_leftPosition, _topPosition);
                        _topPosition--;
                        _sor--;
                        Show.PlayerStatus(_leftPosition, _topPosition);
                    }
                }

                win = WinCheck();
            } while (win != true && key != ConsoleKey.Escape);
            _stopWatch.Stop();

            //escape
            if (key == ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, _map.GetLength(0) + 1);
                Console.WriteLine("Escape-et nyomtál, enterrel visszaléphetsz a menübe.");
            }
            //win
            if (win == true)
            {
                Console.SetCursorPosition(0, _map.GetLength(0) + 1);
                //nézd meg hogy toplistába kerülte
                TimeSpan _ts = _stopWatch.Elapsed;
                Console.WriteLine($"Végig mentél {_ts} idő alatt..");
                NewRecord(_topList, _ts, _whichMap);

                Console.WriteLine("Enter leütése után újra a menüben leszel..");
            }
            Console.ReadLine();
        }

        //read and loads map
        private void ReadMap(string _whichMap)
        {
            StreamReader sr = new StreamReader("palya_" + _whichMap + ".be");
            int[] MAPSIZE = MapSize(_whichMap);
            _map = new string[MAPSIZE[0], MAPSIZE[1]];
            int counter = 0;
            while (!sr.EndOfStream)
            {
                string oneLine = sr.ReadLine();
                for (int i = 0; i < oneLine.Length; i++)
                {
                    _map[counter, i] = oneLine[i].ToString();
                }
                counter++;
            }


            sr.Close();
        }
        private int[] MapSize(string _whichMap)
        {
            int counter = 0;
            int[] _result = new int[2];
            StreamReader sr = new StreamReader("palya_" + _whichMap + ".be");
            string firstLine = sr.ReadLine();
            _result[1] = firstLine.Length;
            counter++;
            while (!sr.EndOfStream)
            {
                firstLine = sr.ReadLine();
                counter++;
            }
            sr.Close();
            _result[0] = counter;
            return _result;
        }

        //search start index
        private void StartAndEndIndex()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] == "K")
                    {
                        //oszlop!
                        _leftPosition = j;
                        //sor
                        _topPosition = i;
                    }
                    if (_map[i, j] == "B")
                    {
                        //oszlop!
                        _endLeft = j;
                        //sor
                        _endTop = i;
                    }
                }
            }
        }

        //win check
        private bool WinCheck()
        {
            if (_leftPosition == _endLeft && _topPosition == _endTop)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void NewRecord(string[,] _topList, TimeSpan fullTime_, string _whichMap)
        {
            bool _newRecord = false;

            int index = 0;
            while (index != _topList.GetLength(0) && _newRecord != true)
            {
                if (true)
                {
                    if (_topList[index, 2] == _whichMap && fullTime_ < TimeSpan.Parse(_topList[index, 1]))
                    {
                        _newRecord = true;
                        string _newNAme = Show.NewTopFive();
                        _topList[index, 0] = _newNAme;
                        _topList[index, 1] = fullTime_.ToString();

                    }


                }
                index++;
            }
            if (_newRecord == false)
            {
                Show.WinButNotTopFive();
            }
            else
            {
                WriteTopList(_topList);
            }
        }
        private void WriteTopList(string[,] topList)
        {
            StreamWriter sw = new StreamWriter("toplista.txt");

            for (int i = 0; i < topList.GetLength(0); i++)
            {
                sw.WriteLine(topList[i, 0] + "|" + topList[i, 1] + "|" + topList[i, 2]);
            }

            sw.Close();
        }


        private void Start()
        {
            StreamReader sr3 = new StreamReader("3.txt");
            StreamReader sr2 = new StreamReader("2.txt");
            StreamReader sr1 = new StreamReader("1.txt");
            StreamReader sr0 = new StreamReader("0.txt");
            string[,] array3 = new string[22, 32];
            string[,] array2 = new string[22, 32];
            string[,] array1 = new string[22, 23];
            string[,] array0 = new string[22, 32];

            int counter = 0;
            while (!sr3.EndOfStream)
            {
                string sor = sr3.ReadLine();
                for (int i = 0; i < sor.Length; i++)
                {
                    array3[counter, i] = sor[i].ToString();
                }
                counter++;
            }


            counter = 0;
            while (!sr2.EndOfStream)
            {
                string sor = sr2.ReadLine();
                for (int i = 0; i < sor.Length; i++)
                {
                    array2[counter, i] = sor[i].ToString();
                }
                counter++;
            }

            counter = 0;
            while (!sr1.EndOfStream)
            {
                string sor = sr1.ReadLine();
                for (int i = 0; i < sor.Length; i++)
                {
                    array1[counter, i] = sor[i].ToString();
                }
                counter++;
            }

            counter = 0;
            while (!sr0.EndOfStream)
            {
                string sor = sr0.ReadLine();
                for (int i = 0; i < sor.Length; i++)
                {
                    array0[counter, i] = sor[i].ToString();
                }
                counter++;
            }
            sr0.Close();
            sr2.Close();
            sr1.Close();
            sr3.Close();
            Show.StartCount(array3, array2, array1, array0);

        }

    }
}
