using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LáncKód
{
    static class Show
    {
        public static void DrawMap(string[,] _map)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] == "+" || _map[i, j] == "-" || _map[i, j] == "|")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(_map[i, j]);
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


        public static void ShowNextMovement(int top, int left)
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("X");
            Console.ResetColor();
        }

    }
}
