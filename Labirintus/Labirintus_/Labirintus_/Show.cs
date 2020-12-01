using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirintus_
{
    static class Show
    {
        //MENU
        public static string DrawMenu()
        {
            Console.Clear();
            Console.Title = "Menü";
            Console.WriteLine("(1) - Játék indítása");
            Console.WriteLine("(2) - Hasznos instrukciók");
            Console.WriteLine("(3) - Jelenlegi Toplista Megtekenitése");
            Console.WriteLine("(4) - Kilépés");
            Console.Write("Választásod: ");
            return Console.ReadLine();
        }
        public static void Exit()
        {
            Console.WriteLine("Enterrel kiléphetsz..");
            Console.ReadLine();
        }
        public static void Instructions()
        {
            Console.Clear();
            Console.Title = "Instrukciók";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(2) - es opciót választottad:");
            Console.WriteLine("Az alábbiakat kell tudd a játékról:");
            Console.WriteLine("\t-ESC billentyűzettel bármikor kiléphetsz a játkból");
            Console.WriteLine("\t-A Falakon nem tudsz átmenni, felesleges próbálkoznod..");
            Console.WriteLine("\t-Akkor győzöl, ha a kezdő pontról eljutsz a végpontba.");
            Console.WriteLine("\t-Felkerülsz a toplistára, ha az adott pályán benne vagy a TOP 5-ben.");
            Console.ResetColor();
            Console.WriteLine("Enter leütésével visszatérhetsz a menübe.");
            Console.ReadLine();
            Console.Title = "Menü";
        }
        public static string ChooseMap()
        {
            Console.Clear();
            Console.Title = "Pálya választás";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("(1) - es opciót választottad");
            Console.WriteLine("Válassz az alábbi pályalehetőségek közül: ");
            Console.WriteLine("\t-(1)");
            Console.WriteLine("\t-(2)");
            Console.WriteLine("\t-(3)");
            Console.WriteLine("\t-(4)");
            Console.WriteLine("\t-(5)");
            Console.Write("Választott pályád: ");
            string _options = Console.ReadLine();
            while (_options != "1" && _options != "2" && _options != "3" && _options != "4" && _options != "5")
            {
                Console.Write("Választott pályád: ");
                _options = Console.ReadLine();
            }
            Console.Title = "Játékban vagy";
            Console.ResetColor();
            return _options;
        }
        public static void DrawTopList(string[,] topList)
        {
            Console.Clear();
            Console.Title = "TopLista";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0,19} {1,30} {2,5}", "|  Játékos Neve |", "      Teljesítés ideje     |", "Pálya |");
            Console.WriteLine("----------------------------------------------------------");
            for (int i = 0; i < topList.GetLength(0); i++)
            {
                Console.WriteLine("{0,14} {1,30} {2,7}", topList[i, 0], topList[i, 1], topList[i, 2]);
            }
            Console.ResetColor();
            Console.WriteLine("Nyomj entert , hogy visszatérj a menübe..");
            Console.ReadLine();
            Console.Title = "Menü";
        }


        //GAME
        public static void DrawMap(string[,] _map)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] == "K")
                    {
                        Console.Write(" ");
                    }
                    else if (_map[i, j] == "B")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(_map[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        //start and end index color
        public static void EndIndexColor(int left_, int top_)
        {
            Console.SetCursorPosition(left_, top_);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" ");
            Console.ResetColor();
        }
        public static void PlayerStatus(int left_, int top_)
        {
            Console.SetCursorPosition(left_, top_);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("O");
            Console.SetCursorPosition(left_, top_);
            Console.ResetColor();
        }
        public static void PlayerBeforeStatus(int left_, int top_)
        {
            Console.SetCursorPosition(left_, top_);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(".");
            Console.SetCursorPosition(left_, top_);
            Console.ResetColor();
        }


        //new record
        public static string NewTopFive()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GRATULÁLOK BEkerültél a legjobb 5-be!");
            Console.ResetColor();
            Console.Write("Kérlek add meg a neved, ami majd a toplistában lesz:");
            return Console.ReadLine();
        }
        public static void WinButNotTopFive()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GRATULÁLOK kitaláltál a labirintusból!");
            Console.ResetColor();
        }


        public static void StartCount(string[,] array3, string[,] array2, string[,] array1, string[,] array0)
        {
            Console.Clear();
            int left = 25;
            int top = 2;


            for (int i = 0; i < array3.GetLength(0); i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < array3.GetLength(1); j++)
                {
                    if (array3[i, j] == "|" || array3[i, j] == "+" || array3[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(array3[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                top++;
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
            left = 25;
            top = 2;
            Console.Clear();
            for (int i = 0; i < array2.GetLength(0); i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    if (array2[i, j] == "|" || array2[i, j] == "+" || array2[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(array2[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                top++;
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);

            left = 35;
            top = 2;
            Console.Clear();
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (array1[i, j] == "|" || array1[i, j] == "+" || array1[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(array1[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                top++;
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);

            left = 25;
            top = 2;
            Console.Clear();
            for (int i = 0; i < array0.GetLength(0); i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < array0.GetLength(1); j++)
                {
                    if (array0[i, j] == "|" || array0[i, j] == "+" || array0[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write(array0[i, j]);
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                }
                top++;
            }
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);


        }
    }
}
