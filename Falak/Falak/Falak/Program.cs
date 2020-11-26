using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Falak
{
    static class Show
    {
        public static void ShowMap(int[,] _map)
        {
            for (int i = 0; i < _map.GetLength(1); i++)
            {
                Console.Write("-");
            }


            for (int i = 0; i < _map.GetLength(0) - 1; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, _map.GetLength(0));


            for (int i = 0; i < _map.GetLength(1); i++)
            {
                Console.Write("-");
            }

            for (int i = 0; i < _map.GetLength(0) - 1; i++)
            {
                Console.SetCursorPosition(_map.GetLength(1) - 1, i + 1);
                Console.Write("|");
            }




        }
        public static void ShowWall(int _wallsNumber, int[,] walls, int _squareLength, int[,] _map)
        {
            for (int i = 0; i < _wallsNumber; i++)
            {
                //akkor függőlegesen megy fel!
                if (walls[i, 2] == 1)
                {
                    int left = walls[i, 0];
                    int top = (_squareLength + 2) - walls[i, 1];
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                    for (int j = 0; j < walls[i, 3]; j++)
                    {
                        Console.SetCursorPosition(left, top);
                        if (_map[left,top] == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        top--;
                    }
                    Console.ResetColor();

                }
                else if (walls[i, 3] == 1)
                {
                    int left = walls[i, 0];
                    int top = (_squareLength + 2) - walls[i, 1];

                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    for (int j = 0; j < walls[i, 2]; j++)
                    {
                        Console.SetCursorPosition(left, top);
                        if (_map[left, top] == 9)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("X");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        left++;
                    }
                    Console.ResetColor();
                }
            }
        }
        public static void ShowPoint(int[,] startPositions, int _squareLength, int[,] _map)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < startPositions.GetLength(0); i++)
            {
                
                int left = startPositions[i,0];
                int top = (_squareLength+2)-startPositions[i, 1];
                Console.SetCursorPosition(left, top);
                _map[left, top] = 9;
                Console.Write("X");
            }
            Console.ResetColor();
        }


    }

    class Walls
    {
        private int[,] _map { get; set; }
        private int _squareLength { get; set; }
        private int _wallsNumber { get; set; }
        private int _startPointsNumber { get; set; }
        private int[,] walls { get; set; }
        private int[,] startPositions { get; set; }


        public void CanIGoToOrigo()
        {
            Read();
            Map();

            
            string[] results = CanIEscape();
            WriteFile(results);
        }

        private void WriteFile(string[] results_)
        {
            StreamWriter sw = new StreamWriter("FALAK.KI.txt");
            for (int i = 0; i < results_.Length; i++)
            {
                sw.WriteLine(results_[i]);
            }


            sw.Close();
        }

        private void Map()
        {
            _map = new int[(_squareLength+ 2), (_squareLength + 2)];
            Show.ShowMap(_map);
            Show.ShowPoint(startPositions, _squareLength,  _map);
            Show.ShowWall(_wallsNumber, walls, _squareLength,  _map);

            //A térképen a falak helyére mondjuk 5-öt kéne tenni, a kezdőpontoknak új x,y kordinátát adni, ami illik a tömbünkhöz
            MapAllZero();
            MinusFiveAllWall();




        }
        private void Read()
        {
            StreamReader sr = new StreamReader("FALAK.BE.txt");
            string[] splitOne = sr.ReadLine().Split(' ');
            _squareLength = int.Parse(splitOne[0]);
            _wallsNumber = int.Parse(splitOne[1]);
            _startPointsNumber = int.Parse(splitOne[2]);
            walls = new int[_wallsNumber, 4];  //L sor, 4 oszlop!
            startPositions = new int[_startPointsNumber, 2];
            for (int i = 0; i < _wallsNumber; i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    walls[i, j] = int.Parse(split[j]);
                }
            }
            for (int i = 0; i < startPositions.GetLength(0); i++)
            {
                string[] split = sr.ReadLine().Split(' ');
                for (int j = 0; j < startPositions.GetLength(1); j++)
                {
                    startPositions[i, j] = int.Parse(split[j]);
                }
            }
        }
        private void MinusFiveAllWall()
        {
            for (int i = 0; i < _wallsNumber; i++)
            {
                int left = walls[i, 0];
                int top = walls[i, 1];
                if (walls[i,2] == 1)//függőlegesen
                {
                    for (int j = 0; j < walls[i,3]; j++)
                    {
                        _map[top, left] = -5;
                        top++;
                    }
                }
                else if(walls[i,3] == 1)
                {
                   
                    for (int j = 0; j < walls[i,2]; j++)
                    {
                        _map[top, left] = -5;
                        left++;
                    }

                }




            }


        }
        private void MapAllZero()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    _map[i, j] = 0;
                }
            }
        }




        private string[] CanIEscape()
        {
            string[] may = new string[_startPointsNumber];
            for (int i = 0; i < _startPointsNumber; i++)
            {
                int left = startPositions[i, 1];
                int top = startPositions[i, 0];

                //Ha a térképen az aktuális kezdőpont nem fal... Arra figyelünk, hogy a mi táblázatunk kezdő pontjai azaz az origó a bal felső sarokban van, így az y kordináta az az x és az y az x
                if (_map[left, top] > -1)
                {
                    bool can = false;
                    int index = i + 1;
                    Check(index, left, top, ref can);
                    if (can == true)
                    {
                        may[i] = "IGEN";
                    }
                    else
                    {
                        may[i] = "NEM";
                    }


                }
                else
                {
                    may[i] = "NEM";
                }
                
            }
            return may;

        }
        private void Check(int index, int x, int y,ref bool result_)
        {
            if (result_ == false)
            {
                _map[x, y] = index;

             

                
                if (FuggolegesFel(x,y) == true || FuggolegesLe(x,y) == true || VizszintBalra(x,y) == true || VizszintJobbra(x,y) == true)
                {
                    result_ = true;
                }
                else
                {
                    if (_map[x-1,y] >-1 && _map[x-1,y] < index)
                    {
                        int newX = x - 1;
                        Check(index, newX, y,ref result_);
                    }
                    if (_map[x,y-1] >-1 && _map[x,y-1] < index)
                    {
                        int newY = y - 1;
                        Check( index, x, newY,ref result_);
                    }
                    if (_map[x+1,y] > -1 && _map[x+1,y] < index)
                    {
                        int newX = x + 1;
                        Check( index, newX,  y, ref result_);
                    }
                    if (_map[x,y+1] > -1 && _map[x,y+1] < index)
                    {
                        int newY = y + 1;
                        Check( index, x, newY, ref result_);
                    }

                }
            }
           
        }



        private bool VizszintBalra(int x, int y)
        {
            bool result_ = true;
            int X = x;
            int Y = y;
            
            for (int i = 0; i < y; i++)
            {
                if (_map[X, Y] > -1)
                {
                  
                }
                else
                {
                   
                    result_ = false;

                }

                Y--;
            }


            return result_;
        }
        private bool VizszintJobbra(int x, int y)
        {
                bool result_ = true;
                int X = x;
                int Y = y;
            
                for (int i = 0; i < _squareLength + 1 - y; i++)
                {
                if (_map[X, Y] > -1)
                {
                }
                else
                {

                    result_ = false;

                }

                    Y++;
                }

           
            return result_;
        }
        private bool FuggolegesLe(int x, int y)
        {
            bool result_ = true;
            int X = x;
            int Y = y;
         
            for (int i = 0; i < x; i++)
            {
                if (_map[X,Y] > -1)
                {
                   
                }
                else
                {
                   
                    result_ = false;
                }
                X--;

            }

            

            return result_;
        }
        private bool FuggolegesFel(int x, int y)
        {
            bool result_ = true;
            int X = x;
            int Y = y;
          
            for (int i = 0; i < _squareLength+1 - x; i++)
            {
                if (_map[X, Y] > -1)
                {
                   
                }
                else
                {
                   
                    result_ = false;
                }
                X++;

            }

          

            return result_;


        }




    }


    class Program
    {
        static void Main(string[] args)
        {
            Walls w = new Walls();
            w.CanIGoToOrigo();

            Console.ReadLine();
        }
    }
}
