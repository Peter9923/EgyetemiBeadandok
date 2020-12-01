using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labirintus_
{
    class Menu
    {
        public void ShowMenu()
        {
            string[,] _topList = TopList();
            Sorting(_topList);
            Console.Title = "Menü";
            Console.CursorVisible = false;
            string _options = Show.DrawMenu();

            do
            {
                if (_options == "1")
                {
                    //játék indítása
                    string _whichMap = Show.ChooseMap();
                    Game game = new Game();
                    game.PlayTheGame(_whichMap, _topList);
                    _options = Show.DrawMenu();
                }
                else if (_options == "2")
                {
                    //instrukciók
                    Show.Instructions();
                    Sorting(_topList);
                    _options = Show.DrawMenu();
                }
                else if (_options == "3")
                {
                    //toplista
                    Show.DrawTopList(_topList);


                    _options = Show.DrawMenu();
                }
                else if (_options == "4")
                {
                    //KIFOG LÉPNI
                }
                else
                {
                    _options = Show.DrawMenu();
                }


            } while (_options != "4");
            Show.Exit();
        }


        private string[,] TopList()
        {
            StreamReader sr = new StreamReader("toplista.txt");
            string[,] _topList = new string[25, 3];

            for (int i = 0; i < _topList.GetLength(0); i++)
            {
                string[] oneLine = sr.ReadLine().Split('|');
                _topList[i, 0] = oneLine[0];
                _topList[i, 1] = oneLine[1];
                _topList[i, 2] = oneLine[2];
            }
            sr.Close();
            return _topList;
        }

        private void Sorting(string[,] topList_)
        {
            for (int i = topList_.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (TimeSpan.Parse(topList_[j, 1]) < TimeSpan.Parse(topList_[j + 1, 1]))
                    {
                        string _tmpName = topList_[j, 0];
                        string _time = topList_[j, 1];
                        string _map = topList_[j, 1];

                        topList_[j, 0] = topList_[j + 1, 0];
                        topList_[j, 1] = topList_[j + 1, 1];
                        topList_[j, 2] = topList_[j + 1, 2];

                        topList_[j + 1, 0] = _tmpName;
                        topList_[j + 1, 1] = _time;
                        topList_[j + 1, 2] = _map;
                    }
                }
            }
        }


    }

}
